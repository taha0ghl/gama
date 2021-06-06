using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GAMA;
using System.Collections;

namespace MyClass
{
    public class Locations
    {
        //Methods******************************
        #region

        // Control - Control **************
        #region

        // Order (X)
        public static void Left(Control constCtrl, int space, bool order, params Control[] ctrls)
        {
            Control _constCtrl = constCtrl;

            for (int i = 0; i < ctrls.Length; i++)
            {
                ctrls[i].Left = _constCtrl.Left - ctrls[i].Width - space;

                if (order)
                {
                    _constCtrl = ctrls[i];
                }
            }
        }
        public static void Right(Control constCtrl, int space, bool order, params Control[] ctrls)
        {
            Control _constCtrl = constCtrl;

            for (int i = 0; i < ctrls.Length; i++)
            {
                ctrls[i].Left = _constCtrl.Left + _constCtrl.Width + space;

                if (order)
                {
                    _constCtrl = ctrls[i];
                }
            }
        }

        // Order (Y)
        public static void Up(Control constCtrl, int space, bool order, params Control[] ctrls)
        {
            Control _constCtrl = constCtrl;

            for (int i = 0; i < ctrls.Length; i++)
            {
                ctrls[i].Top = _constCtrl.Top - ctrls[i].Height - space;

                if (order)
                {
                    _constCtrl = ctrls[i];
                }
            }
        }
        public static void Down(Control constCtrl, int space, bool order, params Control[] ctrls)
        {
            Control _constCtrl = constCtrl;

            for (int i = 0; i < ctrls.Length; i++)
            {
                ctrls[i].Top = _constCtrl.Bottom + space;

                if (order)
                {
                    _constCtrl = ctrls[i];
                }
            }
        }

        // X (Left)
        public static void AlignLefts(Control constControl, params Control[] ctrls)
        {
            for (int i = 0; i < ctrls.Length; i++)
            {
                ctrls[i].Left = constControl.Left;
            }
        }
        public static void AlignRights(Control constControl, params Control[] ctrls)
        {
            for (int i = 0; i < ctrls.Length; i++)
            {
                ctrls[i].Left = constControl.Right - ctrls[i].Width;
            }
        }
        public static void AlignCenters(Control constControl, params Control[] ctrls)
        {
            for (int i = 0; i < ctrls.Length; i++)
            {
                ctrls[i].Left = constControl.Left + constControl.Width / 2 - ctrls[i].Width / 2;
            }
        }

        // Y (Top)
        public static void AlignTops(Control constControl, params Control[] ctrls)
        {
            for (int i = 0; i < ctrls.Length; i++)
            {
                ctrls[i].Top = constControl.Top;
            }
        }
        public static void AlignMiddles(Control constCtrl, params Control[] ctrls)
        {
            for (int i = 0; i < ctrls.Length; i++)
            {
                ctrls[i].Top = constCtrl.Top + constCtrl.Height / 2 - ctrls[i].Height / 2;
            }
        }
        public static void AlignBottoms(Control constControl, params Control[] ctrls)
        {
            for (int i = 0; i < ctrls.Length; i++)
            {
                ctrls[i].Top = constControl.Bottom - ctrls[i].Height;
            }
        }

        #endregion

        // Control - Parent ***************
        #region

        // x (Left)
        public static void CenterWidth(Control parent, params Control[] ctrls)
        {
            for (int i = 0; i < ctrls.Length; i++)
            {
                ctrls[i].Left = Center(parent.ClientSize.Width, ctrls[i].Width);
            }
        }

        // Y (Top)
        public static void CenterHeight(Control parent, params Control[] ctrls)
        {
            for (int i = 0; i < ctrls.Length; i++)
            {
                if (parent is FrmMaster)
                {
                    ctrls[i].Top = Center(parent.ClientSize.Height - (parent as FrmMaster).HeaderHeight, ctrls[i].Height);
                    ctrls[i].Top += (parent as FrmMaster).HeaderHeight;
                }
                else
                {
                    ctrls[i].Top = Center(parent.ClientSize.Height, ctrls[i].Height);
                }
            }
        }

        // Order (X)
        public static void LeftOrder(int space, params Control[] ctrls)
        {
            for (int i = 0; i < ctrls.Length; i++)
            {
                ctrls[i].Left = space;
            }
        }
        public static void RightOrder(Control parent, int space, params Control[] ctrls)
        {
            for (int i = 0; i < ctrls.Length; i++)
            {
                ctrls[i].Left = parent.ClientSize.Width - ctrls[i].Width - space;
            }
        }

        // Order(Y)
        // ******************

        #endregion

        // Else ***************************
        #region
        public static void CenterScreen(Control ctrl)
        {
            ctrl.Location = new Point(Locations.Center((Screen.PrimaryScreen.Bounds.Width), ctrl.Width), Locations.Center(Screen.PrimaryScreen.Bounds.Height, ctrl.Height));
        }
        private static int Center(double parentsize, double size)
        {
            return Convert.ToInt32(parentsize / 2 - size / 2);
        }
        #endregion

        #endregion
        //*************************************
    }
}
