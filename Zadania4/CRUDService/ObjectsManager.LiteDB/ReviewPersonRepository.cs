using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using ObjectsManager.Interfaces;
using ObjectsManager.LiteDB.Model;
using ObjectsManager.Model;

namespace ObjectsManager.LiteDB
{
    public class ReviewPersonRepository : IReviewPersonRepository
    {
        private readonly string _revierpersonConnection = DatabaseConnections.ReviewPersonConnection;

        public List<Review> GetAllReview()
        {
            using (var db = new LiteDatabase(this._revierpersonConnection))
            {
                var repository = db.GetCollection<ReviewDB>("reviewpersons");
                var results = repository.FindAll();

                return results.Select(x => MapReview(x)).ToList();    
                
            }
        }

        public List<Person> GetAllPerson()
        {
            using (var db = new LiteDatabase(this._revierpersonConnection))
            {
                var repository = db.GetCollection<PersonDB>("reviewpersons");
                var results = repository.FindAll();

                return results.Select(x => MapPerson(x)).ToList();
                
            }
        }

        public int AddReview(Review reviews)
        {
            using (var db = new LiteDatabase(this._revierpersonConnection))
            {
                var dbObject = InverseMapReview(reviews);


                var repository = db.GetCollection<ReviewDB>("reviewpersons");
                repository.Insert(dbObject);

                return dbObject.Id;
            }
        }


        public int AddPerson(Person persons)
        {
            using (var db = new LiteDatabase(this._revierpersonConnection))
            {
                var dbObject = InverseMapPerson(persons);


                var repository = db.GetCollection<PersonDB>("reviewpersons");
                repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        public Review GetReview(int id)
        {
            using (var db = new LiteDatabase(this._revierpersonConnection))
            {
                var repository = db.GetCollection<ReviewDB>("reviewpersons");
                var result = repository.FindById(id);
                return MapReview(result);
            }
        }

        public Person GetPerson(int id)
        {
            using (var db = new LiteDatabase(this._revierpersonConnection))
            {
                var repository = db.GetCollection<PersonDB>("reviewpersons");
                var result = repository.FindById(id);
                return MapPerson(result);
            }
        }


        public Review UpdateReview(Review reviews)
        {
            using (var db = new LiteDatabase(this._revierpersonConnection))
            {
                var dbObject = InverseMapReview(reviews);

                var repository = db.GetCollection<ReviewDB>("reviewpersons");
                if (repository.Update(dbObject))
                    return MapReview(dbObject);
                else
                    return null;
            }
        }

        public Person UpdatePerson(Person persons)
        {
            using (var db = new LiteDatabase(this._revierpersonConnection))
            {
                var dbObject = InverseMapPerson(persons);

                var repository = db.GetCollection<PersonDB>("reviewpersons");
                if (repository.Update(dbObject))
                    return MapPerson(dbObject);
                else
                    return null;
            }
        }

        public bool DeleteReview(int id)
        {
            using (var db = new LiteDatabase(this._revierpersonConnection))
            {
                var repository = db.GetCollection<ReviewDB>("reviewpersons");
                return repository.Delete(id);
            }
        }


        public bool DeletePerson(int id)
        {
            using (var db = new LiteDatabase(this._revierpersonConnection))
            {
                var repository = db.GetCollection<PersonDB>("reviewpersons");
                return repository.Delete(id);
            }
        }

        private Review MapReview(ReviewDB dbReview)
        {
            if (dbReview == null)
                return null;
            return new Review() {Id = dbReview.Id, Content = dbReview.Content, Score = dbReview.Score, Author = new Person()
            {
                Id = dbReview.Author.Id,
                Name = dbReview.Author.Name,
                Surname = dbReview.Author.Surname
            },
            MovieId = dbReview.MovieId };
        }

        private Person MapPerson(PersonDB dbPerson)
        {
            if (dbPerson == null)
                return null;
            return new Person()
            {
                Id = dbPerson.Id,
                Name = dbPerson.Name,
                Surname = dbPerson.Surname
            };
        }

        private ReviewDB InverseMapReview(Review reviews)
        {
            if (reviews == null)
                return null;
            return new ReviewDB()
            {
                Id = reviews.Id,
                Content = reviews.Content,
                Score = reviews.Score,
                Author = new PersonDB()
                {
                    Id = reviews.Author.Id,
                    Name = reviews.Author.Name,
                    Surname = reviews.Author.Surname
                },
                MovieId = reviews.MovieId
            };
        }

        private PersonDB InverseMapPerson(Person persons)
        {
            if (persons == null)
                return null;
            return new PersonDB()
            {
                Id = persons.Id,
                Name = persons.Name,
                Surname = persons.Surname
            };            
        }
    }
}
