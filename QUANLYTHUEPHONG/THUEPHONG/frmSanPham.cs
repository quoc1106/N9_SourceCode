using BusinessLayer;
using DataLayer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace THUEPHONG
{
    public partial class frmSanPham : DevExpress.XtraEditors.XtraForm
    {
        public frmSanPham()
        {
            InitializeComponent();
        }
        public frmSanPham( tb_SYS_USER user, int right)
        {
            InitializeComponent();
            this._user = user;
            this._right = right;
        }
        tb_SYS_USER _user;
        int _right;
        SANPHAM _sanpham;
        bool _them;
        int _id;
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            _sanpham = new SANPHAM();
            loadData();
            showHideControl(true);
            _enabled(false);
        }

        private void showHideControl(bool t)
        {
            btnThem.Visible = t;
            btnSua.Visible = t;
            btnXoa.Visible = t;
            btnThoat.Visible = t;
            btnLuu.Visible = !t;
            btnBoQua.Visible = !t;
        }

        private void _enabled(bool t)
        {
            txtTen.Enabled = t;
            spDonGia.Enabled = t;
            chkDisabled.Enabled = t;
        }

        private void _reset()
        {
            txtTen.Text = "";
            spDonGia.EditValue = 0;
            chkDisabled.Checked = false;
        }

        private void loadData()
        {
            gcDanhSach.DataSource = _sanpham.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (_right == 1)
            {
                MessageBox.Show("No permission to operate.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("No permission to operate.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("No permission to operate.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _sanpham.delete(_id);
            }
            loadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                tb_SanPham sp = new tb_SanPham();
                sp.TENSP = txtTen.Text;
                sp.DONGIA = double.Parse(spDonGia.EditValue.ToString());
                sp.DISABLED = chkDisabled.Checked;
                _sanpham.add(sp);
            }
            else
            {
                tb_SanPham sp = _sanpham.getItem(_id);
                sp.TENSP = txtTen.Text;
                sp.DONGIA = double.Parse(spDonGia.EditValue.ToString());
                sp.DISABLED = chkDisabled.Checked;
                _sanpham.update(sp);
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
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("IDSP").ToString());
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENSP").ToString();
                spDonGia.Text = gvDanhSach.GetFocusedRowCellValue("DONGIA").ToString();
                chkDisabled.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("DISABLED").ToString());
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