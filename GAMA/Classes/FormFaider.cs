using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System;

namespace GAMA
{
    public class FormFader
    {
        public FormFader(Form form, int delay, double maxOpacity)
        {
            form.Shown += Form_Show;
            form.FormClosing += Form_Closeing;
            form.Opacity = 0;
            _form = form;
            _delay = delay;
            _timer.Elapsed += Timer_Tick;
            MAX_OPACITY = maxOpacity;
        }

        #region Fields

        protected readonly Form _form;
        protected System.Timers.Timer _timer = new System.Timers.Timer(50);
        protected TransitionStep _transitionStep;
        protected readonly int _delay;
        public readonly double MAX_OPACITY = 1D;
        public readonly double MIN_OPACITY = 0D;

        #endregion


        #region Event Emplication

        private void Form_Show(object sender, EventArgs e)
        {
            _transitionStep = null;
            _transitionStep = CreateTransition(MAX_OPACITY);
            if (!_timer.Enabled)
                _timer.Start();
        }

        private void Form_Closeing(object sender, FormClosingEventArgs e)
        {
            if (_form.Opacity != MIN_OPACITY)
            {
                e.Cancel = true;
                _transitionStep = null;
                _transitionStep = CreateTransition(MIN_OPACITY);
                if (!_timer.Enabled)
                    _timer.Start();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _transitionStep?.UpdateTransiotionPosition();
        }

        private void Transition_Finished(object sender, EventArgs e)
        {
            if (_timer.Enabled)
                _timer.Stop();
            sender = null;
            if (_form.Opacity == MIN_OPACITY)
                _form.Invoke((MethodInvoker)delegate { _form.Close(); });
        }

        #endregion


        #region Functions

        protected virtual TransitionStep CreateTransition(double value)
        {
            TransitionStep result = new TransitionStep(_form, "Opacity", value, _delay);
            result.TrantisionFinished += Transition_Finished;
            return result;
        }

        #endregion
    }
}