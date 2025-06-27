using CatchupSem13.News.Domain.Model.Aggregates;
using CatchupSem13.News.Domain.Model.Commands;
using CatchupSem13.News.Domain.Repository;
using CatchupSem13.News.Domain.Services;
using CatchupSem13.Shared.Domain.Repositories;

namespace CatchupSem13.News.Application.Internal.CommandServices
{
    public class FavoriteSourceCommandService(IFavoriteSourceRepository favoriteSourceRepository, IUnitOfWork unitOfWork)
     : IFavoriteSourceCommandService
    {
        /// <inheritdoc />
        public async Task<FavoriteSource?> Handle(CreateFavoriteSourceCommand command)
        {
            var favoriteSource =                                               
                await favoriteSourceRepository.FindByNewsApiKeyAndSourceIdAsync(command.NewsApiKey, command.SourceId);
            if (favoriteSource != null)
                throw new Exception("Favorite source with this SourceId already exists for the given NewsApiKey");
            
            favoriteSource = new FavoriteSource(command);

            try
            {
                await favoriteSourceRepository.AddAsync(favoriteSource);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                return null;
            }

            return favoriteSource;
        }
    }
}
