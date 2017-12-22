using Core.CustomClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.FakeService
{
    public interface IUserService
    {



        #region Users

        UserView GetUser(string username, string password);

        UserView GetUserById(Guid User_Id);


        UserViewList GetUsersByProfiles(Guid ProfileId);

        UserViewList GetUsersByLanguage(Guid LanguageId);

        boolView UpdateUser(USER User);

        boolView EnableUser(Guid userId, bool isenabled);

        UserViewList GetUsers();

        boolView AddUsers(USER user);


        #endregion

        #region Profiles

        ProfileViewList GetProfiles();

        boolView AddProfile(PROFILE profile);

        boolView UpdateProfile(PROFILE profile);


        ProfileView GetProfileById(Guid idPriflo);

        ProfileViewList GetProfilesByUserId(Guid idUtente);


        #endregion


        #region Utilities

        UserView checkLogin(string username, string password);

        vServiceGroupViewList GetServiceGroups();

        #region Lingua

        LinguaViewList GetLanguages();

        LinguaView GetLanguagebyId(Guid idLingua);


        LinguaView GetLanguagebyIdUser(Guid idUser);

        #endregion

        #endregion
    }
}
