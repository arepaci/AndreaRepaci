using Core.CustomClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Utilities;
using static Core.Log;

namespace Core.FakeService
{
    public class UserService : IUserService, IServiceBase
    {

        #region Utilities

        public UserView checkLogin(string username, string password)
        {
            Core.Log.LogInfoLevel(string.Format("Called service UserService - Function checkLogin for user {0}",
                username));

            UserView objout = new UserView() { esito = Esito_Controlli.KO };
            try
            {
                if (checkServizioAbilitato(Enum_Servizi.CheckLogin).bEsito)
                {
                    bool bcheck = false;
                    using (var persistence = new Core.IdentityUtilities())
                    {

                        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                        {
                            Core.Log.LogInfoLevel(string.Format("Called service UserService - Checking availabilty for user {0}", username));
                            USER user = persistence.checkLogin(username, password);
                            if (user != null)
                            {
                                objout.User = user;
                                objout.esito = Esito_Controlli.OK;
                            }
                        }
                    }
                    Core.Log.LogInfoLevel(string.Format("Called service UserService - Function checkLogin user {0} checked with value {1}", username, bcheck));
                }
            }
            catch (Exception ex)
            {
                LogFataloLevel(string.Format("service UserService checkLogin : {0}", Log.GetExException(ex)));
            }

            return objout;
        }

        public vServiceGroupViewList GetServiceGroups()
        {
            vServiceGroupViewList vout = new vServiceGroupViewList()
            {
                esito = Esito_Controlli.KO,
                servicegroupsList = null
            };
            Core.Log.LogInfoLevel(string.Format("Called service UserService - Function GetServiceGroups"));

            try
            {
                if (checkServizioAbilitato(Enum_Servizi.GetServiceGroups).bEsito)
                {
                    using (var persistence = new Core.IdentityUtilities())
                    {

                        vout.servicegroupsList = persistence.GetServiceGroups();
                        vout.esito = Esito_Controlli.OK;

                    }
                }
                else
                {
                    vout.esito = Esito_Controlli.SERVIZIO_NON_ATTIVO;
                }
            }
            catch (Exception ex)
            {
                LogFataloLevel(string.Format("service UserService GetServiceGroups : {0}", Log.GetExException(ex)));
                vout.esito = Esito_Controlli.KO;
            }

            Core.Log.LogInfoLevel(string.Format("Exit service UserService - Function GetServiceGroups"));
            return vout;

        }


        #region Lingue

        public LinguaViewList GetLanguages()
        {
            LogInfoLevel(string.Format("Called service UserService - Function GetLanguages"));
            LinguaViewList bout = new LinguaViewList()
            {
                lingue = null,
                esito = Esito_Controlli.KO
            };

            try
            {
                if (checkServizioAbilitato(Enum_Servizi.GetLanguages).bEsito)
                {
                    using (var persistece = new IdentityUtilities())
                    {
                        bout.lingue = persistece.GetLanguages();
                        bout.esito = Esito_Controlli.OK;
                    }
                }
                else
                {
                    bout.esito = Esito_Controlli.SERVIZIO_NON_ATTIVO;
                }
            }
            catch (Exception ex)
            {
                LogFataloLevel(string.Format("service UserService GetLanguages : {0}", Log.GetExException(ex)));
                bout.esito = Esito_Controlli.KO;
            }

            LogInfoLevel(string.Format("Exit service UserService - Function GetLanguages"));
            return bout;
        }

        public LinguaView GetLanguagebyId(Guid idLingua)
        {
            LogInfoLevel(string.Format("Called service UserService - Function GetLanguagebyId for the language {0}", idLingua.ToString()));
            LinguaView bout = new LinguaView()
            {
                lingua = null,
                esito = Esito_Controlli.KO
            };

            try
            {
                if (checkServizioAbilitato(Enum_Servizi.GetLanguagebyId).bEsito)
                {
                    using (var persistece = new IdentityUtilities())
                    {
                        bout.lingua = persistece.GetLanguagebyId(idLingua);
                        bout.esito = Esito_Controlli.OK;
                    }
                }
                else
                {
                    bout.esito = Esito_Controlli.SERVIZIO_NON_ATTIVO;
                }
            }
            catch (Exception ex)
            {
                LogFataloLevel(string.Format("service UserService GetLanguagebyId : {0}", Log.GetExException(ex)));
                bout.esito = Esito_Controlli.KO;
            }

            LogInfoLevel(string.Format("Exit service UserService - Function GetLanguagebyId for the language {0}", idLingua.ToString()));
            return bout;
        }

