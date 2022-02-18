using UserManager.Services.Models;

namespace UserManager.Services.IServices
{
    public interface IHubConnectionService
    {
        public void AddToCache(HubConnectionModel model);

        public string GetFromCache(int userId);

    }
}
