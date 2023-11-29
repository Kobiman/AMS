using AMS.Server.Data;
using AMS.Shared;
using AMS.Shared.Dto;
using Microsoft.EntityFrameworkCore;

namespace AMS.Server.Services
{
    public class GameService : IGameService
    {
        private readonly ApplicationDbContext dbContext;
        public GameService(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<Game> AddGame(Game game)
        {
            var originalGame = dbContext.Games.FirstOrDefault(x => x.Name == game.Name);
            if (originalGame != null)
            {
                return null;
            }
            dbContext.Games.Add(game);
            var result = await dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return game;
            }
            return null; 
        }

        public Task<Game> DeleteGame(int gameId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Game>> GetAllGames()
        {
            return await dbContext.Games.Where(x => x.Srl.HasValue)
                .OrderBy(x => x.Srl)
                .ToListAsync();
        }

        public Task<Game> GetUpdateGame(Game game)
        {
            throw new NotImplementedException();
        }

        public async Task<Game> GetGameById(string gameId)
        {
            return await dbContext.Games.FirstOrDefaultAsync(x => x.Id == gameId);
        }

        public async Task<Game> UpdateGame(Game game)
        {
            dbContext.Games.UpdateRange(game);
            var result = await dbContext.SaveChangesAsync();
            if (result > 0)
                return game;
            else
                return new Game();
        }
    }
}