        public LinguaView GetLanguagebyIdUser(Guid idUser)
        {
            LogInfoLevel(string.Format("Called service UserService - Function GetLanguagebyIdUser for the user {0}", idUser.ToString()));
            LinguaView bout = new LinguaView()
            {
                lingua = null,
                esito = Esito_Controlli.KO
            };

            try
            {
                if (checkServizioAbilitato(Enum_Servizi.GetLanguagebyIdUser).bEsito)
                {
                    using (var persistece = new IdentityUtilities())
                    {
                        bout.lingua = persistece.GetLanguagebyIdUser(idUser);
                        bout.esito = Esito_Controlli.OK;
                    }
                }
                else
                {
                    bout.esito = Esito_Controlli.SERVIZIO_NON_ATTIVO;
                }
            }
            catch (Exception ex)
            {
                LogFataloLevel(string.Format("service UserService GetLanguagebyIdUser : {0}", Log.GetExException(ex)));
                bout.esito = Esito_Controlli.KO;
            }

            LogInfoLevel(string.Format("Exit service UserService - Function GetLanguagebyIdUser for the user {0}", idUser.ToString()));
            return bout;
        }

        #endregion

        #endregion

        #region Users   

        public UserView GetUser(string username, string password)
        {
            Core.Log.LogInfoLevel(string.Format("Called service UserService - Function GetUser for user {0}", username));
            UserView objout = null;

            try
            {
                if (checkServizioAbilitato(Enum_Servizi.GetUser).bEsito)
                {
                    using (var persistence = new Core.IdentityUtilities())
                    {

                        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                        {
                            objout.User = persistence.getUser(username, password);
                            objout.esito = Esito_Controlli.OK;
                        }
                    }
                }
                else
                {
                    objout.esito = Esito_Controlli.SERVIZIO_NON_ATTIVO;
                }
            }
            catch (Exception ex)
            {
                LogFataloLevel(string.Format("service UserService checkLogin : {0}", Log.GetExException(ex)));
                objout.esito = Esito_Controlli.KO;
            }

            Core.Log.LogInfoLevel(string.Format("Exit service UserService - Function GetUser for user {0}", username));
            return objout;
        }

        public UserView GetUserById(Guid User_Id)
        {
            Core.Log.LogInfoLevel(string.Format("Called service UserService - Function GetUserById for user {0}", User_Id));
            UserView objout = null;

            try
            {
                if (checkServizioAbilitato(Enum_Servizi.GetUserById).bEsito)
                {
                    using (var persistence = new Core.IdentityUtilities())
                    {

                        objout.User = persistence.getUserbyId(User_Id);
                        objout.esito = Esito_Controlli.OK;
                    }
                    Core.Log.LogInfoLevel(string.Format("Exit service UserService - Function GetUserById for user {0}", User_Id));
                }
                else
                {
                    objout.esito = Esito_Controlli.SERVIZIO_NON_ATTIVO;
                }
            }
            catch (Exception ex)
            {
                LogFataloLevel(string.Format("service UserService AbbinamentoProfiloMenu : {0}", Log.GetExException(ex)));
                objout.esito = Esito_Controlli.KO;
            }


            return objout;
        }

        public UserViewList GetUsersByProfiles(Guid ProfileId)
        {
            Core.Log.LogInfoLevel(string.Format("Called service UserService - Function GetUsersByProfiles for profile {0}", ProfileId));
            UserViewList objout = null;

            try
            {
                if (checkServizioAbilitato(Enum_Servizi.GetUsersByProfiles).bEsito)
                {
                    using (var persistence = new Core.IdentityUtilities())
                    {

                        objout.UserList = persistence.getUsersByProfile(ProfileId);
                        objout.esito = Esito_Controlli.OK;
                    }
                }
                else
                {
                    objout.esito = Esito_Controlli.SERVIZIO_NON_ATTIVO;
                }
            }
            catch (Exception ex)
            {
                LogFataloLevel(string.Format("service UserService AbbinamentoProfiloMenu : {0}", Log.GetExException(ex)));
                objout.esito = Esito_Controlli.KO;
            }


            Core.Log.LogInfoLevel(string.Format("Exit service UserService - Function GetUsersByProfiles for profile {0}", ProfileId));
            return objout;
        }

