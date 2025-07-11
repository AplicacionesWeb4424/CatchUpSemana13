﻿using CatchupSem13.News.Domain.Model.Aggregates;
using CatchupSem13.News.Interface.REST.Resource;

namespace CatchupSem13.News.Interface.REST.Transform
{
    public static class FavoriteSourceResourceFromEntityAssembler
    {
        public static FavoriteSourceResource ToResourceFromEntity(FavoriteSource entity) =>
          new FavoriteSourceResource(entity.Id, entity.NewsApiKey, entity.SourceId);
    
    }
}
