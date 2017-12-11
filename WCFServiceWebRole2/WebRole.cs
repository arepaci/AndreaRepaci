using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace WCFServiceWebRole2
{
    public class WebRole : RoleEntryPoint
    {
        public override bool OnStart()
        {
            // Per informazioni sulla gestione delle modifiche alla configurazione,
            // vedere l'argomento MSDN all'indirizzo https://go.microsoft.com/fwlink/?LinkId=166357.

            return base.OnStart();
        }
    }
}
