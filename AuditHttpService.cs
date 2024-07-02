using Microsoft.Extensions.Logging;

namespace AuditHttpFunction
{
    public interface IAuditHttpService
    {
        Task<string> GetBuildingPostsAsync(string buildingId);
    }

    internal class AuditHttpService(ILogger<AuditHttpService> logger, IAuditHttpClient httpClient) : IAuditHttpService
    {
        public async Task<string> GetBuildingPostsAsync(string buildingId)
        {
            return await httpClient.GetBuildingPostsAsync(buildingId);
        }
    }
}
