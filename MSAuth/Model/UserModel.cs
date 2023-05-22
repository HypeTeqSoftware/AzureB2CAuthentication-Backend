using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSAuth.Model
{
    public class UserModel
    {

        public bool accountEnabled { get; set; }

        public string displayName { get; set; }

        public List<Identities> identities { get; set; }

        public string passwordProfile { get; set; }

        public List<string> passwordPolicies { get;set; }
    }

    public class Identities
    {
        public string SignInType { get; set; }


        public string Issuer { get; set; }

        public string IssuerAssignedId { get; set; }

    }


    public class Identity
    {
        public string SignInType { get; set; }
        public string Issuer { get; set; }
        public string IssuerAssignedId { get; set; }
    }

    public class PasswordProfile
    {
        public string password { get; set; }

        public bool ForceChangePasswordNextSignIn { get; set; }
    }

    public class Root
    {
        public bool accountEnabled { get; set; }
        public string displayName { get; set; }
        public List<Identity> identities { get; set; }
        public PasswordProfile passwordProfile { get; set; }

        //public string extension_b830ea226c7649a1ba3b1bfd59f8fd57_correlationId { get; set; }
        public string extension_fde214df89d4429e94051ec651103bf0_correlationId { get; set; }
        public string extension_fde214df89d4429e94051ec651103bf0_userID { get; set; }


        public string passwordPolicies { get; set; }
    }

    public class azureTableData : TableEntity
    {
        public DateTime TimeStamp { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public bool? IsActive { get; set; }


        public string Password { get; set; }


        public string ProfilePic { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    public class GetRequestClass
    {
        public List<object> businessPhones { get; set; }
        public string displayName { get; set; }
        public object givenName { get; set; }
        public object jobTitle { get; set; }
        public object mail { get; set; }
        public object mobilePhone { get; set; }
        public object officeLocation { get; set; }
        public object preferredLanguage { get; set; }
        public object surname { get; set; }
        public string userPrincipalName { get; set; }
        public string id { get; set; }
    }
}