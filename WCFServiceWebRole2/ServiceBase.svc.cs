using Core;
using Core.CustomClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static Core.Utilities;

namespace WCFServiceWebRole2
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di classe "ServiceBase" nel codice, nel file svc e nel file di configurazione contemporaneamente.
    // NOTA: per avviare il client di prova WCF per testare il servizio, selezionare ServiceBase.svc o ServiceBase.svc.cs in Esplora soluzioni e avviare il debug.
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
