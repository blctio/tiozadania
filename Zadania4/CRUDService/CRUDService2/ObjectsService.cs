using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ObjectsManager.Interfaces;
using ObjectsManager.LiteDB;

namespace CRUDService2
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ObjectsService : IObjectsService
    {
        private readonly IReviewPersonRepository _reviewpersonRepository;

        public ObjectsService()
        {
            this._reviewpersonRepository = new ReviewPersonRepository();

        }
        public int AddReview(ObjectsManager.Model.Review review)
        {
            return this._reviewpersonRepository.AddReview(review);
        }

        public ObjectsManager.Model.Review GetReview(int id)
        {
            return this._reviewpersonRepository.GetReview(id);
        }

        public List<ObjectsManager.Model.Review> GetAllReviews()
        {
            return this._reviewpersonRepository.GetAllReview();
        }

        public ObjectsManager.Model.Review UpdateReview(ObjectsManager.Model.Review person)
        {
            return this._reviewpersonRepository.UpdateReview(person);
        }

        public bool DeleteReview(int id)
        {
            return this._reviewpersonRepository.DeleteReview(id);
        }

        public int AddPerson(ObjectsManager.Model.Person person)
        {
            return this._reviewpersonRepository.AddPerson(person);
        }

        public ObjectsManager.Model.Person GetPerson(int id)
        {
            return this._reviewpersonRepository.GetPerson(id);
        }

        public List<ObjectsManager.Model.Person> GetAllPersons()
        {
            return this._reviewpersonRepository.GetAllPerson();
        }

        public ObjectsManager.Model.Person UpdatePerson(ObjectsManager.Model.Person person)
        {
            return this._reviewpersonRepository.UpdatePerson(person);
        }

        public bool DeletePerson(int id)
        {
            return this._reviewpersonRepository.DeletePerson(id);
        }
        
    }
}
