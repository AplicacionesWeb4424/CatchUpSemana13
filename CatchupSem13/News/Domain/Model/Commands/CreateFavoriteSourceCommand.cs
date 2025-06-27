namespace CatchupSem13.News.Domain.Model.Commands;
public record CreateFavoriteSourceCommand(string NewsApiKey, string SourceId);