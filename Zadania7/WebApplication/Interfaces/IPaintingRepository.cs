using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication9.Models;

namespace WebApplication9.Interfaces
{
    public interface IPaintingRepository
    {
        List<Painting> GetAll();
        Painting Get(int id);
        int Add(Painting painting);
        Painting Update(Painting painting);
        bool Delete(int id);

    }
}
