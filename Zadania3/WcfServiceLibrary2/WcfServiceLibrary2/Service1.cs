﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]

    public class Service1 : IService1
    {
        public int GetMoneyFromImperium()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            return rnd.Next(3000, 5001);
        }
    }
}
