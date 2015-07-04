// ***********************************************************
// 护理电子病历系统,主窗口全局功能tab页窗口基类.
// Creator:YangMingkun  Date:2012-3-20
// Copyright : Heren Health Services Co.,Ltd.
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.DockSuite;

namespace Windy.Printer.DockForms
{
    internal partial class DockContentBase : DockContent
    {
        private MainForm m_mainFrame = null;

        /// <summary>
        /// 获取或设置主程序控件
        /// </summary>
        [Browsable(false)]
        protected virtual MainForm MainFrame
        {
            get
            {
                if (this.m_mainFrame == null)
                    return null;
                if (this.m_mainFrame.IsDisposed)
                    return null;
                return this.m_mainFrame;
            }

            set
            {
                this.m_mainFrame = value;
            }
        }
        
        private int m_index = 0;

        /// <summary>
        /// 获取或设置当前窗口显示序号
        /// </summary>
        [Browsable(false)]
        public virtual int Index
        {
            get { return this.m_index; }
            set { this.m_index = value; }
        }

        /// <summary>
        /// 获取当前窗口数据是否已经被修改
        /// </summary>
        [Browsable(false)]
        public virtual bool IsModified
        {
            get { return false; }
        }

        private bool m_bUserChanged = true;

        /// <summary>
        /// 获取当前登录用户是否已经改变,改变后则刷新视图
        /// </summary>
        [Browsable(false)]
        public virtual bool UserChanged
        {
            get { return this.m_bUserChanged; }
        }

        private bool m_bDisplayDeptChanged = true;

        /// <summary>
        /// 获取当前显示的科室是否已经改变,改变后则刷新视图
        /// </summary>
        [Browsable(false)]
        public virtual bool DisplayDeptChanged
        {
            get { return this.m_bDisplayDeptChanged; }
        }

        private bool m_bPatientTableChanged = true;

        /// <summary>
        /// 获取当前病人列表数据是否已经改变,改变后则刷新视图
        /// </summary>
        [Browsable(false)]
        public virtual bool PatientTableChanged
        {
            get { return this.m_bPatientTableChanged; }
        }

        private bool m_bEventEnabledOnHidden = false;

        /// <summary>
        /// 获取或设置当当前窗口处于隐藏状态时,是否需要处理上层发来的事件消息
        /// </summary>
        [Browsable(false)]
        public virtual bool EventEnabledOnHidden
        {
            get { return this.m_bEventEnabledOnHidden; }
            set { this.m_bEventEnabledOnHidden = value; }
        }

        public DockContentBase()
            : this(null)
        {
        }

        public DockContentBase(MainForm parent)
        {
            this.m_mainFrame = parent;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.BindingSystemEvents();
        }

        protected virtual void BindingSystemEvents()
        {
            if (this.m_mainFrame == null || this.m_mainFrame.IsDisposed)
                return;
            EventHandler activeContentChangedEventHandler =
                new EventHandler(this.MainFrame_ActiveContentChanged);
           
        
        }

        public virtual void RefreshView()
        {
            this.m_bUserChanged = false;
            this.m_bPatientTableChanged = false;
        }

        /// <summary>
        /// 检查当前数据编辑窗口是否已经改变
        /// </summary>
        /// <returns>是否取消</returns>
        public virtual bool CheckModifyState()
        {
            return false;
        }

        /// <summary>
        /// 刷新视图方法
        /// </summary>
        public virtual void OnRefreshView()
        {
        }

        /// <summary>
        /// 当病人列表数据改变时自动调用的方法
        /// </summary>
        protected virtual void OnPatientTableChanged()
        {
        }

        /// <summary>
        /// 停靠窗口的活动状态改变时自动调用的方法
        /// 在子类中重写此方法来初始化当前的数据
        /// </summary>
        protected virtual void OnActiveContentChanged()
        {
        }

        /// <summary>
        /// 显示科室改变时自动调用的方法
        /// 在子类中重写此方法来刷新当前的数据
        /// </summary>
        protected virtual void OnDisplayDeptChanged(EventArgs e)
        {
        }

        private void System_PatientTableChanged(object sender, EventArgs e)
        {
            this.m_bPatientTableChanged = true;
            if (!this.DockHandler.IsHidden || this.m_bEventEnabledOnHidden)
                this.OnPatientTableChanged();
        }


        private void System_DisplayDeptChanged(object sender, EventArgs e)
        {
            this.m_bDisplayDeptChanged = true;
            if (!this.DockHandler.IsHidden || this.m_bEventEnabledOnHidden)
                this.OnDisplayDeptChanged(e);
        }

        private void MainFrame_ActiveContentChanged(object sender, EventArgs e)
        {
            if (!this.DockHandler.IsHidden || this.m_bEventEnabledOnHidden)
                this.OnActiveContentChanged();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (this.m_mainFrame == null || this.m_mainFrame.IsDisposed)
                return;
          
        }
    }
}
