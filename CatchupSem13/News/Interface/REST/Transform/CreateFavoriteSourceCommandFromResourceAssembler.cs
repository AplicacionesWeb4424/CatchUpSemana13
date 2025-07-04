using CatchupSem13.News.Domain.Model.Commands;
using CatchupSem13.News.Interface.REST.Resource;

namespace CatchupSem13.News.Interface.REST.Transform
{
    public static class CreateFavoriteSourceCommandFromResourceAssembler
    {
        public static CreateFavoriteSourceCommand ToCommandFromResource(CreateFavoriteSourceResource resource) => 
            new CreateFavoriteSourceCommand(resource.NewsApiKey, resource.sourceId);
        
    }
}