        public UserViewList GetUsersByLanguage(Guid LanguageId)
        {
            Core.Log.LogInfoLevel(string.Format("Called service UserService - Function GetUsersByLanguage for language {0}", LanguageId));
            UserViewList objout = null;

            try
            {
                if (checkServizioAbilitato(Enum_Servizi.GetUsersByLanguage).bEsito)
                {
                    using (var persistence = new Core.IdentityUtilities())
                    {

                        objout.UserList = persistence.getUsersByLanguage(LanguageId);
                        objout.esito = Esito_Controlli.OK;
                    }
                }
                else
                {
                    objout.esito = Esito_Controlli.SERVIZIO_NON_ATTIVO;
                }
            }
            catch (Exception ex)
            {
                LogFataloLevel(string.Format("service UserService AbbinamentoProfiloMenu : {0}", Log.GetExException(ex)));
                objout.esito = Esito_Controlli.KO;
            }


            Core.Log.LogInfoLevel(string.Format("Exit service UserService - Function GetUsersByLanguage for language {0}", LanguageId));
            return objout;
        }

        public bool checkServizioAbilitato(Guid idServizio)
        {
            Core.Log.LogInfoLevel(string.Format("Called service UserService - Function checkServizioAbilitato"));
            using (var ctx = new myWebEntities())
            {
                return ctx.SERVIZIs.First(o => o.ID_SERVIZIO == idServizio).IS_ENABLED;
            }
        }

        public boolView checkServizioAbilitato(Core.Utilities.Enum_Servizi Servizio)
        {

            Core.Log.LogInfoLevel(string.Format("Called service UserService - Function checkServizioAbilitato for the service {0}", Servizio.ToString()));
            boolView bcheck = new boolView();
            bcheck.bEsito = false;
            bcheck.esito = Esito_Controlli.KO;
            using (var core = new Core.ServiceUtilities())
            {
                bcheck.bEsito = core.ServiceEnabled(Enum_Servizi.ChechServizioAbilitato);
                bcheck.esito = Esito_Controlli.OK;
            }
            Core.Log.LogInfoLevel(string.Format("Exit service UserService - Function checkServizioAbilitato for the service {0}", Servizio.ToString()));
            return bcheck;

        }

        public boolView UpdateUser(USER User)
        {
            Core.Log.LogInfoLevel(string.Format("Called service UserService - Function UpdateUser for the user{0}", User.EMAIL));
            boolView bout = new boolView()
            {
                bEsito = false,
                esito = Esito_Controlli.KO
            };


            try
            {
                if (checkServizioAbilitato(Enum_Servizi.UpdateUser).bEsito)
                {
                    using (var persistece = new IdentityUtilities())
                    {
                        bout.bEsito = persistece.updateUser(User);
                        bout.esito = Esito_Controlli.OK;
                    }
                }
                else
                {
                    bout.esito = Esito_Controlli.SERVIZIO_NON_ATTIVO;
                }
            }
            catch (Exception ex)
            {
                LogFataloLevel(string.Format("service UserService UpdateUser : {0}", Log.GetExException(ex)));
                bout.esito = Esito_Controlli.KO;
            }

            Core.Log.LogInfoLevel(string.Format("Exit service UserService - Function UpdateUser for the user {0}", User.EMAIL));
            return bout;
        }

