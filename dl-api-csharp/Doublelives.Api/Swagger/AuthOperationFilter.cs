﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Doublelives.Api.Swagger
{
    public class AuthOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var isAuthorized = (context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>()
                                    .Any() ||
                                context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any()) &&
                               !context.MethodInfo.GetCustomAttributes(true).OfType<AllowAnonymousAttribute>().Any() &&
                               !context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                                   .OfType<AllowAnonymousAttribute>().Any();

            if (!isAuthorized) return;

            operation.Responses.TryAdd("401", new OpenApiResponse {Description = "Unauthorized"});
            operation.Responses.TryAdd("403", new OpenApiResponse {Description = "Forbidden"});

            var jwtbearerScheme = new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                    {Type = ReferenceType.SecurityScheme, Id = JwtBearerDefaults.AuthenticationScheme}
            };

            operation.Security = new List<OpenApiSecurityRequirement>
            {
                new OpenApiSecurityRequirement
                {
                    [jwtbearerScheme] = Array.Empty<string>()
                }
            };
        }
    }
}