using LeonsList.Application.Features.Categories.Queries.GetPictureById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;



namespace LeonsList.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [AllowAnonymous]
    public class PicturesController : BaseApiController
    {
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public FileContentResult Get(int id)
        {


            var imageData = Mediator.Send(new GetPictureByIdQuery { Id = id }).Result;

            return File(imageData.Data.Content, "image/png");


        }
   
    }
}
