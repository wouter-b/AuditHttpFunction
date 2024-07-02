using Microsoft.Extensions.Logging;

namespace AuditHttpFunction
{
    internal interface IAuditHttpClient
    {
        Task<string> GetBuildingPostsAsync(string buildingId);
    }

    internal class AuditHttpClient(ILogger<AuditHttpClient> logger, HttpClient httpClient) : IAuditHttpClient
    {
        public async Task<string> GetBuildingPostsAsync(string buildingId)
        {
            var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
