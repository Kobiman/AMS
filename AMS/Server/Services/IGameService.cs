using AMS.Shared;
using AMS.Shared.Dto;

namespace AMS.Server.Services
{
    public interface IGameService
    {
        public Task<Game> AddGame(Game game);
        public Task<IEnumerable<Game>> GetAllGames();
        public Task<Game> GetUpdateGame(Game game);
        public Task<Game> DeleteGame(int gameId);    
    }
}
