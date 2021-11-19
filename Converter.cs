using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TableConverter
{
    class Converter
    {
        private string TableAttributes;

        private static readonly string[] RECOGNIZED_ATTRIBUTES = { "colspan", "rowspan" };

        public Converter(string tableAttributes)
        {
            TableAttributes = tableAttributes;
        }

        public static bool HasValidTable(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            return doc.DocumentNode.Descendants("table").Any();
        }

        public string ConvertTable(HtmlNode srcTable)
        {
            var doc = new HtmlDocument();
            HtmlNode table = HtmlNode.CreateNode(string.Format("<table {0}></table>", this.TableAttributes));
            doc.DocumentNode.AppendChild(table);

            // Create caption
            HtmlNode caption = HtmlNode.CreateNode("<caption style=\"caption-side:top;text-align:center;font-weight:bold;color:black\">Table Title</caption>");
            table.AppendChild(caption);

            // Create header
            HtmlNode header = HtmlNode.CreateNode("<thead></thead>");
            table.AppendChild(header);

            // Create body
            HtmlNode body = HtmlNode.CreateNode("<tbody></tbody>");
            table.AppendChild(body);

            // Process rows in source table
            foreach (HtmlNode n in srcTable.ChildNodes)
            {
                if (n.Name.ToLower() == "th" || n.Name.ToLower() == "tr")
                {
                    // Row
                    body.AppendChild(ConvertRow(n));
                }
                else
                {
                    // Something else; ignore
                }
            }

            // Change the first row into the caption if it spans the entire table
            int columnCount = body.ChildNodes.Select(r => r.ChildNodes.Select(n => n.GetAttributeValue("colspan", 1)).Sum()).Max();
            HtmlNode firstRow = body.ChildNodes[0];
            if (firstRow.ChildNodes.Count == 1 && firstRow.ChildNodes[0].GetAttributeValue("colspan", 0) == columnCount)
            {
                caption.InnerHtml = firstRow.ChildNodes[0].InnerHtml;
                body.ChildNodes.RemoveAt(0);
            }

            // Pretty-print result to string and return it
            using (var s = new MemoryStream())
            {
                doc.Save(s, Encoding.UTF8);
                s.Position = 0;
                var tidy = TidyManaged.Document.FromStream(s);
                tidy.OutputBodyOnly = TidyManaged.AutoBool.Yes;
                tidy.IndentBlockElements = TidyManaged.AutoBool.Yes;
                tidy.IndentSpaces = 2;
                tidy.CleanAndRepair();
                return tidy.Save();
            }
        }

        private HtmlNode ConvertRow(HtmlNode srcRow)
        {
            bool header = srcRow.Name.ToLower() == "th";
            HtmlNode row = HtmlNode.CreateNode(string.Format("<{0}></{0}>", srcRow.Name.ToLower()));
            foreach (HtmlNode n in srcRow.ChildNodes)
            {
                if (n.Name.ToLower() == "td")
                {
                    // This is a cell; format the contents
                    string cellText = n.InnerText
                        .Replace("&nbsp;", " ") // Replace non-breaking space with normal space
                        .Replace("\r\n", " ").Replace("\r", " ").Replace("\n", " ") // Replace line break with normal space
                        .Trim(); // Remove leading and trailing spaces
                    cellText = Regex.Replace(cellText, @"\s+", " "); // Collapse multiple consecutive spaces into one
                    HtmlNode cell = HtmlNode.CreateNode(string.Format("<td>{0}</td>", cellText));

                    // Transfer retained attributes (if present)
                    foreach (string attribute in RECOGNIZED_ATTRIBUTES)
                    {
                        string value = n.GetAttributeValue(attribute, null);
                        if (value != null)
                        {
                            cell.SetAttributeValue(attribute, value);
                        }
                    }

                    row.AppendChild(cell);
                }
                else
                {
                    // Something else
                }
            }
            return row;
        }
    }
}
