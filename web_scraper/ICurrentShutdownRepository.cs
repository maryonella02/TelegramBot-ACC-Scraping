using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_scraper.Models;

namespace web_scraper
{
    interface ICurrentShutdownRepository
    {
        Task<IEnumerable<CurrentShutdown> GetAllShutdowns();
        Task<CurrentShutdown> GetCurrentShutdown(string id);
        Task AddCurrentShutdown(CurrentShutdown item);
        Task<DeleteResult> RemoveCurrentShutdown(string id);
        // обновление содержания (body) записи
        Task<UpdateResult> UpdateCurrentShutdown(string id, string body);

    }
}
