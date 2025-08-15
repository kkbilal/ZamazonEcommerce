// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace Zamazon.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog"){Scopes = {"CatalogFullPermission","CatalogReadPermission"}},
            new ApiResource("ResourceDiscount"){Scopes = { "DiscountFullPermission"}},
            new ApiResource("ResourceOrder"){Scopes = {"OrderFullPermission"}},
            new ApiResource("ResourceCargo"){Scopes = {"CargoFullPermission"}},

        };
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
         {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
         };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("CatalogFullPermission","Full Authority for Catalog operations"),
                new ApiScope("CatalogReadPermission","Read Authority for Catalog operations"),
                new ApiScope("DiscountFullPermission","Full Authority for Discount operations"),
                new ApiScope("OrderFullPermission","Full Authority for Order operations"),
                new ApiScope("CargoFullPermission","Full Authority for Cargo operations"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName, "Local API Scope")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // Visitor Client
                new Client
                {
                    ClientId = "ZamazonVisitorId",
                    ClientName = "Zamazon Visitor User",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("zamazonsecret".Sha256()) },

                    AllowedScopes = { "CatalogReadPermission" }
                },
                // Manager Client
                new Client
                {
                    ClientId = "ZamazonManagerId",
                    ClientName = "Zamazon Manager User",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("zamazonsecret".Sha256()) },

                    AllowedScopes = { "CatalogFullPermission", "CatalogReadPermission" }
                },
                // Admin Client
                new Client
                {
                    ClientId = "ZamazonAdminId",
                    ClientName = "Zamazon Admin User",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("zamazonsecret".Sha256()) },

                    AllowedScopes = { "CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission",
                        "CatalogReadPermission",
                        "CargoFullPermission",
                        IdentityServerConstants.LocalApi.ScopeName,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile
                    },

                    AccessTokenLifetime= 600 // 10 minutes
                }

            };
    }
}