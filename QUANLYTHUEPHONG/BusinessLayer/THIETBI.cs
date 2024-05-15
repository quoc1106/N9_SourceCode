using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class THIETBI
    {
        Entities db;
        public THIETBI()
        {
            db = Entities.CreateEntities();
        }
        public tb_ThietBi getItem(int id)
        {
            return db.tb_ThietBi.FirstOrDefault(x => x.IDTB == id);
        }
        public List<tb_ThietBi> getAll()
        {
            return db.tb_ThietBi.ToList();
        }
        public void add(tb_ThietBi tb)
        {
            try
            {
                db.tb_ThietBi.Add(tb);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred during the data processing." + ex.Message);
            }
        }
        public void update(tb_ThietBi tb)
        {
            tb_ThietBi _tb = db.tb_ThietBi.FirstOrDefault(x => x.IDTB == tb.IDTB);
            _tb.TENTHIETBI = tb.TENTHIETBI;
            _tb.DONGIA = tb.DONGIA;
            _tb.DISABLED = tb.DISABLED;
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
            tb_ThietBi _tb = db.tb_ThietBi.FirstOrDefault(x => x.IDTB == id);
            _tb.DISABLED = true;
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