        public boolView EnableUser(Guid userId, bool isenabled)
        {
            Core.Log.LogInfoLevel(string.Format("Called service UserService - Function EnableUser for the user {0}", userId.ToString()));
            boolView bout = new boolView()
            {
                bEsito = false,
                esito = Esito_Controlli.KO
            };


            try
            {
                if (checkServizioAbilitato(Enum_Servizi.EnableUser).bEsito)
                {
                    using (var persistece = new IdentityUtilities())
                    {
                        bout.bEsito = persistece.EnableUser(userId, isenabled);
                        bout.esito = Esito_Controlli.OK;
                    }
                }
                else
                {
                    bout.esito = Esito_Controlli.SERVIZIO_NON_ATTIVO;
                }
            }
            catch (Exception ex)
            {
                LogFataloLevel(string.Format("service UserService EnableUser : {0}", Log.GetExException(ex)));
                bout.esito = Esito_Controlli.KO;
            }

            Core.Log.LogInfoLevel(string.Format("Exit service UserService - Function EnableUser for the user {0}", userId.ToString()));
            return bout;
        }

        public UserViewList GetUsers()
        {
            Core.Log.LogInfoLevel(string.Format("Called service UserService - Function GetUsers "));
            UserViewList bout = new UserViewList()
            {
                UserList = null,
                esito = Esito_Controlli.KO
            };


            try
            {
                if (checkServizioAbilitato(Enum_Servizi.GetUsers).bEsito)
                {
                    using (var persistece = new IdentityUtilities())
                    {
                        bout.UserList = persistece.GetAllUser();
                        bout.esito = Esito_Controlli.OK;
                    }
                }
                else
                {
                    bout.esito = Esito_Controlli.SERVIZIO_NON_ATTIVO;
                }
            }
            catch (Exception ex)
            {
                LogFataloLevel(string.Format("service UserService GetUsers : {0}", Log.GetExException(ex)));
                bout.esito = Esito_Controlli.KO;
            }

            Core.Log.LogInfoLevel(string.Format("Exit service UserService - Function GetUsers "));
            return bout;
        }

        public boolView AddUsers(USER user)
        {
            Core.Log.LogInfoLevel(string.Format("Called service UserService - Function AddUsers for the user {0}", user.EMAIL));
            boolView bout = new boolView()
            {
                bEsito = false,
                esito = Esito_Controlli.KO
            };


            try
            {
                if (checkServizioAbilitato(Enum_Servizi.AddUsers).bEsito)
                {
                    using (var persistece = new IdentityUtilities())
                    {
                        bout.bEsito = persistece.addUser(user);
                        bout.esito = Esito_Controlli.OK;
                    }
                }
                else
                {
                    bout.esito = Esito_Controlli.SERVIZIO_NON_ATTIVO;
                }
            }
            catch (Exception ex)
            {
                LogFataloLevel(string.Format("service UserService AddUsers : {0}", Log.GetExException(ex)));
                bout.esito = Esito_Controlli.KO;
            }

            Core.Log.LogInfoLevel(string.Format("Exit service UserService - Function AddUsers for the user {0}", user.EMAIL));
            return bout;
        }

        #endregion

        #region Profiles

        public ProfileViewList GetProfiles()
        {
            Core.Log.LogInfoLevel(string.Format("Called service UserService - Function GetProfiles "));
            ProfileViewList bout = new ProfileViewList()
            {
                ProfileList = null,
                esito = Esito_Controlli.KO
            };

            try
            {
                if (checkServizioAbilitato(Enum_Servizi.GetProfiles).bEsito)
                {
                    using (var persistece = new IdentityUtilities())
                    {
                        bout.ProfileList = persistece.GetAllProfiles();
                        bout.esito = Esito_Controlli.OK;
                    }
                }
                else
                {
                    bout.esito = Esito_Controlli.SERVIZIO_NON_ATTIVO;
                }
            }
            catch (Exception ex)
            {
                LogFataloLevel(string.Format("service UserService GetProfiles : {0}", Log.GetExException(ex)));
                bout.esito = Esito_Controlli.KO;
            }

            Core.Log.LogInfoLevel(string.Format("Exit service UserService - Function GetProfiles "));
            return bout;
        }

