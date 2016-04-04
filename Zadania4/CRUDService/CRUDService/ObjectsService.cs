using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ObjectsManager.Interfaces;
using ObjectsManager.LiteDB;

namespace CRUDService1
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ObjectsService : IObjectsService
    {
        private readonly IMovieRepository _movieRepository;
       
        public ObjectsService()
        {
            this._movieRepository = new MovieRepository();
           
        }
        public int AddMovie(ObjectsManager.Model.Movie movie)
        {
            return this._movieRepository.Add(movie);
        }

        public ObjectsManager.Model.Movie GetMovie(int id)
        {
            return this._movieRepository.Get(id);
        }

        public List<ObjectsManager.Model.Movie> GetAllMovies()
        {
            return this._movieRepository.GetAll();
        }

        public ObjectsManager.Model.Movie UpdateMovie(ObjectsManager.Model.Movie movie)
        {
            return this._movieRepository.Update(movie);
        }

        public bool DeleteMovie(int id)
        {
            return this._movieRepository.Delete(id);
        }


    }
}
