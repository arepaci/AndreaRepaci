﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.CustomClasses
{
    [DataContract]
    public class UserViewList
    {
        [DataMember]
        public Utilities.Esito_Controlli esito;
        [DataMember]
        public List<USER> UserList;
    }
}