        public boolView AddProfile(PROFILE profile)
        {
            Core.Log.LogInfoLevel(string.Format("Called service UserService - Function AddProfile for the profile {0}", profile.DESCRIPTION));
            boolView bout = new boolView()
            {
                bEsito = false,
                esito = Esito_Controlli.KO
            };

            try
            {
                if (checkServizioAbilitato(Enum_Servizi.AddProfile).bEsito)
                {
                    using (var persistece = new IdentityUtilities())
                    {
                        bout.bEsito = persistece.AddProfile(profile);
                        bout.esito = Esito_Controlli.OK;
                    }
                }
                else
                {
                    bout.esito = Esito_Controlli.SERVIZIO_NON_ATTIVO;
                }
            }
            catch (Exception ex)
            {
                LogFataloLevel(string.Format("service UserService AddProfile : {0}", Log.GetExException(ex)));
                bout.esito = Esito_Controlli.KO;
            }

            Core.Log.LogInfoLevel(string.Format("Exit service UserService - Function AddProfile for the profile {0}", profile.DESCRIPTION));
            return bout;
        }

        public boolView UpdateProfile(PROFILE profile)
        {
            Core.Log.LogInfoLevel(string.Format("Called service UserService - Function UpdateProfile for the profile {0}", profile.DESCRIPTION));
            boolView bout = new boolView()
            {
                bEsito = false,
                esito = Esito_Controlli.KO
            };

            try
            {
                if (checkServizioAbilitato(Enum_Servizi.AddProfile).bEsito)
                {
                    using (var persistece = new IdentityUtilities())
                    {
                        bout.bEsito = persistece.UpdateProfile(profile);
                        bout.esito = Esito_Controlli.OK;
                    }
                }
                else
                {
                    bout.esito = Esito_Controlli.SERVIZIO_NON_ATTIVO;
                }
            }
            catch (Exception ex)
            {
                LogFataloLevel(string.Format("service UserService UpdateProfile : {0}", Log.GetExException(ex)));
                bout.esito = Esito_Controlli.KO;
            }

            Core.Log.LogInfoLevel(string.Format("Exit service UserService - Function UpdateProfile for the profile {0}", profile.DESCRIPTION));
            return bout;
        }

        public ProfileView GetProfileById(Guid idPriflo)
        {
            Core.Log.LogInfoLevel(string.Format("Called service UserService - Function GetProfileById for the profile {0}", idPriflo.ToString()));
            ProfileView bout = new ProfileView()
            {
                Profile = null,
                esito = Esito_Controlli.KO
            };

            try
            {
                if (checkServizioAbilitato(Enum_Servizi.GetProfileById).bEsito)
                {
                    using (var persistece = new IdentityUtilities())
                    {
                        bout.Profile = persistece.UpdateProfile(idPriflo);
                        bout.esito = Esito_Controlli.OK;
                    }
                }
                else
                {
                    bout.esito = Esito_Controlli.SERVIZIO_NON_ATTIVO;
                }
            }
            catch (Exception ex)
            {
                LogFataloLevel(string.Format("service UserService GetProfileById : {0}", Log.GetExException(ex)));
                bout.esito = Esito_Controlli.KO;
            }

            Core.Log.LogInfoLevel(string.Format("Exit service UserService - Function GetProfileById for the profile {0}", idPriflo.ToString()));
            return bout;
        }

        public ProfileViewList GetProfilesByUserId(Guid idUtente)
        {
            LogInfoLevel(string.Format("Called service UserService - Function GetProfilesByUserId for the user {0}", idUtente.ToString()));
            ProfileViewList bout = new ProfileViewList()
            {
                ProfileList = null,
                esito = Esito_Controlli.KO
            };

            try
            {
                if (checkServizioAbilitato(Enum_Servizi.GetProfilesByUserId).bEsito)
                {
                    using (var persistece = new IdentityUtilities())
                    {
                        bout.ProfileList = persistece.GetProfilesByUserId(idUtente);
                        bout.esito = Esito_Controlli.OK;
                    }
                }
                else
                {
                    bout.esito = Esito_Controlli.SERVIZIO_NON_ATTIVO;
                }
            }
            catch (Exception ex)
            {
                LogFataloLevel(string.Format("service UserService GetProfilesByUserId : {0}", Log.GetExException(ex)));
                bout.esito = Esito_Controlli.KO;
            }

            LogInfoLevel(string.Format("Exit service UserService - Function GetProfilesByUserId for the user {0}", idUtente.ToString()));
            return bout;
        }





        #endregion

    }
}
