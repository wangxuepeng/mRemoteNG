﻿using System.ComponentModel;
using System.Windows.Forms;
using mRemoteNG.Themes;
using mRemoteNG.Tools;

namespace mRemoteNG.UI.Controls
{
    public class MultiSshToolStrip : ToolStrip
    {
        private IContainer components;
        private ToolStripLabel _lblMultiSsh;
        private ToolStripTextBox _txtMultiSsh;

        // ReSharper disable once NotAccessedField.Local
        private MultiSSHController _multiSshController;
        private readonly ThemeManager _themeManager;


        public MultiSshToolStrip()
        {
            InitializeComponent();
            _themeManager = ThemeManager.getInstance();
            _themeManager.ThemeChanged += ApplyTheme;
            ApplyTheme();
            _multiSshController = new MultiSSHController(_txtMultiSsh);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            _lblMultiSsh = new ToolStripLabel();
            _txtMultiSsh = new ToolStripTextBox();
            SuspendLayout();
            // 
            // lblMultiSSH
            // 
            _lblMultiSsh.Name = "_lblMultiSsh";
            _lblMultiSsh.Size = new System.Drawing.Size(77, 22);
            _lblMultiSsh.Text = Language.MultiSsh;
            // 
            // txtMultiSsh
            // 
            _txtMultiSsh.Name = "_txtMultiSsh";
            _txtMultiSsh.Size = new System.Drawing.Size(new DisplayProperties().ScaleWidth(300), 25);
            _txtMultiSsh.ToolTipText = Language.MultiSshToolTip;

            Items.AddRange(new ToolStripItem[]
            {
                _lblMultiSsh,
                _txtMultiSsh
            });
            ResumeLayout(true);
        }

        private void ApplyTheme()
        {
            if (!_themeManager.ActiveAndExtended) return;
            _txtMultiSsh.BackColor = _themeManager.ActiveTheme.ExtendedPalette.getColor("TextBox_Background");
            _txtMultiSsh.ForeColor = _themeManager.ActiveTheme.ExtendedPalette.getColor("TextBox_Foreground");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if(components != null)
                    components.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}