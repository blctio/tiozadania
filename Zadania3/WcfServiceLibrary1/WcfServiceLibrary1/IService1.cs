using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CosmicAdventureDTO;

namespace WcfServiceLibrary1
{
       
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void Initializegame();

        [OperationContract]
        Starship SendStarship(Starship starship, string systemName);

        [OperationContract]
        SpaceSystem GetSystem();

        [OperationContract]
        Starship GetStarship(int money);

        [OperationContract]
        string showCrew(Starship ship);
    }
}
