﻿using CleanArch.Application.Permissions;
using CleanArch.Application.Users.Commands.AddRole;
using CleanArch.Application.Users.Commands.ChangePassword;
using CleanArch.Application.Users.Commands.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArch.WebAPI.Controllers
{
    public class UserController : BaseController
    {
        [Authorize(Policy = Permission.Users.Create)]
        [HttpPost]
        public async Task<ActionResult<bool>> Create([FromBody] CreateUserCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [Authorize(Policy = Permission.Roles.Edit)]
        [HttpPost]
        public async Task<ActionResult<bool>> AddRole([FromBody] AddRoleToUserCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [Authorize(Policy = Permission.Roles.Edit)]
        [HttpPost]
        public async Task<ActionResult<bool>> AdminChnagePassword([FromBody] AdminChangePasswordCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
