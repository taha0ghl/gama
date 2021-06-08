using System;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics;

namespace GAMA
{
    // Implemented Strategy Pattern
    public class TransitionStep : ITransitionStep
    {
        #region Fields

        static private readonly Dictionary<Type, ITransitionStrategy> _suportedTypeList = new Dictionary<Type, ITransitionStrategy>()
        {
            { typeof(Color), new TransitionStrategy_Color() },
            {typeof(double), new TransitionStrategy_Double() },
            {typeof(int), new TransitionStrategy_Integer() }
        };
        private readonly PropertyInfo _property;
        public readonly Control target;
        public ITransitionStrategy strategy;
        public readonly Stopwatch start_time;
        public readonly int delay;
        public readonly object max_value;
        private readonly object minValue;

        #endregion


        #region Methods

        public TransitionStep(Control target, string property, object value, int delay)
        {
            PropertyInfo info = target.GetType().GetProperty(property);
            CheckValidation(info, value);
            this._property = info;
            //this.minValue = info.GetValue(target);
            this.max_value = value;
            this.delay = delay;
            this.target = target;
            strategy = GetStrategyFor(info.PropertyType);
            this.start_time = Stopwatch.StartNew();
        }

        public void CheckValidation(PropertyInfo propInfo, object value)
        {
            if (value is null)
                throw new ArgumentNullException("value", "argument is null");
            else if (!propInfo.CanRead || !propInfo.CanWrite)
                throw new ArgumentException("property is not read and write");
            else if (!propInfo.PropertyType.IsAssignableFrom(value.GetType()))
                throw new ArgumentException("property and value are not the same type");
            else if (!IsTypeSupported(propInfo.PropertyType))
                throw new ArgumentException("we don't support type " + propInfo.PropertyType);
        }

        public static bool IsTypeSupported(Type type)
        {
            return _suportedTypeList.ContainsKey(type);
        }

        public static ITransitionStrategy GetStrategyFor(Type type)
        {
            return _suportedTypeList[type];
        }

        public void UpdateTransiotionPosition()
        {
            double percent = GetPercent(start_time.ElapsedMilliseconds, delay);
            if (percent > 1)
                percent = 1;
            strategy.Mix(target, _property, minValue, max_value, percent);
            if (percent == 1)
                TrantisionFinished?.Invoke(this, new EventArgs());
        }

        protected double GetPercent(long passedTime, long delay)
        {
            return passedTime / (double)delay;
        }

        #endregion


        #region Events

        public event EventHandler TrantisionFinished;

        #endregion
    }
}
