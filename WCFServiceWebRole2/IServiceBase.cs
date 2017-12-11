using Core.CustomClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceWebRole2
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di interfaccia "IServiceBase" nel codice e nel file di configurazione contemporaneamente.
    [ServiceContract]
    public interface IServiceBase
    {
        [OperationContract]
        bool checkServizioAbilitatoByID(Guid idServizio);
        [OperationContract]
        boolView checkServizioAbilitato(Core.Utilities.Enum_Servizi Servizio);
    }
}
