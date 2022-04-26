using KatarinaZvkovic.Net13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatarinaZvkovic.Net13.Intrfaces
{
    public interface IAutobusRepository 
    {
        IEnumerable<Autobus> GetAll();
        Autobus GetId(int id);
        IEnumerable<Autobus> GetAllSorted();
        IEnumerable<Autobus> GetAllByOznaka(string oznaka);


    }
}
