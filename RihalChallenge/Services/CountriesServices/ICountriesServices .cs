using RihalChallenge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RihalChallenge.Services.CountriesServices
{
    public interface ICountriesServices
    {
        Task<bool> addedditdeleteDatacountries(countries countries, string code);
        List<countries> GetListofcountries();
        Task<bool> postRandomSeedDataFaker();
    }
}
