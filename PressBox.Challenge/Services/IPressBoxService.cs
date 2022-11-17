using PressBox.Challenge.Model.BrandData;
using PressBox.Challenge.Model.LeagueData;

namespace PressBox.Challenge.Services
{
    public interface IPressBoxService
    {
        Task<List<Brand>> GetAllBrands();
        Task<List<League>> GetAllLeagues();
        Task<List<BrandDetails>> GetBrand(int brandId);
        Task<List<Fixture>> GetFixtures(int leagueId);
    }
}