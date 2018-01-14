using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.Entity;
using Core.CustomClasses;

namespace Core
{
    public class IdentityUtilities : IDisposable
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

        ~IdentityUtilities()
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

        public USER checkLogin(string username, string password)
        {
            USER objout = null;
            using (var ctx = new myWebEntities())
            {
                objout = ctx.USERS.FirstOrDefault(o=>o.EMAIL.ToUpper().Equals(username.ToUpper()) && o.PASSWORD.ToUpper().Equals(password.ToUpper()));
              
            }
            return objout;
        }

        #region Users

        public USER getUser(string username, string password)
        {
            USER objout = null;
            using (var ctx = new myWebEntities())
            {
                objout = ctx.USERS.Include(o => o.LANGUAGE).Include(o=>o.PROFILE).FirstOrDefault(o =>
                    o.EMAIL.ToUpper().Equals(username.ToUpper()) && o.PASSWORD.ToUpper().Equals(password.ToUpper()));
                
            }
            return objout;
        }

        public USER getUserbyId(Guid UserId)
        {
            USER objout = null;
            using (var ctx = new myWebEntities())
            {
                objout = ctx.USERS.FirstOrDefault(o =>
                    o.ID_USER == UserId);
                
            }
            return objout;
        }

        public List<USER> getUsersByProfile(Guid ProfileId)
        {
            List<USER> objout = null;
            using (var ctx = new myWebEntities())
            {
                objout = ctx.USERS.Where(o =>
                    o.ID_PROFILE == ProfileId).ToList();
            }
            return objout;
        }

        public List<vServiceGroup> GetServiceGroups()
        {
            List<vServiceGroup> objout = null;
            using (var ctx = new myWebEntities())
            {
                objout = ctx.vServiceGroups.OrderBy(o=>o.GRUPPO_SERVIZIO).ThenBy(o=>o.CODE).ToList();
            }
            return objout;
        }

        public List<USER> getUsersByLanguage(Guid LanguageId)
        {
            List<USER> objout = null;
            using (var ctx = new myWebEntities())
            {
                objout = ctx.USERS.Where(o =>
                    o.ID_LANGUAGE == LanguageId).ToList();
            }
            return objout;
        }
        
        public bool updateUser(USER user)
        {
            bool objout = false;
            using (var ctx = new myWebEntities())
            {
               USER OldUser = ctx.USERS.FirstOrDefault(o=>o.ID_USER == user.ID_USER);
                if(OldUser != null)
                {
                    OldUser.EMAIL = user.EMAIL;
                    OldUser.ID_LANGUAGE = user.ID_LANGUAGE;
                    OldUser.ID_PROFILE = user.ID_PROFILE;
                    OldUser.IS_ENABLED = user.IS_ENABLED;
                    OldUser.MOBILE_PHONE_NUMBER = user.MOBILE_PHONE_NUMBER;
                    OldUser.NAME = user.NAME;
                    OldUser.PASSWORD = user.PASSWORD;
                    OldUser.PHONE_NUMBER = user.PHONE_NUMBER;
                    OldUser.SURNAME = user.SURNAME;
                    OldUser.TITLE = user.TITLE;
                    ctx.SaveChanges();
                    objout = true;
                }
                
            }
            return objout;
        }

        public bool EnableUser(Guid userId, bool isenabled)
        {
            bool objout = false;
            using (var ctx = new myWebEntities())
            {
                USER OldUser = ctx.USERS.FirstOrDefault(o => o.ID_USER == userId);

                OldUser.IS_ENABLED = isenabled;

                ctx.SaveChanges();
                objout = true;
            }
            return objout;
        }

        public List<USER> GetAllUser()
        {
            List<USER> objout = null;
            using (var ctx = new myWebEntities())
            {
                objout = ctx.USERS.OrderBy(o=>o.EMAIL).ToList();
            }
            return objout;
        }

