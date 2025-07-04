using CatchupSem13.Shared.Infrastructure.Persistence.EFC.Configuration;
using CatchupSem13.Shared.Infrastructure.Persistence.EFC.Repositories;
using CatchupSem13.News.Domain.Model.Aggregates;
using CatchupSem13.News.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace CatchupSem13.News.Infrastructure
{
    public class FavoriteSourceRepository(AppDbContext context) : BaseRepository<FavoriteSource>(context), IFavoriteSourceRepository
    {
        /// <inheritdoc />
        public async Task<FavoriteSource?> FindByNewsApiKeyAndSourceIdAsync(string newsApiKey, string sourceId)
        {
            return await Context.Set<FavoriteSource>().FirstOrDefaultAsync(f => f.NewsApiKey == newsApiKey && f.SourceId == sourceId);
        }
        public async Task<FavoriteSource> FindBySourceIdAsync(string sourceId)
        {
            return await Context.Set<FavoriteSource>().FirstOrDefaultAsync(f => f.SourceId == sourceId)
                   ?? throw new KeyNotFoundException($"No favorite source found with Source ID: {sourceId}");
        }

        public async Task<FavoriteSource> FindByNewsApiKeyAsync(string NewsApiKey)
        {
            return await Context.Set<FavoriteSource>().FirstOrDefaultAsync(f => f.SourceId == NewsApiKey)
                   ?? throw new KeyNotFoundException($"No favorite source found with Source ID: {NewsApiKey}");
        }



    }
}
