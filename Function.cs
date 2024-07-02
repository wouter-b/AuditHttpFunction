using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AuditHttpFunction
{
    public class Function(ILogger<Function> logger, IAuditHttpService httpService)
    {
        [Function("Function1")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "buildings/{buildingId}/posts")] HttpRequest req, string buildingId)
        {
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var projectId = await GetProjectIdFromDbAsync(buildingId);

            var posts = await httpService.GetBuildingPostsAsync(buildingId);

            return new OkObjectResult(posts);
        }

        private async Task<string> GetProjectIdFromDbAsync(string buildingId)
        {
            return "123";
        }
    }
}
