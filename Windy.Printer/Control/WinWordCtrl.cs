using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using Heren.Common.Libraries;

namespace Windy.Printer.Control
{
    public partial class WinWordCtrl : Panel
    {
        private Word._Document m_WordDoc = null;
        private Word.ApplicationClass m_WordApp = null;
        private IntPtr m_hWordWnd = IntPtr.Zero;

        #region"初始化"
        public WinWordCtrl()
        {
            this.BorderStyle = BorderStyle.Fixed3D;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
        }

        protected override void Dispose(bool disposing)
        {
            this.CloseDocument();
            this.CloseWordApplication();
            base.Dispose(disposing);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.ResumeLayout();
        }
        #endregion

        /// <summary>
        /// 激活当前病历文档
        /// </summary>
        public void Activate()
        {
            if (this.m_WordApp == null)
                return;
            try
            {
                if (!this.m_WordApp.Visible)
                    this.m_WordApp.Visible = true;
                //this.m_WordApp.Activate();
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("WinWordControl.OpenDocument", ex);
            }
        }

        private bool m_bShowInternalMenuStrip = false;

        /// <summary>
        /// 获取或设置是否显示编辑器自带的菜单栏
        /// </summary>
        [Description("获取或设置是否显示编辑器自带的菜单栏")]
        [DefaultValue(false)]

        public bool ShowInternalMenuStrip
        {
            get { return this.m_bShowInternalMenuStrip; }
            set { this.m_bShowInternalMenuStrip = value; }
        }

        private void HandleWordUILayout()
        {
            if (this.m_WordApp == null || this.m_WordApp.ActiveWindow == null)
                return;
            //隐藏WORD标题栏
            int nStyle = NativeMethods.User32.GetWindowLong(this.m_hWordWnd, NativeConstants.GWL_STYLE);
            NativeMethods.User32.SetWindowLong(this.m_hWordWnd
                , NativeConstants.GWL_STYLE, nStyle & ~NativeConstants.WS_CAPTION);

            this.m_WordApp.ActiveWindow.DocumentMap = false;
            this.m_WordApp.ActiveWindow.DisplayScreenTips = false;
         
            this.m_WordApp.ActiveWindow.DisplayRulers = false;
            this.m_WordApp.ActiveWindow.DisplayVerticalRuler = false;
            this.m_WordApp.ActiveWindow.Application.CommandBars.ActiveMenuBar.Enabled = this.m_bShowInternalMenuStrip;
            this.m_WordApp.ActiveWindow.Application.DisplayStatusBar = false;
          
            this.m_WordApp.ActiveWindow.ActivePane.View.Type = Word.WdViewType.wdPrintView;

            //隐藏保存等各按钮
            int nCount = this.m_WordApp.ActiveWindow.Application.CommandBars.Count;
            for (int index = 1; index <= nCount; index++)
            {
                if (this.m_WordApp.ActiveWindow.Application.CommandBars[index].Name == "Standard")
                {
                    this.m_WordApp.ActiveWindow.Application.CommandBars[index].Enabled = false;
                    this.m_WordApp.ActiveWindow.Application.CommandBars[index].Visible = false;
                    this.m_WordApp.ActiveWindow.Application.CommandBars[index].Controls[1].Enabled = false;
                    this.m_WordApp.ActiveWindow.Application.CommandBars[index].Controls[2].Enabled = false;
                    this.m_WordApp.ActiveWindow.Application.CommandBars[index].Controls[3].Enabled = false;
                    this.m_WordApp.ActiveWindow.Application.CommandBars[index].Controls[1].Visible = false;
                    this.m_WordApp.ActiveWindow.Application.CommandBars[index].Controls[2].Visible = false;
                    this.m_WordApp.ActiveWindow.Application.CommandBars[index].Controls[3].Visible = false;
                    break;
                }
            }
        }

        /// <summary>
        /// 打开指定的本地WORD病历文件
        /// </summary>
        /// <param name="szFilePath">本地路径</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public short OpenDocument(string szFilePath)
        {
            try
            {
                if (this.m_WordApp == null)
                    this.m_WordApp = new Word.ApplicationClass();
                this.m_WordApp.CommandBars.AdaptiveMenus = this.m_bShowInternalMenuStrip;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("WinWordControl.OpenDocument", ex);
                return SystemConst.ReturnValue.EXCEPTION;
            }

            this.CloseDocument();

            if (this.m_hWordWnd == IntPtr.Zero)
                this.m_hWordWnd = NativeMethods.User32.FindWindow("OpusApp", null);

            if (this.m_hWordWnd == IntPtr.Zero)
                return SystemConst.ReturnValue.FAILED;

            NativeMethods.User32.SetParent(this.m_hWordWnd, this.Handle);

            try
            {
                if (this.m_WordApp == null || this.m_WordApp.Documents == null)
                    return SystemConst.ReturnValue.FAILED;

                object fileName = szFilePath;
                object newTemplate = false;
                object docType = Word.WdDocumentType.wdTypeDocument;
                object isVisible = true;
                this.m_WordDoc = this.m_WordApp.Documents.Add(ref fileName, ref newTemplate, ref docType, ref isVisible);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("WinWordControl.OpenDocument", ex);
                return SystemConst.ReturnValue.EXCEPTION;
            }
            this.ResumeLayout();
           this.Activate();

            try
            {
                this.HandleWordUILayout();
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("WinWordControl.OpenDocument", ex);
            }
            return SystemConst.ReturnValue.OK;
        }

        public short CloseDocument()
        {
            try
            {
                object saveChanges = false;
                object originalFormat = null;
                object routeDocument = null;
                if (this.m_WordDoc != null)
                    this.m_WordDoc.Close(ref saveChanges, ref originalFormat, ref routeDocument);
                this.m_WordDoc = null;
                return SystemConst.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("WinWordControl.CloseDocument", ex);
                return SystemConst.ReturnValue.EXCEPTION;
            }
        }

        public void CloseWordApplication()
        {
            try
            {
                object saveChanges = false;
                object originalFormat = null;
                object routeDocument = null;
                if (this.m_WordApp != null)
                    this.m_WordApp.Quit(ref saveChanges, ref originalFormat, ref routeDocument);
                this.m_WordApp = null;
                this.m_hWordWnd = IntPtr.Zero;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("WinWordControl.CloseWordApplication", ex);
            }
        }

        new public void ResumeLayout()
        {
            if (this.m_hWordWnd == IntPtr.Zero || this.m_WordDoc == null)
                return;
            System.Drawing.Rectangle bounds = this.ClientRectangle;
            bounds.X += -SystemInformation.Border3DSize.Width * 2;
            bounds.Y += -SystemInformation.Border3DSize.Height * 2;
            bounds.Width += SystemInformation.Border3DSize.Width * 4;
            bounds.Height += SystemInformation.Border3DSize.Height * 4;
            NativeMethods.User32.MoveWindow(this.m_hWordWnd, bounds.X, bounds.Y, bounds.Width, bounds.Height, true);
        }
    }
}
