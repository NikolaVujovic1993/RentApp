using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.UserCommands;
using Application.DataTransfer;
using Application.DataTransfer.ResponseDTO;
using Application.Searches;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Implementation.UserCommands
{
    public class EFGetUsersCommand : BaseEFCommand, IGetUsersCommand
    {
        public EFGetUsersCommand(AIContext context) : base(context)
        {
        }

        public IEnumerable<UserResponseDTO> Execute(UserSearch request)
        {
            var query = AiContext.Users
				.AsQueryable()
				.Where(u => u.IsDeleted == 0);
            var keyword = request.Keyword;
            if (keyword != null)
                query = query
                    .Where(u => u.Username.ToLower().Contains(keyword.ToLower()));
            return query
                .Include(u => u.Role)
                .Select(u => new UserResponseDTO
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Username = u.Username,
                    RoleId = u.RoleId,
                    RoleName = u.Role.Name
                });
        }
    }
}
