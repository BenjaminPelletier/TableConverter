namespace TableConverter
{
    partial class ConverterUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpClipboardViewer = new System.Windows.Forms.TabPage();
            this.clipboardViewerUI1 = new TableConverter.ClipboardViewerUI();
            this.tpTableConverter = new System.Windows.Forms.TabPage();
            this.tableConverterUI1 = new TableConverter.TableConverterUI();
            this.clipboardMonitor1 = new TableConverter.ClipboardMonitor();
            this.tabControl1.SuspendLayout();
            this.tpClipboardViewer.SuspendLayout();
            this.tpTableConverter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpClipboardViewer);
            this.tabControl1.Controls.Add(this.tpTableConverter);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 426);
            this.tabControl1.TabIndex = 3;
            // 
            // tpClipboardViewer
            // 
            this.tpClipboardViewer.Controls.Add(this.clipboardViewerUI1);
            this.tpClipboardViewer.Location = new System.Drawing.Point(4, 22);
            this.tpClipboardViewer.Name = "tpClipboardViewer";
            this.tpClipboardViewer.Padding = new System.Windows.Forms.Padding(3);
            this.tpClipboardViewer.Size = new System.Drawing.Size(768, 400);
            this.tpClipboardViewer.TabIndex = 1;
            this.tpClipboardViewer.Text = "Clipboard viewer";
            this.tpClipboardViewer.UseVisualStyleBackColor = true;
            // 
            // clipboardViewerUI1
            // 
            this.clipboardViewerUI1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clipboardViewerUI1.Location = new System.Drawing.Point(6, 6);
            this.clipboardViewerUI1.Name = "clipboardViewerUI1";
            this.clipboardViewerUI1.Size = new System.Drawing.Size(756, 388);
            this.clipboardViewerUI1.TabIndex = 0;
            // 
            // tpTableConverter
            // 
            this.tpTableConverter.Controls.Add(this.tableConverterUI1);
            this.tpTableConverter.Location = new System.Drawing.Point(4, 22);
            this.tpTableConverter.Name = "tpTableConverter";
            this.tpTableConverter.Size = new System.Drawing.Size(768, 400);
            this.tpTableConverter.TabIndex = 2;
            this.tpTableConverter.Text = "Table converter";
            this.tpTableConverter.UseVisualStyleBackColor = true;
            // 
            // tableConverterUI1
            // 
            this.tableConverterUI1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableConverterUI1.Location = new System.Drawing.Point(3, 3);
            this.tableConverterUI1.Name = "tableConverterUI1";
            this.tableConverterUI1.Size = new System.Drawing.Size(762, 394);
            this.tableConverterUI1.TabIndex = 0;
            // 
            // clipboardMonitor1
            // 
            this.clipboardMonitor1.BackColor = System.Drawing.Color.Red;
            this.clipboardMonitor1.Location = new System.Drawing.Point(413, 259);
            this.clipboardMonitor1.Name = "clipboardMonitor1";
            this.clipboardMonitor1.Size = new System.Drawing.Size(75, 23);
            this.clipboardMonitor1.TabIndex = 2;
            this.clipboardMonitor1.Text = "clipboardMonitor1";
            this.clipboardMonitor1.Visible = false;
            this.clipboardMonitor1.ClipboardChanged += new System.EventHandler<TableConverter.ClipboardChangedEventArgs>(this.clipboardMonitor1_ClipboardChanged);
            // 
            // ConverterUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.clipboardMonitor1);
            this.Name = "ConverterUI";
            this.Text = "Table converter";
            this.Load += new System.EventHandler(this.ConverterUI_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpClipboardViewer.ResumeLayout(false);
            this.tpTableConverter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ClipboardMonitor clipboardMonitor1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpClipboardViewer;
        private System.Windows.Forms.TabPage tpTableConverter;
        private ClipboardViewerUI clipboardViewerUI1;
        private TableConverterUI tableConverterUI1;
    }
}

