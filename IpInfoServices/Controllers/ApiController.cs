using IpInfoServices.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;

namespace IpInfoServices.Controllers
{
    public class ApiController : ControllerBase
    {
        private readonly ApiDbContext _dbContext;

        public ApiController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("api/{ipAddress}")]
        public async Task<IActionResult> GetIpAddressInfo(string ipAddress)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://ipinfo.io/{ipAddress}/geo");
            var content = await response.Content.ReadAsStringAsync();

            var request = new Request
            {
                IpAddress = ipAddress,
                RequestTime = DateTime.Now
            };
            _dbContext.Requests.Add(request);
            await _dbContext.SaveChangesAsync();

            return Ok(content);
        }
    }
}
