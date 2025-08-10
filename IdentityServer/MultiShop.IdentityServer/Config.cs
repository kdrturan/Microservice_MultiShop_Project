// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog"){Scopes = {"CatalogFullPermission", "CatalogReadPermission"}},
            new ApiResource("ResourceDiscount"){Scopes = {"DiscountFullPermission"}},
            new ApiResource("ResourceOrder"){Scopes = {"OrderFullPermission"}},
            new ApiResource("ResourceCargo"){Scopes = {"CargoFullPermission"}},
            new ApiResource("ResourceBasket"){Scopes = {"BasketFullPermission"}},
            new ApiResource("ResourceOcelot"){Scopes = {"OcelotFullPermission"}},
            new ApiResource("ResourceComment"){Scopes = {"CommentFullPermission"}},
                        new ApiResource("ResourcePayment"){Scopes = {"PaymentFullPermission"}},
                                                new ApiResource("ResourceImage"){Scopes = {"ImageFullPermission"}},

            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
        };

        public static  IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission", "Full access to Catalog API"),
            new ApiScope("CatalogReadPermission", "Read access to Catalog API"),
            new ApiScope("DiscountFullPermission", "Full access to Discount API"),
            new ApiScope("OrderFullPermission", "Full access to Order API"),
            new ApiScope("CargoFullPermission", "Full access to Cargo API"),
            new ApiScope("BasketFullPermission", "Full access to Basket API"),
            new ApiScope("OcelotFullPermission", "Full access to Ocelot API"),
            new ApiScope("CommentFullPermission", "Full access to Comment API"),
                        new ApiScope("PaymentFullPermission", "Full access to Payment API"),
                                                new ApiScope("ImageFullPermission", "Full access to Image API"),

            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)

        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor
            new Client
            {
                ClientId = "MultiShopVisitorId",
                ClientName = "MultiShop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("MultiShopSecret".Sha256()) },
                AllowedScopes = { "OrderFullPermission", "CatalogFullPermission", "OcelotFullPermission", "CommentFullPermission" , "PaymentFullPermission" , "ImageFullPermission" }
            },

            //Manager
            new Client
            {
                ClientId = "MultiShopManagerId",
                ClientName = "MultiShop Manager User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = { new Secret("MultiShopSecret".Sha256()) },
                AllowedScopes = { "OrderFullPermission","CatalogFullPermission", "DiscountFullPermission", "OcelotFullPermission","BasketFullPermission", "CommentFullPermission" , "PaymentFullPermission", "ImageFullPermission", IdentityServerConstants.LocalApi.ScopeName,IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.Profile,IdentityServerConstants.StandardScopes.OpenId}
            },


            //Admin
            new Client
            {
                ClientId = "MultiShopAdminId",
                ClientName = "MultiShop Admin User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = { new Secret("MultiShopSecret".Sha256()) },
                AllowedScopes = { "CatalogFullPermission","PaymentFullPermission", "ImageFullPermission", "CommentFullPermission", "OcelotFullPermission" , "DiscountFullPermission", "OrderFullPermission", "CargoFullPermission","BasketFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName,IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.Profile,IdentityServerConstants.StandardScopes.OpenId },
                AccessTokenLifetime = 300, // 5 minutes
            }
        };
    }
}