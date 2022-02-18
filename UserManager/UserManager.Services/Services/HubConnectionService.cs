using Microsoft.Extensions.Caching.Memory;
using System;
using UserManager.Services.IServices;
using UserManager.Services.Models;

namespace UserManager.Services.Services
{
    public class HubConnectionService : IHubConnectionService
    {
        private IMemoryCache cache;

        public HubConnectionService(IMemoryCache memoryCache)
        {
            cache = memoryCache;
        }

        public void AddToCache(HubConnectionModel model)
        {
            cache.Set(model.UserId, model.ConnectionId, TimeSpan.FromDays(5));
        }

        public string GetFromCache(int userId)
        {
            return cache.Get(userId).ToString();
        }
    }
}
