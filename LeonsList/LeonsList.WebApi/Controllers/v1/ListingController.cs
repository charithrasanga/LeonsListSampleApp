using LeonsList.Application.Features.Listings.Commands.CreateListing;
using LeonsList.Application.Features.Listings.Commands.DeleteListingById;
using LeonsList.Application.Features.Listings.Commands.UpdateListing;
using LeonsList.Application.Features.Listings.Queries.GetAllListings;
using LeonsList.Application.Features.Listings.Queries.GetListingById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;



namespace LeonsList.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ListingController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllListingsParameter filter)
        {

            return Ok(await Mediator.Send(new GetAllListingsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetListingByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromForm] CreateListingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // POST api/<controller>
        [HttpPost]
        [AllowAnonymous]
        [Route("CreateAnonymousListing")]
        public async Task<IActionResult> PostAnonymous([FromForm] CreateAnonymousListingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateListingCommand command)
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
            return Ok(await Mediator.Send(new DeleteListingByIdCommand { Id = id }));
        }
    }
}
