using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using BusinessLayer;

namespace THUEPHONG
{
    public partial class frmPhong : DevExpress.XtraEditors.XtraForm
    {
        public frmPhong()
        {
            InitializeComponent();
        }
        public frmPhong(tb_SYS_USER user, int right)
        {
            InitializeComponent();
            this._user = user;
            this._right = right;
        }
        tb_SYS_USER _user;
        int _right;
        PHONG _phong;
        TANG _tang;
        LOAIPHONG _loaiphong;
        bool _them;
        int _id;
        private void frmPhong_Load(object sender, EventArgs e)
        {
            _phong = new PHONG();
            _tang = new TANG();
            _loaiphong = new LOAIPHONG();
            loadData();
            loadTang();
            loadLoaiPhong();
            showHideControl(true);
            _enabled(false);
        }
        void showHideControl(bool t)
        {
            btnThem.Visible = t;
            btnSua.Visible = t;
            btnXoa.Visible = t;
            btnThoat.Visible = t;
            btnLuu.Visible = !t;
            btnBoQua.Visible = !t;
        }
        void _enabled(bool t)
        {
            txtTen.Enabled = t;
            cboLoaiPhong.Enabled = t;
            cboTang.Enabled = t;
            chkDaThue.Enabled = t;
            chkDisabled.Enabled = t;
        }
        void _reset()
        {
            txtTen.Text = "";
            chkDaThue.Checked = false;
            chkDisabled.Checked = false;
        }
        void loadData()
        {
            gcDanhSach.DataSource = _phong.getListFull();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        void loadTang()
        {
            cboTang.DataSource = _tang.getAll();
            cboTang.DisplayMember = "TENTANG";
            cboTang.ValueMember = "IDTANG";
        }
        void loadLoaiPhong()
        {
            cboLoaiPhong.DataSource = _loaiphong.getAll();
            cboLoaiPhong.DisplayMember = "TENLOAIPHONG";
            cboLoaiPhong.ValueMember = "IDLOAIPHONG";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (_right == 1)
            {
                MessageBox.Show("No permission to operate", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _them = true;
            showHideControl(false);
            _enabled(true);
            _reset();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_right == 1)
            {
                MessageBox.Show("No permission to operate", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _them = false;
            _enabled(true);
            showHideControl(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_right == 1)
            {
                MessageBox.Show("No permission to operate", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _phong.delete(_id);
            }
            loadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                tb_Phong p = new tb_Phong();
                p.TENPHONG = txtTen.Text;
                p.STATUS = chkDaThue.Checked;
                p.IDTANG = int.Parse(cboTang.SelectedValue.ToString());
                p.IDLOAIPHONG = int.Parse(cboLoaiPhong.SelectedValue.ToString());
                p.DISABLED = chkDisabled.Checked;
                _phong.add(p);
            }
            else
            {
                tb_Phong p = _phong.getItem(_id);
                p.TENPHONG = txtTen.Text;
                p.STATUS = chkDaThue.Checked;
                p.IDTANG = int.Parse(cboTang.SelectedValue.ToString());
                p.IDLOAIPHONG = int.Parse(cboLoaiPhong.SelectedValue.ToString());
                p.DISABLED = chkDisabled.Checked;
                _phong.update(p);
            }
            _them = false;
            loadData();
            _enabled(false);
            showHideControl(true);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            _enabled(false);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("IDPHONG").ToString());
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENPHONG").ToString();
                cboLoaiPhong.SelectedValue = gvDanhSach.GetFocusedRowCellValue("IDLOAIPHONG");
                cboTang.SelectedValue = gvDanhSach.GetFocusedRowCellValue("IDTANG");
                chkDisabled.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("DISABLED").ToString());
                chkDaThue.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("STATUS").ToString());
            }
        }

        private void gvDanhSach_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Name == "DISABLED" && bool.Parse(e.CellValue.ToString()) == true)
            {
                Image img = Properties.Resources.del_Icon_x16;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
            }
        }
    }
}