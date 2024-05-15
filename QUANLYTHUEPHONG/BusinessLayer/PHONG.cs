using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class PHONG
    {
        Entities db;
        public PHONG()
        {
            db = Entities.CreateEntities();
        }
        public tb_Phong getItem(int id)
        {
            return db.tb_Phong.FirstOrDefault(x=>x.IDPHONG==id);
        }
        public List<tb_Phong> getAll()
        {
            return db.tb_Phong.ToList();
        }
        public List<tb_Phong>getByTang(int idTang)
        {
            return db.tb_Phong.Where(x => x.IDTANG == idTang).ToList();
        }       
        public List<tb_Phong> getList()
        {
            return db.tb_Phong.ToList();
        }
        public OBJ_PHONG getItemFull(int id)
        {
            var _p = db.tb_Phong.FirstOrDefault(x => x.IDPHONG == id);
            OBJ_PHONG phong = new OBJ_PHONG();
            phong.IDPHONG = _p.IDPHONG;
            phong.TENPHONG = _p.TENPHONG;
            phong.STATUS = bool.Parse(_p.STATUS.ToString());
            phong.DISABLED = bool.Parse(_p.DISABLED.ToString());
            phong.IDLOAIPHONG = _p.IDLOAIPHONG;
            phong.IDTANG = _p.IDTANG;
            var tang = db.tb_Tang.FirstOrDefault(t => t.IDTANG == _p.IDTANG);
            phong.TENTANG = tang.TENTANG;
            var lp = db.tb_LoaiPhong.FirstOrDefault(l => l.IDLOAIPHONG == _p.IDLOAIPHONG);
            phong.TENLOAIPHONG = lp.TENLOAIPHONG;
            phong.DONGIA = double.Parse(lp.DONGIA.ToString());
            return phong;

        }
        public List<OBJ_PHONG> getListFull()
        {
            var lsPhong = db.tb_Phong.ToList();
            List<OBJ_PHONG> lsPhongOBJ = new List<OBJ_PHONG>();
            OBJ_PHONG phong;
            foreach (var _p in lsPhong)
            {
                phong = new OBJ_PHONG();
                phong.IDPHONG = _p.IDPHONG;
                phong.TENPHONG = _p.TENPHONG;
                phong.STATUS = bool.Parse(_p.STATUS.ToString());
                phong.DISABLED = bool.Parse(_p.DISABLED.ToString());
                phong.IDLOAIPHONG = _p.IDLOAIPHONG;
                phong.IDTANG = _p.IDTANG;
                var tang = db.tb_Tang.FirstOrDefault(t => t.IDTANG == _p.IDTANG);
                phong.TENTANG = tang.TENTANG;
                var lp = db.tb_LoaiPhong.FirstOrDefault(l => l.IDLOAIPHONG == _p.IDLOAIPHONG);
                phong.TENLOAIPHONG = lp.TENLOAIPHONG;
                phong.DONGIA = double.Parse(lp.DONGIA.ToString());

                lsPhongOBJ.Add(phong);
            }

            return lsPhongOBJ;

        }
        public List<OBJ_PHONG> getPhongTrongFull()
        {
            var lsPhong = db.tb_Phong.Where(x => x.STATUS == false).ToList();
            List<OBJ_PHONG> lsPhongOBJ = new List<OBJ_PHONG>();
            OBJ_PHONG phong;
            foreach (var _p in lsPhong)
            {
                phong = new OBJ_PHONG();
                phong.IDPHONG = _p.IDPHONG;
                phong.TENPHONG = _p.TENPHONG;
                phong.STATUS = bool.Parse(_p.STATUS.ToString());
                phong.DISABLED = bool.Parse(_p.DISABLED.ToString());
                phong.IDLOAIPHONG = _p.IDLOAIPHONG;
                phong.IDTANG = _p.IDTANG;
                var tang = db.tb_Tang.FirstOrDefault(t => t.IDTANG == _p.IDTANG);
                phong.TENTANG = tang.TENTANG;
                var lp = db.tb_LoaiPhong.FirstOrDefault(l => l.IDLOAIPHONG == _p.IDLOAIPHONG);
                phong.TENLOAIPHONG = lp.TENLOAIPHONG;
                phong.DONGIA = double.Parse(lp.DONGIA.ToString());

                lsPhongOBJ.Add(phong);
            }

            return lsPhongOBJ;

        }
        public List<tb_Phong> getListByTang(int _idTang)
        {
            return db.tb_Phong.Where(t => t.IDTANG == _idTang).ToList();
        }
        public List<tb_Phong> getPhongTrong(int idTang)
        {
            return db.tb_Phong.Where(x => x.STATUS == false && x.DISABLED == false && x.IDTANG == idTang).ToList();
        }
        public void add(tb_Phong _phong)
        {
            tb_Phong p = new tb_Phong();
            p.STATUS = _phong.STATUS;
            p.IDLOAIPHONG = _phong.IDLOAIPHONG;
            p.IDTANG = _phong.IDTANG;
            p.TENPHONG = _phong.TENPHONG;
            p.DISABLED = _phong.DISABLED;
            db.tb_Phong.Add(p);
            db.SaveChanges();

        }
        public void update(tb_Phong _phong)
        {
            tb_Phong p = db.tb_Phong.FirstOrDefault(x => x.IDPHONG == _phong.IDPHONG);
            p.STATUS = _phong.STATUS;
            p.IDLOAIPHONG = _phong.IDLOAIPHONG;
            p.IDTANG = _phong.IDTANG;
            p.TENPHONG = _phong.TENPHONG;
            p.DISABLED = _phong.DISABLED;
            db.SaveChanges();

        }
        public void updateStatus(int id, bool status)
        {
            tb_Phong p = db.tb_Phong.FirstOrDefault(x => x.IDPHONG == id);
            p.STATUS = status;
            db.SaveChanges();

        }
        public void delete(int id)
        {
            tb_Phong p = db.tb_Phong.FirstOrDefault(x => x.IDPHONG == id);
            p.DISABLED = true;
            db.SaveChanges();

        }
        public bool checkEmpty(int idPhong)
        {
            var p = db.tb_Phong.FirstOrDefault(x=>x.IDPHONG==idPhong);
            if (p.STATUS == true)
                return true;
            else
                return false;
        }
    }
}
