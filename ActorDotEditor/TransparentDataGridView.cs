using System;
using System.Drawing;
using System.Windows.Forms;

namespace ActorDotEditor
{
    public class TransparentDataGridView : DataGridView
    {
        public TransparentDataGridView()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DefaultCellStyle.BackColor = Color.Transparent;
            RowHeadersDefaultCellStyle.BackColor = Color.Transparent;
            ColumnHeadersDefaultCellStyle.BackColor = Color.Transparent;
            EnableHeadersVisualStyles = false;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x20; // WS_EX_TRANSPARENT
                return cp;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Do not paint background to keep transparency
        }
    }
}

