using BusinessLayer;
using DataLayer;
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

namespace THUEPHONG
{
    public partial class frmKhachHang : DevExpress.XtraEditors.XtraForm
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        public frmKhachHang(tb_SYS_USER user, int right)
        {
            InitializeComponent();
            this._user = user;
            this._right = right;
        }
        tb_SYS_USER _user;
        int _right;
        frmDatPhong objDP = (frmDatPhong) Application.OpenForms["frmDatPhong"];
        frmDatPhongDon objDPDon = (frmDatPhongDon)Application.OpenForms["frmDatPhongDon"];
        KHACHHANG _khachhang;
        bool _them;
        int _makh;
        public string kh_dp;
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            _khachhang = new KHACHHANG();
            loadData();
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
            txtDienThoai.Enabled = t;
            chkGioiTinh.Enabled = t;
            txtEmail.Enabled = t;
            txtDiaChi.Enabled = t;
            chkDisabled.Enabled = t;
            txtCCCD.Enabled = t;
        }
        void _reset()
        {
            txtTen.Text = "";
            txtDienThoai.Text = "";
            chkGioiTinh.Checked =false;
            txtEmail.Text = "";
            txtCCCD.Text = "";
            txtDiaChi.Text = "";
            chkDisabled.Checked = false;
        }
        void loadData()
        {
            gcDanhSach.DataSource = _khachhang.getAll();
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
                _khachhang.delete(_makh);
            }
            loadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                tb_KhachHang kh = new tb_KhachHang();
                kh.CCCD = txtCCCD.Text;
                kh.HOTEN = txtTen.Text;
                kh.DIACHI = txtDiaChi.Text;
                kh.DIENTHOAI = txtDienThoai.Text;
                kh.GIOITINH = chkGioiTinh.Checked;
                kh.EMAIL = txtEmail.Text;
                kh.DISABLED = chkDisabled.Checked;
                _khachhang.add(kh);
            }
            else
            {
                tb_KhachHang kh = _khachhang.getItem(_makh);
                kh.CCCD = txtCCCD.Text;
                kh.HOTEN = txtTen.Text;
                kh.DIACHI = txtDiaChi.Text;
                kh.DIENTHOAI = txtDienThoai.Text;
                kh.GIOITINH = chkGioiTinh.Checked;
                kh.EMAIL = txtEmail.Text;
                kh.DISABLED = chkDisabled.Checked;
                _khachhang.update(kh);
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
                _makh = int.Parse(gvDanhSach.GetFocusedRowCellValue("IDKH").ToString());
                chkGioiTinh.Checked = bool.Parse( gvDanhSach.GetFocusedRowCellValue("GIOITINH").ToString());
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("HOTEN").ToString();
                txtDienThoai.Text = gvDanhSach.GetFocusedRowCellValue("DIENTHOAI").ToString();
                txtCCCD.Text = gvDanhSach.GetFocusedRowCellValue("CCCD").ToString();
                txtEmail.Text = gvDanhSach.GetFocusedRowCellValue("EMAIL").ToString();
                txtDiaChi.Text = gvDanhSach.GetFocusedRowCellValue("DIACHI").ToString();
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

        private void gvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            if (gvDanhSach.GetFocusedRowCellValue("IDKH")!=null)
            {
                if (kh_dp== "datphongdon")
                {
                    objDPDon.loadKH();
                    objDPDon.setKH(int.Parse(gvDanhSach.GetFocusedRowCellValue("IDKH").ToString()));
                }
                else
                {
                    
                    objDP.loadKH();
                    objDP.setKhachHang(int.Parse(gvDanhSach.GetFocusedRowCellValue("IDKH").ToString()));
                }    
                
                this.Close();
            }
        }
    }
}