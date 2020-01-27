using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Roles.Commands.Create
{
    public class CreateRoleCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}
