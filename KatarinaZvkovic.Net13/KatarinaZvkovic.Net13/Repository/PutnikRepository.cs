using KatarinaZvkovic.Net13.Intrfaces;
using KatarinaZvkovic.Net13.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace KatarinaZvkovic.Net13.Repository
{
    public class PutnikRepository : IDisposable, IPutnikRepository
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
        public void Add(Putnik putnik)
        {
            db.Putnici.Add(putnik);
            db.SaveChanges();
        }

        public void Delete(Putnik putnik)
        {
            db.Putnici.Remove(putnik);
            db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IQueryable<Putnik> GetAll()
        {
            return db.Putnici.OrderBy(x => x.ImePrezime);
        }

        public IQueryable<PutnikSumDTO> GetAllCompSum()
        {
            IQueryable<Putnik> put = GetAll();
            var result = put.GroupBy(
                c => c.Autobus,
                c => c.Id,
                (bus, id) => new PutnikSumDTO()
                {
                    Id = bus.Id,
                    OznakaLinije = bus.OznakaLinije,
                    BrojPuntika = id.Count()

                }).OrderByDescending(x => x.BrojPuntika);
            return result;

        }

        public Putnik GetId(int id)
        {
            return db.Putnici.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Putnik> SearchByAdress(string adresa)
        {
            return db.Putnici.OrderBy(x => x.AdresaStanovanja);
        }

        public IEnumerable<Putnik> SearchByYear(int start, int end)
        {
            return db.Putnici.Where(x => x.GodinaRodjenja >= start && x.GodinaRodjenja <= end).OrderBy(x => x.GodinaRodjenja);
        }

        public Putnik Update(Putnik putnik)
        {
            db.Entry(putnik).State = System.Data.Entity.EntityState.Modified;
            try
            {
                db.SaveChanges();
                return putnik;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}