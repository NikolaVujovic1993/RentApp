using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.LogCommands;
using Application.DataTransfer.ResponseDTO;
using Application.Searches;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly IGetLogsCommand _getLogsCommand;
        private readonly IMapper _mapper;

        public LogsController(IGetLogsCommand getLogsCommand, IMapper mapper)
        {
            _getLogsCommand = getLogsCommand ?? throw new ArgumentNullException(nameof(getLogsCommand));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<LogResponseDTO>> Get([FromQuery] LogSearch search)
        {
            try
            {
                var logs = _getLogsCommand.Execute(search);

                var logResponse = _mapper.Map<IEnumerable<LogResponseDTO>>(logs);

                return Ok(logResponse);
            }
            catch (Exception)
            {
                return StatusCode(500, "Server error");
            }
        }
    }
}
