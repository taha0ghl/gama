using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using MyClass;

namespace GAMA
{
    public partial class FrmDatePicker : Form
    {
        #region Fields

        private Color _dayItemsForeColor;
        private Color _dayItemsSelectedForeColor;
        private Color _dayItemsSelectedRingColor;
        private float _dayItemsSelectedRingWidth;
        private Color _dayItemsCurrantMarkColor;
        private Color _dayItemsCurrantForeColor;
        private bool _useFittedEllipseForDayItem = true;
        public readonly PersianCalendar Calendar = new PersianCalendar();

        #endregion


        #region Properties

        public int Day { get; protected set; }
        public int Month { get; protected set; }
        public int Year { get; protected set; }
        public string OkButtonText
        {
            get => btnOk.Text;
            set => btnOk.Text = value;
        }
        public string CancelButtonText
        {
            get => btnCancel.Text;
            set => btnCancel.Text = value;
        }
        public Color DayItemsForeColor
        {
            get => _dayItemsForeColor;
            set
            {
                _dayItemsForeColor = value;
                ChangeAllDayItems((c) => c.ForeColor = value);
            }
        }
        public Color DayItemsSelectedForeColor
        {
            get => _dayItemsSelectedForeColor;
            set
            {
                _dayItemsSelectedForeColor = value;
                ChangeAllDayItems((c) => c.SelectedForeColor = value);
            }
        }
        public float DayItemsSelectedRingWidth
        {
            get => _dayItemsSelectedRingWidth;
            set
            {
                _dayItemsSelectedRingWidth = value;
                ChangeAllDayItems((c) => c.SelectedRingWidth = value);
            }
        }
        public Color DayItemsSelectedRingColor
        {
            get => _dayItemsSelectedRingColor;
            set
            {
                _dayItemsSelectedRingColor = value;
                ChangeAllDayItems((c) => c.SelectedRingColor= value);
            }
        }
        public Color DayItemsCurrantMarkColor
        {
            get => _dayItemsCurrantMarkColor;
            set
            {
                _dayItemsCurrantMarkColor = value;
                ChangeAllDayItems((c) => c.CurrantRingColor = value);
            }
        }
        public Color DayItemsCurrantForeColor
        {
            get => _dayItemsCurrantForeColor;
            set
            {
                _dayItemsCurrantForeColor = value;
                ChangeAllDayItems((c) => c.CurrantForeColor = value);
            }
        }
        public bool UseFittedEllipeForDayItem
        {
            get => _useFittedEllipseForDayItem;
            set
            {
                _useFittedEllipseForDayItem = value;
                ChangeAllDayItems((c) => c.UseFitedEllipse = value);
            }
        }

        #endregion


        #region Methodes

        public FrmDatePicker(int year, int month, int day, string[] monthDays)
        {
            InitializeComponent();
            new MovableForm(pnlHeader);
            Year = year;
            Month = month;
            Day = day;
            LstMonth.List = monthDays;
            LstMonth.SelectedItemIndex = Month - 1;
            SetDaysToCalendar();
        }

        private void SetDaysToCalendar()
        {
            int startDay = (int)FindFirstDayOfMonth() - 1;
            int monthLength = Calendar.GetDaysInMonth((int)NumYear.Value, LstMonth.SelectedItemIndex + 1);
            tlpDays.Controls.Clear();
            for (int i = startDay; i < monthLength + startDay; i++)
            {
                DayItem item = CreateDayItem((i - startDay + 1).ToString(), i - startDay + 1);
                if (IsCurrantDay((int)NumYear.Value, LstMonth.SelectedItemIndex + 1, i - startDay + 1))
                    item.IsCurrant = true;
                tlpDays.Controls.Add(item, i % 7, i / 7);
            }
        }

        private PersianDayOfWeek FindFirstDayOfMonth()
        {
            return Calendar.GetDayOfWeek(new DateTime((int)NumYear.Value, LstMonth.SelectedItemIndex + 1, 1, new PersianCalendar())).PersionDayOfWeek();
        }

        private DayItem CreateDayItem(string text, int tag)
        {
            DayItem item = new DayItem()
            {
                Text = text,
                SelectedForeColor = Color.FromArgb(204, 0, 255),
                SelectedRingWidth = 2,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                RightToLeft = RightToLeft.Yes,
                Tag = tag
            };
            item.Click += DayItem_Click;
            return item;
        }

        private bool IsCurrantDay(int year, int month, int day)
        {
            return year == Year && month == Month && day == Day;
        }

        private void ChangeAllDayItems(Action<DayItem> item)
        {
            for (int i = 0; i < tlpDays.Controls.Count; i++)
                if (tlpDays.Controls[1].GetType().Equals(typeof(DayItem)))
                    item(tlpDays.Controls[i] as DayItem);
        }

        private bool IsThereAnyItemSelected()
        {
            bool result = false;
            for (int i = 0; i < tlpDays.Controls.Count; i++)
                if (typeof(DayItem).Equals(tlpDays.Controls[i].GetType()))
                {
                    DayItem item = tlpDays.Controls[i] as DayItem;
                    if (item.IsSelected)
                    {
                        result = true;
                        break;
                    }
                }
            return result;
        }

        private int FindSelectedDay()
        {
            int result = -1;
            for (int i = 0; i < tlpDays.Controls.Count; i++)
                if (typeof(DayItem).Equals(tlpDays.Controls[i].GetType()))
                {
                    DayItem item = tlpDays.Controls[i] as DayItem;
                    if (item.IsSelected)
                    {
                        result = (int)item.Tag;
                        break;
                    }
                }
            return result;
        }

        #endregion


        #region Event Implimcation

        private void DayItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tlpDays.Controls.Count; i++)
            {
                if (sender != tlpDays.Controls[i] && tlpDays.Controls[i].GetType().Equals(typeof(DayItem)))
                {
                    DayItem item = (tlpDays.Controls[i] as DayItem);
                    if (item.IsSelected)
                        item.IsSelected = false;
                }
            }
            btnOk.Enabled = IsThereAnyItemSelected();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Year = (int)NumYear.Value;
            Month = LstMonth.SelectedItemIndex + 1;
            Day = FindSelectedDay();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Num_LostFocus(object sender, EventArgs e)
        {
            SetDaysToCalendar();
        }

        private void LstMonth_SelectedItemChanged(object sender, EventArgs e)
        {
            SetDaysToCalendar();
        }

        private void Pnl_MouseDown(object sender, MouseEventArgs e)
        {
            flpButtons.Focus();
        }

        #endregion

    }
}
