using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PressBox.Challenge.API.Model;
using PressBox.Challenge.Model.BrandData;
using System.Net.Http.Headers;

namespace PressBox.Challenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly EndpointConfiguration _endpointConfiguration;
        public BrandsController(IHttpClientFactory httpFactory, IOptions<EndpointConfiguration> endpointConfigs)
        {
            _endpointConfiguration = endpointConfigs.Value;
            _httpClient = httpFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(_endpointConfiguration.BaseAddress);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetAll()
        {
            string url = $"{_httpClient.BaseAddress}brands.json?{_endpointConfiguration.SasToken}";
            try
            {
                using (HttpResponseMessage response = await _httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var Brands = await response.Content.ReadAsAsync<List<Brand>>();

                        return Ok(Brands);
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
        public async Task<ActionResult<IEnumerable<Brand>>> Get(int id = 1)
        {
            string url = $"{_httpClient.BaseAddress}brands/{id}.json?{_endpointConfiguration.SasToken}";
            try
            {
                using (HttpResponseMessage response = await _httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var leagues = await response.Content.ReadAsAsync<List<BrandDetails>>();

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
