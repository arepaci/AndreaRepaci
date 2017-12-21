using Core;
using Core.CustomClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLocal
{
    // NOTA: è possibile utilizzare il comando "Rinomina" del menu "Refactoring" per modificare il nome di interfaccia "IUserService" nel codice e nel file di configurazione contemporaneamente.
    [ServiceContract]
    public interface IUserService
    {



        #region Users

        [OperationContract]
        UserView GetUser(string username, string password);

        [OperationContract]
        UserView GetUserById(Guid User_Id);


        [OperationContract]
        UserViewList GetUsersByProfiles(Guid ProfileId);

        [OperationContract]
        UserViewList GetUsersByLanguage(Guid LanguageId);

        [OperationContract]
        boolView UpdateUser(USER User);

        [OperationContract]
        boolView EnableUser(Guid userId, bool isenabled);

        [OperationContract]
        UserViewList GetUsers();

        [OperationContract]
        boolView AddUsers(USER user);


        #endregion

        #region Profiles

        [OperationContract]
        ProfileViewList GetProfiles();

        [OperationContract]
        boolView AddProfile(PROFILE profile);

        [OperationContract]
        boolView UpdateProfile(PROFILE profile);


        [OperationContract]
        ProfileView GetProfileById(Guid idPriflo);

        [OperationContract]
        ProfileViewList GetProfilesByUserId(Guid idUtente);


        #endregion


        #region Utilities

        [OperationContract]
        USER checkLogin(string username, string password);

        [OperationContract]
        vServiceGroupViewList GetServiceGroups();

        #region Lingua

        [OperationContract]
        LinguaViewList GetLanguages();

        [OperationContract]
        LinguaView GetLanguagebyId(Guid idLingua);


        [OperationContract]
        LinguaView GetLanguagebyIdUser(Guid idUser);

        #endregion

        #endregion

    }
}
