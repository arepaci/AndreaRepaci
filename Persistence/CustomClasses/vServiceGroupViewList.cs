using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.CustomClasses
{
    [DataContract]
   public class vServiceGroupViewList
    {
        [DataMember]
        public List<vServiceGroup> servicegroupsList;
        [DataMember]
        public Utilities.Esito_Controlli  esito;

    }
}
