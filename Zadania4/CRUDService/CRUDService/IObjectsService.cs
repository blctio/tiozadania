using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ObjectsManager.Model;

namespace CRUDService1
{
    [ServiceContract]
    public interface IObjectsService
    {
        [OperationContract]
        int AddMovie(Movie movie);

        [OperationContract]
        Movie GetMovie(int id);

        [OperationContract]
        List<Movie> GetAllMovies();

        [OperationContract]
        Movie UpdateMovie(Movie movie);

        [OperationContract]
        bool DeleteMovie(int id);

    }
}
