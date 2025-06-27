using CatchupSem13.News.Domain.Model.Aggregates;
using CatchupSem13.News.Domain.Model.Commands;

namespace CatchupSem13.News.Domain.Services
{
    public interface IFavoriteSourceCommandService
    { 
        Task<FavoriteSource?> Handle(CreateFavoriteSourceCommand command);
    }
}
