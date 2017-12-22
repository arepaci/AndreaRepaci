using Core.CustomClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Utilities;

namespace Core.FakeService
{
    public class ServiceBase : IServiceBase
    {
        public bool checkServizioAbilitato(Guid idServizio)
        {
            using (var ctx = new myWebEntities())
            {
                return ctx.SERVIZIs.First(o => o.ID_SERVIZIO == idServizio).IS_ENABLED;
            }
        }

        public boolView checkServizioAbilitato(Core.Utilities.Enum_Servizi Servizio)
        {

            boolView bcheck = new boolView();
            bcheck.bEsito = false;
            bcheck.esito = Esito_Controlli.KO;
            using (var core = new Core.ServiceUtilities())
            {
                bcheck.bEsito = core.ServiceEnabled(Enum_Servizi.ChechServizioAbilitato);
                bcheck.esito = Esito_Controlli.OK;
            }
            return bcheck;

        }
    }
}
