using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.DockSuite;
using Heren.Common.Libraries;
using Windy.Printer.DockForms;

namespace Windy.Printer.Control
{
    internal partial class PdfForm : DockContentBase,IDocument
    {

        public PdfForm()
        {
            InitializeComponent();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
          
        }
        private string m_szFileFullName = string.Empty;
        /// <summary>
        /// 打开指定的Word文档
        /// </summary>
        /// <param name="szFilePath">文件路径</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public short OpenDocument(string szFilePath)
        {
            axAcroPDF1.LoadFile(szFilePath);
            this.m_szFileFullName = szFilePath;
            return SystemConst.ReturnValue.OK;
        }

        /// <summary>
        /// 关闭当前文档
        /// </summary>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public short CloseDocument()
        {
            return SystemConst.ReturnValue.OK;
        }

        private void WinWordDocForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.CloseDocument();
        }


        public string GetFileFullPath()
        {
            return this.m_szFileFullName;
        }
    }
}