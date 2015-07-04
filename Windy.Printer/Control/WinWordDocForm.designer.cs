namespace Windy.Printer.Control
{
    partial class WinWordDocForm
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
            this.winWordCtrl1 = new Windy.Printer.Control.WinWordCtrl();
            this.SuspendLayout();
            // 
            // winWordCtrl1
            // 
            this.winWordCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.winWordCtrl1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.winWordCtrl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.winWordCtrl1.Location = new System.Drawing.Point(0, 0);
            this.winWordCtrl1.Name = "winWordCtrl1";
            this.winWordCtrl1.Size = new System.Drawing.Size(939, 620);
            this.winWordCtrl1.TabIndex = 0;
            // 
            // WinWordDocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 620);
            this.Controls.Add(this.winWordCtrl1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "WinWordDocForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WinWordDocForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WinWordDocForm_FormClosing);
            this.ResumeLayout(false);
        }
        #endregion

        private WinWordCtrl winWordCtrl1;
    }
}