using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class LOAIPHONG
    {
        Entities db;
        public LOAIPHONG()
        {
            db = Entities.CreateEntities();
        }
        public tb_LoaiPhong getItem(int id)
        {
            return db.tb_LoaiPhong.FirstOrDefault(x => x.IDLOAIPHONG == id);
        }
        public List<tb_LoaiPhong> getAll()
        {
            return db.tb_LoaiPhong.ToList();
        }
        public void add(tb_LoaiPhong lp)
        {
            try
            {
                db.tb_LoaiPhong.Add(lp);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred during the data processing." + ex.Message);
            }
        }
        public void update(tb_LoaiPhong lp)
        {
            tb_LoaiPhong _lp = db.tb_LoaiPhong.FirstOrDefault(x => x.IDLOAIPHONG == lp.IDLOAIPHONG);
            _lp.TENLOAIPHONG = lp.TENLOAIPHONG;
            _lp.SOGIUONG = lp.SOGIUONG;
            _lp.SONGUOITOIDA = lp.SONGUOITOIDA;
            _lp.DONGIA = lp.DONGIA;
            _lp.DISABLED = lp.DISABLED;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred during the data processing." + ex.Message);
            }
        }
        public void delete(int id)
        {
            tb_LoaiPhong _lp = db.tb_LoaiPhong.FirstOrDefault(x => x.IDLOAIPHONG == id);
            _lp.DISABLED = true;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred during the data processing." + ex.Message);
            }
        }
    }
}
