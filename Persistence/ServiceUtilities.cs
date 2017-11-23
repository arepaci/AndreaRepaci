using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core
{
    public class ServiceUtilities : IDisposable
    {

        #region Disposability
        private IntPtr nativeResource = Marshal.AllocHGlobal(100);

        private Thread runningThread;
        public void Dispose()
        {
            if (runningThread != null)
                if (runningThread.IsAlive)
                {
                    runningThread.Abort();
                }
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ServiceUtilities()
        {
            Dispose(false);
        }
        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {

            // free native resources if there are any.
            if (nativeResource != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeResource);
                nativeResource = IntPtr.Zero;
            }
        }

        #endregion

        public bool ServiceEnabled(Utilities.Enum_Servizi servizio)
        {
            bool bcheck = false;
            string serv = servizio.ToString().ToUpper();
            using (var ctx = new myWebEntities())
            {
                bcheck = ctx.SERVIZIs.First(o => o.CODE.ToUpper().Equals(serv)).IS_ENABLED;
            }
            return bcheck;
        }
    }
}
