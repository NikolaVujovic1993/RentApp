﻿using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Application.Commands.UserCommands;
using Application.DataTransfer.RequestDTO;
using Application.Exceptions;

namespace Implementation.UserCommands
{
	public class EFUserUpdatePasswordCommand : BaseEFCommand, IUpdateUserPasswordCommand
	{
		public EFUserUpdatePasswordCommand(AIContext context) : base(context)
		{
		}

		public void Execute(int request, UserUpdatePasswordRequest pass)
		{
			var user = AiContext.Users.Find(request);
			if (user == null || user.IsDeleted == 1)
				throw new EntityNotFoundException("User");
			user.Password = pass.Password;
			user.ModifiedAt = DateTime.Now;
			AiContext.SaveChanges();
		}
	}
}
