using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Contract
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root ;

        public static class Users
        {
            public const string QueryAll = Base + "/users";
            public const string QueryById = Base + "/users/{id:Guid}";


            public const string EditeInfo = Base + "/users/{id:Guid}";
            public const string Unregister = Base + "/users/{id:Guid}/unregister";
            public const string Register = Base + "/users";
        }

        public static class Identity
        {
            public const string SignIn = Base + "/identity/signin";

            public const string Refresh = Base + "/identity/refresh";

            public const string SignOut = Base + "/identity/{id:Guid}/signout";

            public const string ChangePassword = Base + "/identity/{id:Guid}/changepassword";
        }
        public static class Features
        {
            public const string QueryAll = Base + "/features";

            public const string EditInfo = Base + "/features/{id:Guid}";

            public const string Remove = Base + "/features/{id:Guid}/remove";

            public const string QueryById = Base + "/features/{id:Guid}";

            public const string Create = Base + "/features";

            public const string Deactivate = Base + "/features/{id:Guid}/deactivate";

        }
        public static class Permissions
        {
            public const string QueryAll = Base + "/permissions";

            public const string Edit = Base + "/permissions/{id:Guid}";

            public const string Remove = Base + "/permissions/{id:Guid}/remove";

            public const string QueryById = Base + "/permissions/{id:Guid}";

            public const string Create = Base + "/permissions";

            public const string Deactivate = Base + "/permissions/{id:Guid}/deactivate";

        }


    }
}
