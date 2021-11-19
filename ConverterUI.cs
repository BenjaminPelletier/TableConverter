using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableConverter
{
    public partial class ConverterUI : Form
    {
        public ConverterUI()
        {
            InitializeComponent();
        }

        private void clipboardMonitor1_ClipboardChanged(object sender, ClipboardChangedEventArgs e)
        {
            UpdateFromClipboard();
        }

        private void ConverterUI_Load(object sender, EventArgs e)
        {
            UpdateFromClipboard();
        }

        private void UpdateFromClipboard()
        {
            clipboardViewerUI1.ReadClipboard();
            if (!Clipboard.ContainsText(TextDataFormat.Html) || !Converter.HasValidTable(Clipboard.GetText(TextDataFormat.Html)))
            {
                tabControl1.SelectedTab = tpClipboardViewer;
                return;
            }
            else
            {
                tabControl1.SelectedTab = tpTableConverter;
                tableConverterUI1.ClipboardHtml = Clipboard.GetText(TextDataFormat.Html);
            }
        }
    }
}
