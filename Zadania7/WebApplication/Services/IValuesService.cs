using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication9.Models;

namespace WebApplication9.Services
{
    public interface IValuesService
    {
        Item[] GetValues();
        Item Get(int id);
        int Add(Item item);
        void Delete(int id);
    }
}