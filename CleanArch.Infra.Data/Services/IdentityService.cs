using CleanArch.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace CleanArch.Infra.Data.Services
{
    public class IdentityService : IIdentityService
    {
        private IHttpContextAccessor _context;

        public IdentityService(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public string UserIdentity
        {
            get => _context.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public string UserName
        {
            get => _context.HttpContext.User.Identity.Name;
        }

        public string Language
        {
            get => _context.HttpContext?.Request?.Headers?["content-language"];
        }
    }
}
