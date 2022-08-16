using LeonsList.Application.Features.Categories.Commands.CreateCategory;
using LeonsList.Application.Features.Categories.Commands.DeleteCategoryById;
using LeonsList.Application.Features.Categories.Commands.UpdateCategory;
using LeonsList.Application.Features.Categories.Queries.GetAllCategories;
using LeonsList.Application.Features.Categories.Queries.GetCategoryById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;



namespace LeonsList.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CategoryController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllCategoriesParameter filter)
        {

            return Ok(await Mediator.Send(new GetAllCategoriesQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetCategoryByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateCategoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateCategoryCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCategoryByIdCommand { Id = id }));
        }
    }
}
