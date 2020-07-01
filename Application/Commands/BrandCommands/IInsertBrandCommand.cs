using Application.DataTransfer.RequestDTO;
using Application.DataTransfer.ResponseDTO;
using Application.Intefaces;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.BrandCommands
{
    public interface IInsertBrandCommand : ICommand<BrandRequestDTO, Brand>
    {
    }
}
