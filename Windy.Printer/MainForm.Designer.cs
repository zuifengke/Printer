namespace Windy.Printer
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dockPanel1 = new Heren.Common.DockSuite.DockPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WordSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.PdfSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSettingPrinting = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockPanel1
            // 
            this.dockPanel1.ActiveAutoHideContent = null;
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DockBackColor = System.Drawing.SystemColors.AppWorkspace;
            this.dockPanel1.DocumentStyle = Heren.Common.DockSuite.DocumentStyle.DockingWindow;
            this.dockPanel1.Location = new System.Drawing.Point(0, 25);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(831, 470);
            this.dockPanel1.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.tsmSettingPrinting});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(831, 25);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WordSelect,
            this.PdfSelect});
            this.文件ToolStripMenuItem.Image = global::Windy.Printer.Properties.Resources.file;
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // WordSelect
            // 
            this.WordSelect.Image = global::Windy.Printer.Properties.Resources.word;
            this.WordSelect.Name = "WordSelect";
            this.WordSelect.Size = new System.Drawing.Size(154, 22);
            this.WordSelect.Text = "选择word文档";
            this.WordSelect.Click += new System.EventHandler(this.WordSelect_Click);
            // 
            // PdfSelect
            // 
            this.PdfSelect.Image = global::Windy.Printer.Properties.Resources.pdf;
            this.PdfSelect.Name = "PdfSelect";
            this.PdfSelect.Size = new System.Drawing.Size(154, 22);
            this.PdfSelect.Text = "选择pdf文档";
            this.PdfSelect.Click += new System.EventHandler(this.PdfSelect_Click);
            // 
            // tsmSettingPrinting
            // 
            this.tsmSettingPrinting.Image = global::Windy.Printer.Properties.Resources.printer;
            this.tsmSettingPrinting.Name = "tsmSettingPrinting";
            this.tsmSettingPrinting.Size = new System.Drawing.Size(84, 21);
            this.tsmSettingPrinting.Text = "直接打印";
            this.tsmSettingPrinting.Click += new System.EventHandler(this.tsmSettingPrinting_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 495);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "文档浏览";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Heren.Common.DockSuite.DockPanel dockPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WordSelect;
        private System.Windows.Forms.ToolStripMenuItem PdfSelect;
        private System.Windows.Forms.ToolStripMenuItem tsmSettingPrinting;
    }
}

