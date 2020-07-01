using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.RoleCommands;
using Application.DataTransfer;
using Application.DataTransfer.RequestDTO;
using Application.DataTransfer.ResponseDTO;
using Application.Exceptions;
using DomainModels;
using Domain;

namespace Implementation.RoleCommands
{
    public class EFInsertRoleCommand : BaseEFCommand, IInsertRoleCommand
    {
        public EFInsertRoleCommand(AIContext context) : base(context)
        {
        }

        public RoleResponseDTO Execute(RoleRequestDTO request)
        {
            var role = new Role();          
			var roleExists = AiContext.Roles
				.Where(x => x.Name == request.Name)
				.Where(x => x.IsDeleted == 0)
				.FirstOrDefault();
			if (roleExists != null)
				throw new EntityExistsException("Role with that name");
			role.Name = request.Name;
			AiContext.Roles.Add(role);
			AiContext.SaveChanges();
            return new RoleResponseDTO
            {
                Id = role.Id,
                Name = role.Name
            };
        }
    }
}
