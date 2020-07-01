using Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;
using Application.DataTransfer.RequestDTO;

namespace Application.Commands.UserCommands
{
	public interface IUpdateUserPasswordCommand : IUpdate<int, UserUpdatePasswordRequest>
	{
	}
}