        public bool addUser(USER user)
        {
            bool objout = false;
            using (var ctx = new myWebEntities())
            {
                USER OldUser = ctx.USERS.FirstOrDefault(o => o.EMAIL == user.EMAIL);
                if(OldUser == null)
                {
                    ctx.USERS.Add(user);
                    ctx.SaveChanges();
                    objout = true;
                }
                
            }
            return objout;
        }

        #endregion

        #region Profile
        public List<PROFILE> GetAllProfiles()
        {
            List<PROFILE> objout = null;
            using (var ctx = new myWebEntities())
            {
                objout = ctx.PROFILEs.OrderBy(o => o.DESCRIPTION).ToList();
            }
            return objout;
        }

        public bool AddProfile(PROFILE profile)
        {
            bool objout = false;
            using (var ctx = new myWebEntities())
            {
                PROFILE OldProfile = ctx.PROFILEs.FirstOrDefault(o => o.ID_PROFILE == profile.ID_PROFILE);
                if (OldProfile == null)
                {
                    ctx.PROFILEs.Add(profile);
                    ctx.SaveChanges();
                    objout = true;
                }
            }
            return objout;
        }

        public bool UpdateProfile(PROFILE profile)
        {
            bool objout = false;
            using (var ctx = new myWebEntities())
            {
                PROFILE OldProfile = ctx.PROFILEs.FirstOrDefault(o => o.ID_PROFILE == profile.ID_PROFILE);
                if(OldProfile != null)
                {
                    OldProfile.CODE = profile.CODE;
                    OldProfile.DESCRIPTION = profile.DESCRIPTION;
                    ctx.SaveChanges();
                }
                objout = true;
            }
            return objout;
        }

        public PROFILE UpdateProfile(Guid idPriflo)
        {
            PROFILE objout = null;
            using (var ctx = new myWebEntities())
            {
                objout = ctx.PROFILEs.FirstOrDefault(o => o.ID_PROFILE == idPriflo);
            }
            return objout;
        }

        public List<PROFILE> GetProfilesByUserId(Guid idUtente)
        {
            List<PROFILE> objout = null;
            using (var ctx = new myWebEntities())
            {
                objout = (from a in ctx.USERS
                          join b in ctx.PROFILEs 
                          on a.ID_PROFILE equals b.ID_PROFILE
                          select b).ToList();
            }
            return objout;
        }

        public PROFILE GetProfilesByCode(string code)
        {
            PROFILE objout = null;
            using (var ctx = new myWebEntities())
            {
                objout = (from a in ctx.PROFILEs
                          where a.CODE == code
                          select a).FirstOrDefault();
            }
            return objout;
        }


        public List<LANGUAGE> GetLanguages()
        {
            List<LANGUAGE> objout = null;
            using (var ctx = new myWebEntities())
            {
                objout = ctx.LANGUAGEs.OrderBy(o=>o.DESCRIPTION).ToList();
            }
            return objout;
        }

        public LANGUAGE GetLanguagebyId(Guid idLingua)
        {
            LANGUAGE objout = null;
            using (var ctx = new myWebEntities())
            {
                objout = ctx.LANGUAGEs.First(o => o.ID_LANGUAGE == idLingua);
            }
            return objout;
        }

        public LANGUAGE GetLanguagebyCode(string CODE)
        {
            LANGUAGE objout = null;
            using (var ctx = new myWebEntities())
            {
                objout = ctx.LANGUAGEs.FirstOrDefault(o => o.CODE == CODE);
            }
            return objout;
        }


        public LANGUAGE GetLanguagebyIdUser(Guid idUser)
        {
            LANGUAGE objout = null;
            using (var ctx = new myWebEntities())
            {
                objout = (from a in ctx.USERS
                          join b in ctx.LANGUAGEs
                          on a.ID_LANGUAGE equals b.ID_LANGUAGE
                          select b).First();
            }
            return objout;
        }


        #endregion

    }
}
