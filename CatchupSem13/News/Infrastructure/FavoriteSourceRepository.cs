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
    }
}
