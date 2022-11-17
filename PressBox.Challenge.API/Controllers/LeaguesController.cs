using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PressBox.Challenge.API.Model;
using PressBox.Challenge.Model.LeagueData;
using System.Net.Http.Headers;

namespace PressBox.Challenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaguesController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly EndpointConfiguration _endpointConfiguration;
        public LeaguesController(IHttpClientFactory httpFactory, IOptions<EndpointConfiguration> endpointConfigs)
        {
            _endpointConfiguration = endpointConfigs.Value;
            _httpClient = httpFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(_endpointConfiguration.BaseAddress);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<League>>> GetAll()
        {
            string url = $"{_httpClient.BaseAddress}leagues.json?{_endpointConfiguration.SasToken}";
            try
            {
                using (HttpResponseMessage response = await _httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var leagues = await response.Content.ReadAsAsync<List<League>>();

                        return Ok(leagues);
                    }
                }
            }
            catch
            {
                return BadRequest();
            }
            
            return NoContent();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<IEnumerable<Fixture>>> Get(int id = 8)
        {
            string url = $"{_httpClient.BaseAddress}leagues/{id}.json?{_endpointConfiguration.SasToken}";
            try
            {
                using (HttpResponseMessage response = await _httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var leagues = await response.Content.ReadAsAsync<List<Fixture>>();

                        return Ok(leagues);
                    }
                }
            }
            catch
            {
                return BadRequest();
            }

            return NoContent();
        }

    }
}
