using KatarinaZvkovic.Net13.Intrfaces;
using KatarinaZvkovic.Net13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KatarinaZvkovic.Net13.Repository
{
    public class AutobusRepository : IDisposable, IAutobusRepository
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Autobus> GetAll()
        {
            return db.Autobusi.OrderBy(x => x.OznakaLinije);
        }

        public IEnumerable<Autobus> GetAllByOznaka(string oznaka)
        {
            return db.Autobusi.OrderBy(x => x.GodinaProizvodnje);
        }

        public IEnumerable<Autobus> GetAllSorted()
        {
            return db.Autobusi.OrderBy(x => x.GodinaProizvodnje).ThenBy(x => x.OznakaLinije);
        }

        public Autobus GetId(int id)
        {
            return db.Autobusi.FirstOrDefault(x => x.Id == id);
        }
    }
}
