using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAMA
{
    public partial class HorizontalListNavigator : UserControl
    {
        #region Fields

        private string[] _list;
        private int _buttonsWidth = 30;
        private int _selectedItemIndex = 0;
        private Image _leftButtonImage;
        private Image _rightButtonImage;
        private Font _btnFont = new Font("Tahoma", 9, FontStyle.Regular);
        private ImageLayout _buttonsImageLayout = ImageLayout.Zoom;

        #endregion


        #region Properties

        public string[] List
        {
            get => _list;
            set
            {
                _list = value;
                if (value != null && value.Length != 0)
                {
                    lblText.Text = value[SelectedItemIndex];
                    btnRight.Enabled = btnLeft.Enabled = true;
                }
                else
                {
                    lblText.Text = string.Empty;
                    btnRight.Enabled = btnLeft.Enabled = false;
                }
            }
        }
        public int ButtonsWidth
        {
            get => _buttonsWidth;
            set
            {
                tlp.ColumnStyles[0].Width = tlp.ColumnStyles[2].Width = value;
                _buttonsWidth = value;
            }
        }
        public int SelectedItemIndex
        {
            get => _selectedItemIndex;
            set
            {
                _selectedItemIndex = value;
                if (List == null) return;
                lblText.Text = List[value];
                SelectedItemChanged?.Invoke(this, new EventArgs());
            }
        }
        public Image LeftButtonImage
        {
            get => _leftButtonImage;
            set
            {
                btnLeft.BackgroundImage = value;
                _leftButtonImage = value;
            }
        }
        public Image RightButtonImage
        {
            get => _rightButtonImage;
            set
            {
                //if (value != null)
                btnRight.BackgroundImage = value;
                _rightButtonImage = value;
            }
        }
        public ImageLayout ButtonImageLayout
        {
            get => _buttonsImageLayout;
            set
            {
                btnRight.BackgroundImageLayout = value;
                btnLeft.BackgroundImageLayout = value;
                _buttonsImageLayout = value;
            }
        }
        public string LeftButtonText
        {
            get => btnLeft.Text;
            set => btnLeft.Text = value;
        }
        public string RightButotnText
        {
            get => btnRight.Text;
            set => btnRight.Text = value;
        }
        public Font TextFont
        {
            get => lblText.Font;
            set => lblText.Font = value;
        }
        public Font ButtonFont
        {
            get => _btnFont;
            set
            {
                btnLeft.Font = btnRight.Font = value;
                _btnFont = value;
            }

        }

        #endregion


        #region Methode

        public HorizontalListNavigator()
        {
            InitializeComponent();
        }

        protected void ChangeSelectedItem(int distince)
        {
            if (List == null) return;
            int index = SelectCircularSum(SelectedItemIndex, distince, List.Length);
            SelectedItemIndex = index;
        }

        private int SelectCircularSum(int currantValue, int distance, int maxValue)
        {
            distance = distance % maxValue;
            int target = currantValue + distance;
            int result = 0;

            if (target >= 0 && target < maxValue)
                result = target;
            else if (target >= maxValue)
                result = maxValue - target;
            else if (target < 0)
                result = maxValue + distance;

            return result;
        }

        #endregion


        #region Event Implication

        private void BtnRight_Click(object sender, EventArgs e)
        {
            ChangeSelectedItem(-1);
            RightButtonClicked?.Invoke(sender, e);
        }

        private void BtnLeft_Click(object sender, EventArgs e)
        {
            ChangeSelectedItem(+1);
            LeftButtonClicked?.Invoke(sender, e);
        }

        #endregion


        #region Events

        public event EventHandler LeftButtonClicked;
        public event EventHandler RightButtonClicked;
        public event EventHandler SelectedItemChanged;

        #endregion
    }
}
