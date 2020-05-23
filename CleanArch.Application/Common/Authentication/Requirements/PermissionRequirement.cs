﻿using Microsoft.AspNetCore.Authorization;
namespace CleanArch.Application.Common.Authentication.Requirements
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string Permission { get; private set; }

        public PermissionRequirement(string permission)
        {
            Permission = permission;
        }
    }
}
