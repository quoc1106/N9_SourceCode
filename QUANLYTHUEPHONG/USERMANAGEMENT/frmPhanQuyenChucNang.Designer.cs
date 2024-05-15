
namespace USERMANAGEMENT
{
    partial class frmPhanQuyenChucNang
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
            this.components = new System.ComponentModel.Container();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcUsers = new DevExpress.XtraGrid.GridControl();
            this.gvUsers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ISGROUP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.USERNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FULLNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IDUSER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcChucNang = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnCamQuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnChiXem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnToanQuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.gvChucNang = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.FUNC_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DESCRIPTION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QUYEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cISGROUP = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcChucNang)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvChucNang)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.gcUsers);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gcChucNang);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1115, 716);
            this.splitContainerControl1.SplitterPosition = 427;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // gcUsers
            // 
            this.gcUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcUsers.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gcUsers.Location = new System.Drawing.Point(0, 0);
            this.gcUsers.MainView = this.gvUsers;
            this.gcUsers.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gcUsers.Name = "gcUsers";
            this.gcUsers.Size = new System.Drawing.Size(427, 716);
            this.gcUsers.TabIndex = 0;
            this.gcUsers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUsers});
            // 
            // gvUsers
            // 
            this.gvUsers.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvUsers.Appearance.Row.Options.UseFont = true;
            this.gvUsers.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ISGROUP,
            this.USERNAME,
            this.FULLNAME,
            this.IDUSER});
            this.gvUsers.DetailHeight = 436;
            this.gvUsers.GridControl = this.gcUsers;
            this.gvUsers.Name = "gvUsers";
            this.gvUsers.OptionsEditForm.PopupEditFormWidth = 1000;
            this.gvUsers.OptionsView.ShowGroupPanel = false;
            this.gvUsers.RowHeight = 34;
            this.gvUsers.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvUsers_CustomDrawCell);
            this.gvUsers.Click += new System.EventHandler(this.gvUsers_Click);
            // 
            // ISGROUP
            // 
            this.ISGROUP.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.ISGROUP.AppearanceHeader.Options.UseFont = true;
            this.ISGROUP.Caption = " ";
            this.ISGROUP.FieldName = "ISGROUP";
            this.ISGROUP.MaxWidth = 50;
            this.ISGROUP.MinWidth = 37;
            this.ISGROUP.Name = "ISGROUP";
            this.ISGROUP.Visible = true;
            this.ISGROUP.VisibleIndex = 0;
            this.ISGROUP.Width = 50;
            // 
            // USERNAME
            // 
            this.USERNAME.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.USERNAME.AppearanceHeader.Options.UseFont = true;
            this.USERNAME.Caption = "USERNAME";
            this.USERNAME.FieldName = "USERNAME";
            this.USERNAME.MaxWidth = 125;
            this.USERNAME.MinWidth = 99;
            this.USERNAME.Name = "USERNAME";
            this.USERNAME.Visible = true;
            this.USERNAME.VisibleIndex = 1;
            this.USERNAME.Width = 117;
            // 
            // FULLNAME
            // 
            this.FULLNAME.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.FULLNAME.AppearanceHeader.Options.UseFont = true;
            this.FULLNAME.Caption = "FULLNAME";
            this.FULLNAME.FieldName = "FULLNAME";
            this.FULLNAME.MaxWidth = 187;
            this.FULLNAME.MinWidth = 150;
            this.FULLNAME.Name = "FULLNAME";
            this.FULLNAME.Visible = true;
            this.FULLNAME.VisibleIndex = 2;
            this.FULLNAME.Width = 150;
            // 
            // IDUSER
            // 
            this.IDUSER.Caption = "ID";
            this.IDUSER.FieldName = "IDUSER";
            this.IDUSER.MinWidth = 31;
            this.IDUSER.Name = "IDUSER";
            this.IDUSER.Width = 117;
            // 
            // gcChucNang
            // 
            this.gcChucNang.ContextMenuStrip = this.contextMenuStrip1;
            this.gcChucNang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcChucNang.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gcChucNang.Location = new System.Drawing.Point(0, 0);
            this.gcChucNang.MainView = this.gvChucNang;
            this.gcChucNang.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gcChucNang.Name = "gcChucNang";
            this.gcChucNang.Size = new System.Drawing.Size(676, 716);
            this.gcChucNang.TabIndex = 0;
            this.gcChucNang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvChucNang});
            this.gcChucNang.Click += new System.EventHandler(this.gcChucNang_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnCamQuyen,
            this.toolStripSeparator1,
            this.mnChiXem,
            this.toolStripSeparator2,
            this.mnToanQuyen});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(209, 100);
            // 
            // mnCamQuyen
            // 
            this.mnCamQuyen.Image = global::USERMANAGEMENT.Properties.Resources.Cancel_16x16;
            this.mnCamQuyen.Name = "mnCamQuyen";
            this.mnCamQuyen.Size = new System.Drawing.Size(208, 28);
            this.mnCamQuyen.Text = "lock permissions";
            this.mnCamQuyen.Click += new System.EventHandler(this.mnCamQuyen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(205, 6);
            // 
            // mnChiXem
            // 
            this.mnChiXem.Image = global::USERMANAGEMENT.Properties.Resources.FindCustomers_16x16;
            this.mnChiXem.Name = "mnChiXem";
            this.mnChiXem.Size = new System.Drawing.Size(208, 28);
            this.mnChiXem.Text = "only view";
            this.mnChiXem.Click += new System.EventHandler(this.mnChiXem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(205, 6);
            // 
            // mnToanQuyen
            // 
            this.mnToanQuyen.Image = global::USERMANAGEMENT.Properties.Resources.Apply_16x16;
            this.mnToanQuyen.Name = "mnToanQuyen";
            this.mnToanQuyen.Size = new System.Drawing.Size(208, 28);
            this.mnToanQuyen.Text = "full permission";
            this.mnToanQuyen.Click += new System.EventHandler(this.mnToanQuyen_Click);
            // 
            // gvChucNang
            // 
            this.gvChucNang.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvChucNang.Appearance.Row.Options.UseFont = true;
            this.gvChucNang.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.FUNC_CODE,
            this.DESCRIPTION,
            this.QUYEN,
            this.cISGROUP});
            this.gvChucNang.DetailHeight = 436;
            this.gvChucNang.GridControl = this.gcChucNang;
            this.gvChucNang.Name = "gvChucNang";
            this.gvChucNang.OptionsEditForm.PopupEditFormWidth = 1000;
            this.gvChucNang.OptionsSelection.MultiSelect = true;
            this.gvChucNang.OptionsView.ShowGroupPanel = false;
            this.gvChucNang.RowHeight = 35;
            // 
            // FUNC_CODE
            // 
            this.FUNC_CODE.Caption = "FUNC_CODE";
            this.FUNC_CODE.FieldName = "FUNC_CODE";
            this.FUNC_CODE.MinWidth = 31;
            this.FUNC_CODE.Name = "FUNC_CODE";
            this.FUNC_CODE.Width = 117;
            // 
            // DESCRIPTION
            // 
            this.DESCRIPTION.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.DESCRIPTION.AppearanceHeader.Options.UseFont = true;
            this.DESCRIPTION.Caption = "FUNCTION";
            this.DESCRIPTION.FieldName = "DESCRIPTION";
            this.DESCRIPTION.MaxWidth = 312;
            this.DESCRIPTION.MinWidth = 250;
            this.DESCRIPTION.Name = "DESCRIPTION";
            this.DESCRIPTION.Visible = true;
            this.DESCRIPTION.VisibleIndex = 0;
            this.DESCRIPTION.Width = 250;
            // 
            // QUYEN
            // 
            this.QUYEN.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.QUYEN.AppearanceHeader.Options.UseFont = true;
            this.QUYEN.Caption = "PERMISSIONS";
            this.QUYEN.FieldName = "QUYEN";
            this.QUYEN.MaxWidth = 187;
            this.QUYEN.MinWidth = 125;
            this.QUYEN.Name = "QUYEN";
            this.QUYEN.Visible = true;
            this.QUYEN.VisibleIndex = 1;
            this.QUYEN.Width = 125;
            // 
            // cISGROUP
            // 
            this.cISGROUP.Caption = "GROUP";
            this.cISGROUP.FieldName = "ISGROUP";
            this.cISGROUP.MinWidth = 31;
            this.cISGROUP.Name = "cISGROUP";
            this.cISGROUP.Width = 117;
            // 
            // frmPhanQuyenChucNang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 716);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmPhanQuyenChucNang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Function Permissions";
            this.Load += new System.EventHandler(this.frmPhanQuyenChucNang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcChucNang)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvChucNang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gcUsers;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUsers;
        private DevExpress.XtraGrid.Columns.GridColumn ISGROUP;
        private DevExpress.XtraGrid.Columns.GridColumn USERNAME;
        private DevExpress.XtraGrid.Columns.GridColumn FULLNAME;
        private DevExpress.XtraGrid.Columns.GridColumn IDUSER;
        private DevExpress.XtraGrid.GridControl gcChucNang;
        private DevExpress.XtraGrid.Views.Grid.GridView gvChucNang;
        private DevExpress.XtraGrid.Columns.GridColumn FUNC_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn DESCRIPTION;
        private DevExpress.XtraGrid.Columns.GridColumn QUYEN;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnCamQuyen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnChiXem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnToanQuyen;
        private DevExpress.XtraGrid.Columns.GridColumn cISGROUP;
    }
}