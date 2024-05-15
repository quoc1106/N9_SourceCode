using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class KHACHHANG
    {
        Entities db;
        public KHACHHANG()
        {
            db = Entities.CreateEntities();
        }
        public tb_KhachHang getItem(int idkh)
        {
            return db.tb_KhachHang.FirstOrDefault(x => x.IDKH == idkh);
        }
        public List<tb_KhachHang> getAll()
        {
            return db.tb_KhachHang.ToList();
        }
        public void add(tb_KhachHang kh)
        {
            try
            {
                db.tb_KhachHang.Add(kh);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred during the data processing. " + ex.Message);
            }
        }

        public void update(tb_KhachHang kh)
        {
            tb_KhachHang _kh = db.tb_KhachHang.FirstOrDefault(x => x.IDKH == kh.IDKH);
            _kh.HOTEN = kh.HOTEN;
            _kh.CCCD = kh.CCCD;
            _kh.DIACHI = kh.DIACHI;
            _kh.DIENTHOAI = kh.DIENTHOAI;
            _kh.EMAIL = kh.EMAIL;
            _kh.GIOITINH = kh.GIOITINH;
            _kh.DISABLED = kh.DISABLED;
            _kh.CREATED_DATE = kh.CREATED_DATE;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred during the data processing." + ex.Message);
            }
        }
        public void delete(int idkh)
        {
            tb_KhachHang _kh = db.tb_KhachHang.FirstOrDefault(x => x.IDKH == idkh);
            if (_kh != null)
            {
                try
                {
                    db.tb_KhachHang.Remove(_kh);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred during the data processing. " + ex.Message);
                }
            }
            else
            {
                throw new Exception("Customer with ID not found:  " + idkh);
            }
        }

    }
}
