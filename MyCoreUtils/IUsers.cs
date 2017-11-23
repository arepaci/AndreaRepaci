using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace MyCoreUtils
{
    public interface IUsers
    {
    

        [OperationContract]
        bool checkLogin(string username, string password);

        [OperationContract]
        USER GetUser(string username, string password);

        [OperationContract]
        USER GetUser(Guid User_Id);


        [OperationContract]
        List<USER> GetUsers();

        [OperationContract]
        List<USER> GetUsersByProfile(Guid Profilo_Id);

    }
}
