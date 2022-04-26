using KatarinaZvkovic.Net13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatarinaZvkovic.Net13.Intrfaces
{
    public interface IPutnikRepository 
    {
        IQueryable<Putnik> GetAll();
        Putnik GetId(int id);
        void Add(Putnik putnik);
        Putnik Update(Putnik putnik);
        void Delete(Putnik putnik);
        IEnumerable<Putnik> SearchByYear(int start, int end);
        IQueryable<Putnik> SearchByAdress(string adresa);
        IQueryable<PutnikSumDTO> GetAllCompSum();




    }
}
