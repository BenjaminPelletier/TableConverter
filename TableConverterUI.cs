using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace TableConverter
{
    public partial class TableConverterUI : UserControl
    {
        private HtmlAgilityPack.HtmlDocument _Doc = null;

        public TableConverterUI()
        {
            InitializeComponent();
        }

        public string ClipboardHtml
        {
            set
            {
                _Doc = new HtmlAgilityPack.HtmlDocument();
                _Doc.LoadHtml(value);

                int previousIndex = cbTableIndex.SelectedIndex > -1 ? cbTableIndex.SelectedIndex : -1;
                cbTableIndex.Items.Clear();
                foreach (int i in Enumerable.Range(0, _Doc.DocumentNode.Descendants("table").Count()))
                {
                    cbTableIndex.Items.Add(i);
                }
                if (previousIndex > -1)
                {
                    cbTableIndex.SelectedIndex = previousIndex;
                }
                else if (cbTableIndex.Items.Count > 0)
                {
                    cbTableIndex.SelectedIndex = 0;
                }
            }
        }

        private void cbTableIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Doc != null && cbTableIndex.SelectedIndex > -1)
            {
                HtmlNode srcTable = _Doc.DocumentNode.Descendants("table").ElementAt(cbTableIndex.SelectedIndex);
                Converter converter = MakeConverterFromUI();
                txtResult.Text = converter.ConvertTable(srcTable);
            }
            else
            {
                txtResult.Text = "";
            }
        }

        private Converter MakeConverterFromUI()
        {
            return new Converter(tableAttributes: txtTableAttributes.Text);
        }
    }
}
