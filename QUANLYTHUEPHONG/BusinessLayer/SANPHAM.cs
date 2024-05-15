using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class SANPHAM
    {
        Entities db;
        public SANPHAM()
        {
            db = Entities.CreateEntities();
        }
        public tb_SanPham getItem(int id)
        {
            return db.tb_SanPham.FirstOrDefault(x => x.IDSP == id);
        }
        public List<tb_SanPham> getList()
        {
            return db.tb_SanPham.Where(x => x.DISABLED == false).ToList();
        }
        public List<tb_SanPham> getAll()
        {
            return db.tb_SanPham.ToList();
        }
        public void add(tb_SanPham sp)
        {
            tb_SanPham _sp = new tb_SanPham();
            try
            {
                db.tb_SanPham.Add(sp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while adding the product. \r\n" + ex.Message);
            }
        }
        public void update(tb_SanPham sp)
        {
            tb_SanPham _sp = db.tb_SanPham.FirstOrDefault(x => x.IDSP == sp.IDSP);
            _sp.TENSP = sp.TENSP;
            _sp.DONGIA = sp.DONGIA;
            _sp.DISABLED = sp.DISABLED;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while adding the product. \r\n" + ex.Message);
            }
        }
        public void delete(int masp)
        {
            tb_SanPham _sp = db.tb_SanPham.FirstOrDefault(x => x.IDSP == masp);
            _sp.DISABLED = true;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while adding the product. \r\n" + ex.Message);
            }
        }
    }
}
