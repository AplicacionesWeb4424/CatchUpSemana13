using CatchupSem13.News.Application.Internal.QueryServices;
using CatchupSem13.News.Domain.Model.Queries;
using CatchupSem13.News.Domain.Services;
using CatchupSem13.News.Interface.REST.Resource;
using CatchupSem13.News.Interface.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace CatchupSem13.News.Interface.REST
{

    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [SwaggerTag("Available FavoriteSource Endpoints")]
    public class FavoriteSourceController(IFavoriteSourceCommandService FavoriteSourceCommandService, IFavoriteSourceQueryService FavoriteSourceQueryService) : ControllerBase
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

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get a favorite source by Id ",
            Description = "Get a favorite source with a given Source ID",
            OperationId = "GetFavoriteSourceById")
            ]
        [SwaggerResponse(200, "The favorite source was found", typeof(FavoriteSourceResource))]
        public async Task<IActionResult> GetFavoriteSourceById(string id)
        {
            var getFavoriteSourceByIdQuery = new GetFavoriteSourceByIdQuery(id);
            var result = await FavoriteSourceQueryService.Handle(getFavoriteSourceByIdQuery);
            if (result is null) return NotFound();
            var resource = FavoriteSourceResourceFromEntityAssembler.ToResourceFromEntity(result);

            return Ok(resource);
        }
        /*Swashbuckle.AspNetCore.SwaggerGen.SwaggerGeneratorException: Ambiguous HTTP method for action - CatchupSem13.News.Interface.REST.FavoriteSourceController.GetfavoriteSourceByNewsApiKey (CatchupSem13). Actions require an explicit HttpMethod binding for Swagger/OpenAPI 3.0
*/
        [HttpGet]
        [SwaggerOperation(
            Summary = "Get a favorite source by Id and New Api Key ",
            Description = "Get a favorite source with a given Source ID or New Api Key",
            OperationId = "GetFavoriteSourceFromQuery")
            ]
        [SwaggerResponse(200, "The favorite source was found", typeof(FavoriteSourceResource))]
        public async Task<ActionResult> GetFavoriteSourceFromQuery([FromQuery] string newsApiKey, [FromQuery] string sourceId)
        { 
            return  string.IsNullOrEmpty(sourceId) 
                ? await GetfavoriteSourceByNewsApiKey(newsApiKey)
                : await GetfavoriteSourceByNewsApiKeyAndSourceId(newsApiKey, sourceId);

        }
        private async Task<ActionResult> GetfavoriteSourceByNewsApiKey(string newsApiKey)
        {
            var getAllFavoriteSourcesByNewsApiKeyQuery = new GetAllFavoriteSourcesByNewsApiKeyQuery(newsApiKey);
            var result = await FavoriteSourceQueryService.Handle(getAllFavoriteSourcesByNewsApiKeyQuery);
            if (result is null) return NotFound();
            var resource = FavoriteSourceResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resource);
        }

        private async Task<ActionResult> GetfavoriteSourceByNewsApiKeyAndSourceId(string newsApiKey, string SourceId)
        {
            var getFavoriteSourceByNewsApiKeyAndSourceIdQuery = new GetFavoriteSourceByNewsApiKeyAndSourceIdQuery(newsApiKey, SourceId);
            var result = await FavoriteSourceQueryService.Handle(getFavoriteSourceByNewsApiKeyAndSourceIdQuery);
            if (result is null) return NotFound();
            var resource = FavoriteSourceResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resource);
        }

    }
}
