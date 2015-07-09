using Heren.Common.DockSuite;
using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Windy.Printer.Control;
using Windy.Printer.Utility;

namespace Windy.Printer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void WordSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (fileDialog.FileName.Contains("doc"))
                {
                    WinWordDocForm frm = new WinWordDocForm();
                    frm.Text = System.IO.Path.GetFileName(fileDialog.FileName);
                    frm.OpenDocument(fileDialog.FileName);
                    frm.Show(this.dockPanel1);
                    frm.Activate();
                }
            }
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            WinWordDocForm frm = new WinWordDocForm();
            frm.Text = "temp.doc";
            frm.OpenDocument(string.Format("{0}/{1}", Application.StartupPath, "temp.doc"));
            frm.Show(this.dockPanel1);
            frm.Activate();

        }

        private void PdfSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (fileDialog.FileName.Contains("pdf"))
                {
                    PdfForm frm = new PdfForm();
                    frm.Text = System.IO.Path.GetFileName(fileDialog.FileName);
                    frm.OpenDocument(fileDialog.FileName);
                    frm.Show(this.dockPanel1);
                    frm.Activate();
                }
            }
        }

        private void tsmSettingPrinting_Click(object sender, EventArgs e)
        {
            if (this.dockPanel1.ActiveDocument == null)
                return;

            using (UserModel objPrint = new UserModel())
            {
                IDocument document = null;
                if (this.dockPanel1.ActiveDocument is WinWordDocForm)
                {
                    document = this.dockPanel1.ActiveDocument as WinWordDocForm;

                }
                else if (this.dockPanel1.ActiveDocument is PdfForm)
                {
                    document = this.dockPanel1.ActiveDocument as PdfForm;
                }

                objPrint.Print(document.GetFileFullPath());

                if (objPrint.PrintResult == DocPrintResult.SENT_SUCCESSFULLY)
                {
                    MessageBox.Show("打印成功");
                }
                else
                {
                    MessageBox.Show("打印失败");
                }
            }

        }
    }
}
