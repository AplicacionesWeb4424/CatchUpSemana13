using CatchupSem13.News.Domain.Model.Aggregates;
using CatchupSem13.Shared.Domain.Repositories;

namespace CatchupSem13.News.Domain.Repository
{
    public interface IFavoriteSourceRepository : IBaseRepository<FavoriteSource>
    {

        /// <summary>
        /// Find a favorite source by News API Key and Source ID 
        /// </summary>
        /// <param name="newsApiKey">The News API Key</param>
        /// <param name="sourceId">The Source ID</param>
        /// <returns>
        /// The favorite source object if found, or null otherwise.
        /// </returns>
        Task<FavoriteSource?> FindByNewsApiKeyAndSourceIdAsync(string newsApiKey, string sourceId);


        /// <summary>
        /// Find a favorite source by Source ID 
        /// </summary>
        /// <param name="newsApiKey">The News API Key</param>
        /// <param name="sourceId">The Source ID</param>
        /// <returns>
        /// The favorite source object if found, or null otherwise.
        /// </returns>
        Task<FavoriteSource> FindBySourceIdAsync(string sourceId);

        Task<FavoriteSource> FindByNewsApiKeyAsync(string NewsApiKey);

    }
}
