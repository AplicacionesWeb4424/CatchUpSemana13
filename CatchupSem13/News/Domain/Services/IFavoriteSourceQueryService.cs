using CatchupSem13.News.Domain.Model.Aggregates;
using CatchupSem13.News.Domain.Model.Commands;
using CatchupSem13.News.Domain.Model.Queries;

namespace CatchupSem13.News.Domain.Services
{
    public interface IFavoriteSourceQueryService
    {
        Task<FavoriteSource?> Handle(GetFavoriteSourceByIdQuery query);

        Task<FavoriteSource> Handle(GetAllFavoriteSourcesByNewsApiKeyQuery query);

        Task<FavoriteSource> Handle(GetFavoriteSourceByNewsApiKeyAndSourceIdQuery query);

    }
}
