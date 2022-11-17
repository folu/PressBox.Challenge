using Microsoft.Extensions.Options;
using PressBox.Challenge.Model;
using PressBox.Challenge.Model.BrandData;
using PressBox.Challenge.Model.LeagueData;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace PressBox.Challenge.Services
{
    public class PressBoxService : IPressBoxService
    {
        private readonly HttpClient _httpClient;
        private readonly LocalApiConfiguration _localApiConfiguration;
        public PressBoxService(IHttpClientFactory httpFactory, IOptions<LocalApiConfiguration> localApiConfig)
        {
            _localApiConfiguration = localApiConfig.Value;
            _httpClient = httpFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(_localApiConfiguration.url);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<League>> GetAllLeagues()
        {
            try
            {
                var leagues = await _httpClient.GetFromJsonAsync<List<League>>("api/Leagues");
                return leagues;
            }
            catch (Exception ex)
            {
                var test = ex.ToString();
                //add a logger here
            }
            return new List<League>();
        }

        public async Task<List<Fixture>> GetFixtures(int leagueId)
        {
            try
            {
                var fixtures = await _httpClient.GetFromJsonAsync<List<Fixture>>($"api/Leagues/{leagueId}");
                return fixtures;
            }
            catch (Exception ex)
            {
                var test = ex.ToString();
                //add a logger here
            }
            return new List<Fixture>();
        }

        public async Task<List<Brand>> GetAllBrands()
        {
            try
            {
                var brands = await _httpClient.GetFromJsonAsync<List<Brand>>("api/Brands");
                return brands;
            }
            catch (Exception ex)
            {
                var test = ex.ToString();
                //add a logger here
            }
            return new List<Brand>();
        }

        public async Task<List<BrandDetails>> GetBrand(int brandId)
        {
            try
            {
                var brandDetails = await _httpClient.GetFromJsonAsync<List<BrandDetails>>($"api/Brands/{brandId}");
                return brandDetails;
            }
            catch (Exception ex)
            {
                var test = ex.ToString();
                //add a logger here
            }
            return new List<BrandDetails>();
        }
    }
}
