using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TINKIN01.Controls
{
    public partial class ChessControlAlert : UserControl
    {

        public ChessControlAlert()
        {
            InitializeComponent();
        }

        public ChessControlAlert(string title, string description) : this ()
        {
            LabelTitle.Text = title;
            LabelDescription.Text = description;
        }

        protected override void OnResize(EventArgs e)
        {
            var border = (int)(Height * 0.1f);
            var height = (int)(Height * 0.4f);
            LabelTitle.Location = new Point(0, border);
            LabelTitle.Height = height;
            LabelTitle.Width = Width;
            LabelTitle.Font = new Font(FontFamily.GenericSansSerif, LabelTitle.Height / 2, FontStyle.Bold, GraphicsUnit.Pixel);
            LabelDescription.Location = new Point(0, border*2 + height);
            LabelDescription.Height = height;
            LabelDescription.Width = Width;
            LabelDescription.Font = new Font(FontFamily.GenericSansSerif, LabelTitle.Height / 3, FontStyle.Regular, GraphicsUnit.Pixel);

            LabelTitle.Refresh();
            LabelDescription.Refresh();
            Refresh();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        
    }
}
