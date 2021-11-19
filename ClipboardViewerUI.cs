using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace TableConverter
{
    public partial class ClipboardViewerUI : UserControl
    {
        public ClipboardViewerUI()
        {
            InitializeComponent();
        }

        private void lbFormats_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbFormats.SelectedIndex == -1)
            {
                txtContent.Text = "";
            }
            else
            {
                TextDataFormat format = (TextDataFormat)Enum.Parse(typeof(TextDataFormat), lbFormats.SelectedItem as string);
                txtContent.Text = Clipboard.GetText(format);
            }
        }

        public void ReadClipboard()
        {
            string previouslySelected = lbFormats.SelectedIndex > -1 ? lbFormats.SelectedItem as string : null;

            lbFormats.Items.Clear();
            foreach (var format in Enum.GetValues(typeof(TextDataFormat)))
            {
                if (Clipboard.ContainsText((TextDataFormat)format))
                {
                    lbFormats.Items.Add(format.ToString());
                    if (format.ToString() == previouslySelected)
                    {
                        lbFormats.SelectedIndex = lbFormats.Items.Count - 1;
                    }
                }
            }
        }
    }
}
