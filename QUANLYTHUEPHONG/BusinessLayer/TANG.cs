using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class TANG
    {
        Entities db;
        public TANG()
        {
            db = Entities.CreateEntities();
        }
        public tb_Tang getItem(int id)
        {
            return db.tb_Tang.FirstOrDefault(x=>x.IDTANG==id);
        }
        public List<tb_Tang>getAll()
        {
            return db.tb_Tang.ToList();
        }
        public List<tb_Tang> getList()
        {
            return db.tb_Tang.Where(x => x.DISABLED == false).ToList();
        }        
        public void add(tb_Tang _tang)
        {
            tb_Tang t = new tb_Tang();
            t.TENTANG = _tang.TENTANG;
            t.DISABLED = _tang.DISABLED;
            db.tb_Tang.Add(t);
            db.SaveChanges();
        }
        public void update(tb_Tang _tang)
        {
            tb_Tang t = db.tb_Tang.FirstOrDefault(x => x.IDTANG == _tang.IDTANG);
            t.TENTANG = _tang.TENTANG;
            t.DISABLED = _tang.DISABLED;
            db.SaveChanges();
        }
        public void delete(int id)
        {
            tb_Tang t = db.tb_Tang.FirstOrDefault(x => x.IDTANG == id);
            t.DISABLED = true;
            db.SaveChanges();
        }
    }
}
