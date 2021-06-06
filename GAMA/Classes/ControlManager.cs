using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace GAMA
{
    public static class ControlManager
    {
        public static bool CheckEmptyControls(Control ctrl)
        {
            bool output = false;

            foreach (Control item in ctrl.Controls)
            {
                if (item.Tag == null || Convert.ToString(item.Tag) == string.Empty)
                {
                    continue;
                }

                if ((item is MaskedTextBox && !(item as MaskedTextBox).MaskCompleted) || (item is TextBox && (item as TextBox).TextLength == 0) || (item is ComboBox && (item as ComboBox).SelectedIndex == -1) || (item is ListBox && (item as ListBox).SelectedItems.Count == 0))
                {
                    MessageBox.Show(string.Format("فیلد {0} خالی میباشد", Convert.ToString(item.Tag)));
                    output = true;
                    break;
                }
            }

            return output;
        }
        public static bool CheckEmptyControls(params object[] ControlMessage)
        {
            for (int i = 0; i < ControlMessage.Length; i += 2)
            {
                Control c = ControlMessage[i] as Control;
                string msg = ControlMessage[i + 1] as string;
                if (c.Text == string.Empty)
                {
                    MessageBox.Show(msg, Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }
            return false;
        }
        public static void ReadOnly(Control parent, bool value , params Control[] exeptions)
        {
            foreach (TextBoxBase item in parent.Controls.OfType<TextBoxBase>())
            {
                if (exeptions.Contains(item))
                {
                    continue;
                }

                item.ReadOnly = value;
            }
        }
        public static void ClearControls(Control mainControl, params Control[] noClearControls)
        {
            foreach (Control item in mainControl.Controls)
            {
                if (noClearControls.Contains<Control>(item))
                {
                    continue;
                }

                if (item is TextBoxBase || item is ComboBox)
                {
                    item.Text = string.Empty;
                }
                else if (item is CheckBox)
                {
                    (item as CheckBox).Checked = false;
                }

                if (item.HasChildren)
                {
                    ClearControls(item);
                }
            }
        }
        public static void SetComboItems(ComboBox combo, ArrayList data)
        {
            combo.Items.Clear();
            combo.Items.AddRange(data.ToArray());
        }
    }
}
