using Application.DataTransfer.ResponseDTO;
using Application.Intefaces;
using Application.Searches;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.LogCommands
{
    public interface IGetLogsCommand : ICommand<LogSearch, IEnumerable<Log>>
    {
    }
}
