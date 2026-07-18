using Catalog.Application.Commands;
using Catalog.Application.DTOs.TypeDTOs;
using Catalog.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllType")]
        public async Task<IActionResult> GetAllType()
        {
            var query = new GetAllTypeQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetTypeById/{Id:Guid}")]
        public async Task<IActionResult> GetTypeById(Guid Id)
        {
            var query = new GetTypeByIdQuery(Id);
            var result = await this._mediator.Send(query);

            return Ok(result);
        }
        [HttpPost]
        [Route("CreateType")]
        public async Task<IActionResult> CreateType(string TypeName)
        {
            var command = new CreateTypeCommand();
            command.Name = TypeName;
            var result = await _mediator.Send(command);
            return Ok(result);

        }

        [HttpDelete]
        [Route("DeleteType")]
        public async Task<IActionResult> DeleteType(Guid Id)
        {
            var command = new DeleteTypeByIdCommand(Id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateType")]
        public async Task<IActionResult> UpdateType(UpdateTypeDTO updateTypeDTO)
        {
            var command = new UpdateTypeCommand() 
            {
                id = updateTypeDTO.Id,
                name = updateTypeDTO.TypeName
            };
           
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
