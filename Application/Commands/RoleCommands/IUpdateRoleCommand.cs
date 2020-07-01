using Application.DataTransfer;
using Application.DataTransfer.RequestDTO;
using Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.RoleCommands
{
    public interface IUpdateRoleCommand : IUpdate<int, RoleRequestDTO>
    {
    }
}
