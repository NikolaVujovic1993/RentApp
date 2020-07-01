﻿using Application.DataTransfer;
using Application.DataTransfer.ResponseDTO;
using Application.Intefaces;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.RoleCommands
{
    public interface IGetRoleCommand : ICommand<RoleSearch, IEnumerable<RoleResponseDTO>>
    {
    }
}
