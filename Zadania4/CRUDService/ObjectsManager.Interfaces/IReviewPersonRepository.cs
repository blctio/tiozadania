using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectsManager.Model;

namespace ObjectsManager.Interfaces
{
    public interface IReviewPersonRepository
    {
        List<Review> GetAllReview();
        int AddReview(Review review);
        Review GetReview(int id);
        Review UpdateReview(Review reviwe);
        bool DeleteReview(int id);

        List<Person> GetAllPerson();
        int AddPerson(Person person);
        Person GetPerson(int id);
        Person UpdatePerson(Person person);
        bool DeletePerson(int id);
    }
}
