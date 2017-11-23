using System;
using System.Runtime.Serialization;

namespace MyCoreUtils.Serializable
{
    [DataContract]
    public class SeializableUsers
    {
        [DataContract]
        public class User
        {
            [DataMember]
            public Guid UserId;
            [DataMember]
            public Guid ProfiloId;
            [DataMember]
            public Guid LanguageId;
            [DataMember]
            public String Name;
            [DataMember]
            public String Surname;
            [DataMember]
            public String Title;
            [DataMember]
            public String email;
            [DataMember]
            public String Password;
            [DataMember]
            public Boolean IsEnabled;
            [DataMember]
            public String PhoneNumber;
            [DataMember]
            public String MobilePhoneNumber;
        }

        [DataContract]
        public class Profile
        {
            [DataMember]
            public Guid ProfileId;
            [DataMember]
            public String Code;
            [DataMember]
            public String Description;
            
        }

        [DataContract]
        public class Language
        {
            [DataMember]
            public Guid LanguageId;
            [DataMember]
            public String Code;
            [DataMember]
            public String Description;

        }

    }
}
