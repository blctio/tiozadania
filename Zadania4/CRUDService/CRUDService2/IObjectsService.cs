using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ObjectsManager.Model;

namespace CRUDService2
{
    [ServiceContract]
    public interface IObjectsService
    {
        [OperationContract]
        int AddReview(Review review);

        [OperationContract]
        Review GetReview(int id);

        [OperationContract]
        List<Review> GetAllReviews();

        [OperationContract]
        Review UpdateReview(Review review);

        [OperationContract]
        bool DeleteReview(int id);

        [OperationContract]
        int AddPerson(Person person);

        [OperationContract]
        Person GetPerson(int id);

        [OperationContract]
        List<Person> GetAllPersons();

        [OperationContract]
        Person UpdatePerson(Person person);

        [OperationContract]
        bool DeletePerson(int id);
    }
}

