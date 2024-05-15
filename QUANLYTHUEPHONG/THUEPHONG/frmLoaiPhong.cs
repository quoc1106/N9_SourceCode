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
    public partial class frmLoaiPhong : DevExpress.XtraEditors.XtraForm
    {
        public frmLoaiPhong()
        {
            InitializeComponent();
        }
        public frmLoaiPhong(tb_SYS_USER user, int right)
        {
            InitializeComponent();
            this._user = user;
            this._right = right;
        }
        tb_SYS_USER _user;
        int _right;
        LOAIPHONG _loaiphong;
        bool _them;
        int _id;
        private void frmLoaiPhong_Load(object sender, EventArgs e)
        {
            _loaiphong = new LOAIPHONG();
            loadData();
            showHideControl(true);
            _enabled(false);
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
                _loaiphong.delete(_id);
            }
            loadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                tb_LoaiPhong lp = new tb_LoaiPhong();
                lp.TENLOAIPHONG = txtTen.Text;
                lp.DONGIA = double.Parse( spDonGia.EditValue.ToString());
                lp.SOGIUONG = int.Parse(spSoGiuong.EditValue.ToString());
                lp.SONGUOITOIDA = int.Parse(spSoNguoi.EditValue.ToString());
                lp.DISABLED = chkDisabled.Checked;
                _loaiphong.add(lp);
            }
            else
            {
                tb_LoaiPhong lp = _loaiphong.getItem(_id);
                lp.TENLOAIPHONG = txtTen.Text;
                lp.DONGIA = double.Parse(spDonGia.EditValue.ToString());
                lp.SOGIUONG = int.Parse(spSoGiuong.EditValue.ToString());
                lp.SONGUOITOIDA = int.Parse(spSoNguoi.EditValue.ToString());
                lp.DISABLED = chkDisabled.Checked;
                _loaiphong.update(lp);
            }
            _them = false;
            loadData();
            _enabled(false);
            showHideControl(true);
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
            spDonGia.Enabled = t;
            spSoGiuong.Enabled = t;
            spSoNguoi.Enabled = t;
            chkDisabled.Enabled = t;
        }
        void _reset()
        {
            txtTen.Text = "";
            spSoNguoi.EditValue = 0;
            spSoGiuong.EditValue = 0;
            spDonGia.EditValue = 0;
            chkDisabled.Checked = false;
        }
        void loadData()
        {
            gcDanhSach.DataSource = _loaiphong.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
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
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("IDLOAIPHONG").ToString());
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENLOAIPHONG").ToString();
                spDonGia.Text = gvDanhSach.GetFocusedRowCellValue("DONGIA").ToString();
                spSoGiuong.Text = gvDanhSach.GetFocusedRowCellValue("SOGIUONG").ToString();
                spSoNguoi.Text = gvDanhSach.GetFocusedRowCellValue("SONGUOITOIDA").ToString();
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

        private void gcDanhSach_Click(object sender, EventArgs e)
        {

        }
    }
}