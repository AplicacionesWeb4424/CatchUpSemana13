using CatchupSem13.News.Domain.Services;
using CatchupSem13.News.Interface.Resource;
using CatchupSem13.News.Interface.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace CatchupSem13.News.Interface.REST
{

    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [SwaggerTag("Available FavoriteSource Endpoints")]
    public class FavoriteSourceController(IFavoriteSourceCommandService FavoriteSourceCommandService) : ControllerBase
    {

        /// <summary>
        /// Creates a favorite source. 
        /// </summary>
        /// <param name="resource">CreateFavoriteSourceResource resource</param>
        /// <returns>
        /// A response as an action result containing the created favorite source, or bad request if the favorite source was not created.
        /// </returns>
        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates a favorite source ",
            Description = "Creates a favorite source with a given News API Key and Source ID",
            OperationId = "CreateFavoriteSource")]
        [SwaggerResponse(201, "The favorite source was created", typeof(FavoriteSourceResource))]
        [SwaggerResponse(400, "The favorite source was not created")]
        public async Task<IActionResult> CreateFavoriteSource([FromBody] CreateFavoriteSourceResource resource)
        {
            var  createFavoriteSourceCommand= CreateFavoriteSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await FavoriteSourceCommandService.Handle(createFavoriteSourceCommand);
            if (result is null) return BadRequest();
            return CreatedAtAction("nameof(GetFavoriteSourceById)", new { id = result.Id }, FavoriteSourceResourceFromEntityAssembler.ToResourceFromEntity(result));

        }
    }
}
