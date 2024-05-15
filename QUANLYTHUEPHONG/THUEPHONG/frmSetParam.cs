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
using BusinessLayer;

namespace THUEPHONG
{
    public partial class frmSetParam : DevExpress.XtraEditors.XtraForm
    {
        public frmSetParam()
        {
            InitializeComponent();
        }
        CONGTY _congty;
        DONVI _donvi;
        private void frmSetParam_Load(object sender, EventArgs e)
        {
            _congty = new CONGTY();
            _donvi = new DONVI();
            loadCongty();
            cboCongTy.SelectedValue = "CT01";
            cboCongTy.SelectedIndexChanged += CboCongTy_SelectedIndexChanged;
            loadDonVi();
        }

        private void CboCongTy_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDonVi();
        }

        void loadCongty()
        {
            cboCongTy.DataSource = _congty.getAll();
            cboCongTy.DisplayMember = "TENCTY";
            cboCongTy.ValueMember = "MACTY";
        }
        void loadDonVi()
        {
            cboDonVi.DataSource = _donvi.getAll(cboCongTy.SelectedValue.ToString());
            cboDonVi.DisplayMember = "TENDVI";
            cboDonVi.ValueMember = "MADVI";
            cboDonVi.SelectedIndex = -1;
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string macty = cboCongTy.SelectedValue.ToString();
            string madvi = (cboDonVi.Text.Trim() == "") ? "~" : cboDonVi.SelectedValue.ToString();
            SYS_PARAM _sysParam = new SYS_PARAM(macty, madvi);
            _sysParam.SaveFile();
            MessageBox.Show("Establishing the unit of use successfully.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}