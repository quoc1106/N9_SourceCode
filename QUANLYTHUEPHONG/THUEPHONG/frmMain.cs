using BusinessLayer;
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
using DevExpress.XtraNavBar;
using DevExpress.Utils.Drawing;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.ViewInfo;

namespace THUEPHONG
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(tb_SYS_USER user)
        {
            InitializeComponent();
            this._user = user;
            this.Text = "HOTEL MANAGEMENT SYSTEM SOFTWARE - " + _user.FULLNAME;
        }
        tb_SYS_USER _user;
        TANG _tang;
        PHONG _phong;
        SYS_FUNC _func;
        SYS_GROUP _sysGroup;
        SYS_RIGHT _sysRight;
        GalleryItem item = null;
        private void frmMain_Load(object sender, EventArgs e)
        {
            _tang = new TANG();
            _phong = new PHONG();
            _func = new SYS_FUNC();
            _sysGroup = new SYS_GROUP();
            _sysRight = new SYS_RIGHT();
            leftMenu();
            showRoom();
        }    
        void leftMenu()
        {
            int i = 0;
            var _lsParent = _func.getParent();
            foreach (var _pr in _lsParent)
            {
                NavBarGroup navGroup = new NavBarGroup(_pr.DESCRIPTION);
                navGroup.Tag = _pr.FUNC_CODE;
                navGroup.Name = _pr.FUNC_CODE;
                navGroup.ImageOptions.LargeImageIndex = i;
                i++;
                navMain.Groups.Add(navGroup);

                var _lsChild = _func.getChild(_pr.FUNC_CODE);
                foreach (var _ch in _lsChild)
                {
                    NavBarItem navItem = new NavBarItem(_ch.DESCRIPTION);
                    navItem.Tag = _ch.FUNC_CODE;
                    navItem.Name = _ch.FUNC_CODE;
                    navItem.ImageOptions.SmallImageIndex = 0;
                    navGroup.ItemLinks.Add(navItem);
                }
                navMain.Groups[navGroup.Name].Expanded = true;
            }
            
        }
       public void showRoom()
        {
            _tang = new TANG();
            _phong = new PHONG();
            var lsTang = _tang.getList();
            gControl.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
            gControl.Gallery.ImageSize = new Size(64,64);
            gControl.Gallery.ShowItemText = true;
            gControl.Gallery.ShowGroupCaption = true;
            foreach (var t in lsTang)
            {
                var galleryItem = new GalleryItemGroup();
                galleryItem.Caption = t.TENTANG;
                galleryItem.CaptionAlignment = GalleryItemGroupCaptionAlignment.Stretch;
                List<tb_Phong> lsPhong = _phong.getByTang(t.IDTANG);
                foreach (var p in lsPhong)
                {
                    var gc_item = new GalleryItem();
                    gc_item.Caption = p.TENPHONG;
                    gc_item.Value = p.IDPHONG;
                    if (p.STATUS==true)
                        gc_item.ImageOptions.Image = imageList3.Images[1];
                    else
                        gc_item.ImageOptions.Image = imageList3.Images[0];

                    galleryItem.Items.Add(gc_item);
                }
                gControl.Gallery.Groups.Add(galleryItem);
            }
            

        }
        private void navMain_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            string func_code = e.Link.Item.Tag.ToString();

            var _group = _sysGroup.getGroupByMemBer(_user.IDUSER);
            var _uRight = _sysRight.getRight(_user.IDUSER, func_code);

            if (_group!=null)
            {
                var _groupRight = _sysRight.getRight(_group.GROUP,func_code);
                if (_uRight.USER_RIGHT < _groupRight.USER_RIGHT)
                    _uRight.USER_RIGHT = _groupRight.USER_RIGHT;
            }

            if (_uRight.USER_RIGHT==0)
            {
                MessageBox.Show("No operation rights.", "Notification.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                switch (func_code)
                {
                    case "CONGTY":
                        {
                            frmCongTy frm = new frmCongTy(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                    case "DONVI":
                        {
                            frmDonVi frm = new frmDonVi(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                    case "TANG":
                        {
                            frmTang frm = new frmTang(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                    case "SANPHAM":
                        {
                            frmSanPham frm = new frmSanPham(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                    case "LOAIPHONG":
                        {
                            frmLoaiPhong frm = new frmLoaiPhong(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                    case "PHONG":
                        {
                            frmPhong frm = new frmPhong(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                    case "KHACHHANG":
                        {
                            frmKhachHang frm = new frmKhachHang(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                    case "THIETBI":
                        {
                            frmThietBi frm = new frmThietBi(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                    case "PHONG_TB":
                        {
                            frm_Phong_ThietBi frm = new frm_Phong_ThietBi(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                    case "DATPHONG":
                        {
                            frmDatPhong frm = new frmDatPhong(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                }
            }    
            
        }

        private void btnHeThong_Click(object sender, EventArgs e)
        {

        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            frmBaoCao frm = new frmBaoCao(_user);
            frm.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void popupMenu1_Popup(object sender, EventArgs e)
        {
            Point point = gControl.PointToClient(Control.MousePosition);
            RibbonHitInfo hitInfo = gControl.CalcHitInfo(point);
            if (hitInfo.InGalleryItem || hitInfo.HitTest == RibbonHitTest.GalleryImage)
                item = hitInfo.GalleryItem;
            
        }

        private void btnDatPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_phong.checkEmpty(int.Parse(item.Value.ToString())))
            {
                MessageBox.Show("Room has been booked. Please choose another room.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmDatPhongDon frm = new frmDatPhongDon();
            frm._idPhong = int.Parse(item.Value.ToString());
            frm._them = true;
            frm.ShowDialog();
        }

        private void btnChuyenPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!_phong.checkEmpty(int.Parse(item.Value.ToString())))
            {
                MessageBox.Show("Rooms have not been booked, so transfers are not allowed. Please select the room that has been booked.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmChuyenPhong frm = new frmChuyenPhong();
            frm._idPhong = int.Parse(item.Value.ToString());
            frm.ShowDialog();
        }

        private void btnSPDV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!_phong.checkEmpty(int.Parse(item.Value.ToString())))
            {
                MessageBox.Show("The room has not been booked yet, so products and services cannot be updated. Please select the room that has been booked.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmDatPhongDon frm = new frmDatPhongDon();
            frm._idPhong = int.Parse(item.Value.ToString());
            frm._them = false;
            frm.ShowDialog();
        }

        private void btnThanhToan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!_phong.checkEmpty(int.Parse(item.Value.ToString())))
            {
                MessageBox.Show("The room has not been booked so payment cannot be made. Please select the room that has been booked.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmDatPhongDon frm = new frmDatPhongDon();
            frm._idPhong = int.Parse(item.Value.ToString());
            frm._them = false;
            frm.ShowDialog();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}