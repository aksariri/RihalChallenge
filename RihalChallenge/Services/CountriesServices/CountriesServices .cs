using Microsoft.EntityFrameworkCore;
using RihalChallenge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RihalChallenge.Services.CountriesServices
{
    public class CountriesServices : ICountriesServices
    {
        #region Property  
        private RihalChallengeContext _rihalChallengeContext;
        #endregion

        #region Constructor  
        public CountriesServices(RihalChallengeContext rihalChallengeContext)
        {
            _rihalChallengeContext = rihalChallengeContext;
        }
        #endregion
        #region funcations
        public async Task<bool> addedditdeleteDatacountries(countries countries , string code)
        {
            try
            {
                countries _countries = new countries();
                if (code == "EDIT")
                {
                    if (countries.id == 0)
                    {
                        countries.name = countries.name;
                        await _rihalChallengeContext.AddAsync(countries);
                    }
                    else
                    {
                        _countries = await (from c in _rihalChallengeContext.countries
                                          where c.id == countries.id
                                          select c).FirstOrDefaultAsync();
                        _countries.name = countries.name;
                        _rihalChallengeContext.Update(_countries);
                    }
                }
                else
                {
                    _countries = await (from c in _rihalChallengeContext.countries
                                      where c.id == countries.id
                                      select c).FirstOrDefaultAsync();
                    _rihalChallengeContext.Remove(_countries);
                }
                await _rihalChallengeContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false; ;
            }
        }
        public List<countries> GetListofcountries()
        {
            try
            {
                List<countries> _countries = new List<countries>();
                _countries = (from c in _rihalChallengeContext.countries
                                  select c).ToList();
                return _countries;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> postRandomSeedDataFaker()
        {
            try
            {
                int count = await _rihalChallengeContext.countries.CountAsync();
                for (int i = count; i <120; i++)
                {
                    countries countries = new countries()
                    {
                        
                        name = Faker.Country.Name()
                    };
                    await _rihalChallengeContext.AddAsync(countries);
                }
                await _rihalChallengeContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false; ;
            }
        }
        #endregion
    }
}
