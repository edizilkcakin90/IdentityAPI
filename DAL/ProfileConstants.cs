using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public static class ClaimConstants
    {
        ///<summary>A claim that specifies the subject of an entity</summary>
        public const string Subject = "sub";

        ///<summary>A claim that specifies the permission of an entity</summary>
        public const string Permission = "permission";
    }



    public static class PropertyConstants
    {

        ///<summary>A property that specifies the full name of an entity</summary>
        public const string Name = "name";

        ///<summary>A property that specifies the job title of an entity</summary>
        public const string Email = "email";

        ///<summary>A property that specifies the configuration/customizations of an entity</summary>
        
    }



    public static class ScopeConstants
    {
        ///<summary>A scope that specifies the roles of an entity</summary>
        public const string Roles = "roles";
    }
}
