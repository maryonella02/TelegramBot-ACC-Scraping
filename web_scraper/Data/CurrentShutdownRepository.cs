using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_scraper.Models;

namespace web_scraper.Data
{
    public class CurrentShutdownRepository: ICurrentShutdownRepository
    {
        private readonly CurrentShutdownContext _context = null;

        public CurrentShutdownRepository(IOptions<Settings> settings)
        {
            _context = new CurrentShutdownContext(settings);
        }
        public async Task<IEnumerable<CurrentShutdown>> GetAllShutdowns()
        {
            return await _context.Shutdowns.Find(_ => true).ToListAsync();
        }
        public async Task<CurrentShutdown> GetCurrentShutdown(string id)
        {
            var filter = Builders<CurrentShutdown>.Filter.Eq("Id", id);
            return await _context.Shutdowns
                            .Find(filter)
                            .FirstOrDefaultAsync();
        }
        public async Task AddCurrentShutdown(CurrentShutdown item)
        {
            await _context.Shutdowns.InsertOneAsync(item);
        }

        public async Task<DeleteResult> RemoveCurrentShutdown(string id)
        {
            return await _context.Shutdowns.DeleteOneAsync(
                 Builders<CurrentShutdown>.Filter.Eq("Id", id));
        }

        public async Task<UpdateResult> UpdateCurrentShutdown(string id, string body)
        {
            var filter = Builders<CurrentShutdown>.Filter.Eq(s => s.Id, id);
            var update = Builders<CurrentShutdown>.Update
                            .Set(s => s.Body, body)
                            .CurrentDate(s => s.UpdatedOn);

            return await _context.Shutdowns.UpdateOneAsync(filter, update);
        }
    }
}
