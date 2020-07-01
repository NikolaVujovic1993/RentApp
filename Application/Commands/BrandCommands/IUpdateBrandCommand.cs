using Application.DataTransfer.RequestDTO;
using Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.BrandCommands
{
    public interface IUpdateBrandCommand : IUpdate<int, BrandRequestDTO>
    {
    }
}
