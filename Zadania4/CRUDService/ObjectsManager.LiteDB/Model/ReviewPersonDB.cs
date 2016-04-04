using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsManager.LiteDB.Model
{
    public class PersonDB
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public void setPersonDB(int i, string n, string s)
        {
            this.Id = i;
            this.Name = n;
            this.Surname = s;
                 
        }
    }
    public class ReviewDB
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Score { get; set; }
        public PersonDB Author { get; set; }
        public int MovieId { get; set; }
    }
    
}
