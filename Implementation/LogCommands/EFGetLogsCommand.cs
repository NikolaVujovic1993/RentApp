using Application.Commands.LogCommands;
using Application.DataTransfer.ResponseDTO;
using Application.Searches;
using Domain;
using DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.LogCommands
{
    public class EFGetLogsCommand : BaseEFCommand, IGetLogsCommand
    {
        public EFGetLogsCommand(AIContext context) : base(context)
        {
        }

        public IEnumerable<Log> Execute(LogSearch request)
        {
            var query = AiContext.Logs
                .AsQueryable()
                .Where(u => u.IsDeleted == 0);
            var dateFrom = request.DateFrom;
            if(dateFrom != null)
            {
                var y = query.Select(u => u.CreatedAt);
                var oy = query.Select(u => u.CreatedAt.CompareTo(dateFrom)).FirstOrDefault();
                query = query
                    .Where(u => u.CreatedAt >= dateFrom );
            }
            var dateTo = request.DateTo;
            if (dateTo != null)
            {
                query = query
                    .Where(u => u.CreatedAt <= dateTo);
            }
            var action = request.Action;
            if(action != null && action != "" && !string.IsNullOrWhiteSpace(action))
            {
                query = query
                  .Where(u => u.Action.ToLower().Contains(action.ToLower()));
            }
            var username = request.Username;
            if (username != null && username != "" && !string.IsNullOrWhiteSpace(username))
            {
                query = query
                  .Where(u => u.User.Username.ToLower().Contains(username.ToLower()));
            }
            return query
                .Include(u => u.User);
        }
    }
}
