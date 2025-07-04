using CatchupSem13.News.Domain.Model.Aggregates;
using CatchupSem13.News.Domain.Model.Commands;
using CatchupSem13.News.Domain.Model.Queries;
using CatchupSem13.News.Domain.Repository;
using CatchupSem13.News.Domain.Services;
using CatchupSem13.Shared.Domain.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace CatchupSem13.News.Application.Internal.QueryServices
{
    public class FavoriteSourceQueryService(IFavoriteSourceRepository favoriteSourceRepository, IUnitOfWork unitOfWork) :
        IFavoriteSourceQueryService
    {
        public async Task<FavoriteSource?> Handle(GetFavoriteSourceByIdQuery Query)
        {
            var favoriteSource =
                await favoriteSourceRepository.FindBySourceIdAsync(Query.SourcedId);

            if (favoriteSource is null)
                throw new Exception("Favorite source with this SourceId doesnt exists");

            return favoriteSource;
        }

        public async Task<FavoriteSource?> Handle(GetAllFavoriteSourcesByNewsApiKeyQuery Query)
        {
            var favoriteSource =
                await favoriteSourceRepository.FindByNewsApiKeyAsync (Query.NewsapiKey);

            if (favoriteSource is null)
                throw new Exception("Favorite source with this SourceId and NewsApiKey doesnt exists");

            return favoriteSource;
        }
                                             
        public async Task<FavoriteSource> Handle(GetFavoriteSourceByNewsApiKeyAndSourceIdQuery query)
        { var favoriteSource = await favoriteSourceRepository.FindByNewsApiKeyAndSourceIdAsync(query.NewsapiKey, query.SourceId);

            if (favoriteSource is null)
                throw new Exception("Favorite source with this SourceId and NewsApiKey doesnt exists");
            return favoriteSource;
        }

    }
}
