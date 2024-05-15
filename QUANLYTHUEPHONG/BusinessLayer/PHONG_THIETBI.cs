using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class PHONG_THIETBI
    {
        Entities db;
        public PHONG_THIETBI()
        {
            db = Entities.CreateEntities();
        }
        public tb_Phong_ThietBi getItem(int idphong, int idTB)
        {
            return db.tb_Phong_ThietBi.FirstOrDefault(x=>x.IDPHONG==idphong && x.IDTB==idTB);
        }
        public List<OBJ_PHONGTHIETBI> getList(int idPhong)
        {
            List<tb_Phong_ThietBi> lstPTB = db.tb_Phong_ThietBi.Where(x => x.IDPHONG == idPhong).ToList();
            List<OBJ_PHONGTHIETBI> lstPhongTB = new List<OBJ_PHONGTHIETBI>();
            OBJ_PHONGTHIETBI _ptb;
            foreach (var item in lstPTB)
            {
                _ptb = new OBJ_PHONGTHIETBI();
                _ptb.IDPHONG = item.IDPHONG;
                _ptb.IDTB = item.IDTB;
                _ptb.SOLUONG = item.SOLUONG;
                tb_Phong _p = db.tb_Phong.FirstOrDefault(x => x.IDPHONG == item.IDPHONG);
                if (_p != null)
                {
                    _ptb.TENPHONG = _p.TENPHONG;
                }
                tb_ThietBi _t = db.tb_ThietBi.FirstOrDefault(x => x.IDTB == item.IDTB);
                if (_t != null)
                {
                    _ptb.TENTHIETBI = _t.TENTHIETBI;
                }
                lstPhongTB.Add(_ptb);
            }
            return lstPhongTB;
        }
        public List<OBJ_PHONGTHIETBI> getAll()
        {
            //List<tb_Phong> lstPhong = db.tb_Phong.ToList();
            //List<tb_ThietBi> lstTB = db.tb_ThietBi.ToList();
            List<tb_Phong_ThietBi> lstPTB = db.tb_Phong_ThietBi.ToList();
            List<OBJ_PHONGTHIETBI> lstPhongTB = new List<OBJ_PHONGTHIETBI>();
            OBJ_PHONGTHIETBI _ptb;
            foreach (var item in lstPTB)
            {
                _ptb = new OBJ_PHONGTHIETBI();
                _ptb.IDPHONG = item.IDPHONG;
                _ptb.IDTB = item.IDTB;
                _ptb.SOLUONG = item.SOLUONG;
                tb_Phong _p = db.tb_Phong.FirstOrDefault(x => x.IDPHONG == item.IDPHONG);
                if (_p != null)
                {
                    _ptb.TENPHONG = _p.TENPHONG;
                }
                tb_ThietBi _t = db.tb_ThietBi.FirstOrDefault(x => x.IDTB == item.IDTB);
                if (_t != null)
                {
                    _ptb.TENTHIETBI = _t.TENTHIETBI;
                }
                lstPhongTB.Add(_ptb);
            }
            return lstPhongTB;
        }
        public void add(tb_Phong_ThietBi ptb)
        {
            try
            {
                db.tb_Phong_ThietBi.Add(ptb);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred during the data processing." + ex.Message); ;
            }
        }
        public void update(tb_Phong_ThietBi ptb)
        {
            tb_Phong_ThietBi tb= db.tb_Phong_ThietBi.FirstOrDefault(x => x.IDPHONG == ptb.IDPHONG && x.IDTB == ptb.IDTB);
            tb.IDTB = ptb.IDTB;
            tb.SOLUONG = ptb.SOLUONG;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred during the data processing." + ex.Message); ;
            }
        }
        public void delete(int idTB, int idPhong)
        {
            tb_Phong_ThietBi tb = db.tb_Phong_ThietBi.FirstOrDefault(x => x.IDPHONG == idPhong && x.IDTB == idTB);
            try
            {
                db.tb_Phong_ThietBi.Remove(tb);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred during the data processing." + ex.Message); ;
            }
        }
    }
}
