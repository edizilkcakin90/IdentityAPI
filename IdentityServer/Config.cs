using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource( "ApiName" )
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                        ClientId = "ClientId",
                        ClientSecrets = {
                            new Secret( "secret".Sha256() )
                        },
                        //http://docs.identityserver.io/en/latest/topics/grant_types.html
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        AllowedScopes = {
                            "ApiName"
                        },
                }
            };
        }

        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser>()
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "admin",
                    Password = "admin".Sha256()
                }
            };
        }
    }
} 