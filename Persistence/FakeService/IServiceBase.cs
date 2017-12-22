using Core.CustomClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.FakeService
{
    public interface IServiceBase
    {
        bool checkServizioAbilitato(Guid idServizio);
        boolView checkServizioAbilitato(Core.Utilities.Enum_Servizi Servizio);
    }
}
