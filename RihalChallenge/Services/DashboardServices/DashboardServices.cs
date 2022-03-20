using Microsoft.EntityFrameworkCore;
using RihalChallenge.Data;
using RihalChallenge.VModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RihalChallenge.Services.DashboardServices
{
    public class DashboardServices : IDashboardServices
    {
        #region Property  
        private RihalChallengeContext _rihalChallengeContext;
        #endregion

        #region Constructor  
        public DashboardServices(RihalChallengeContext rihalChallengeContext)
        {
            _rihalChallengeContext = rihalChallengeContext;
        }
        public async Task<Dashboard> getDashboardData()
        {
            try
            {
                Dashboard dashboards = new Dashboard();
                List<classes> classes = new List<classes>();
                List<countries> countries = new List<countries>();
                List<students> students = new List<students>();
                List<classesDashboard> classesDashboards = new List<classesDashboard>();
                List<CountryDashboard> countryDashboards = new List<CountryDashboard>();
                List<int> Age = new List<int>();
                classes = await _rihalChallengeContext.classes.ToListAsync();
                countries = await _rihalChallengeContext.countries.ToListAsync();
                students = await _rihalChallengeContext.students.ToListAsync();

                foreach (var item in students)
                {

                    Age.Add(new DateTime(DateTime.Now.Subtract(item.date_of_birth.Value).Ticks).Year - 1);
                }

                foreach (var item in classes)
                {
                    if (item.Students != null)
                    {
                        var add = new classesDashboard
                        {
                            studentCount = item.Students.Count,
                            className = item.name
                        };
                        classesDashboards.Add(add);
                    }
                }

                foreach (var item in countries)
                {
                    if (item.Students != null)
                    {
                        var add = new CountryDashboard
                        {
                            CountryName = item.name,
                            studentCount = item.Students.Count
                        };
                        countryDashboards.Add(add);
                    };
                }
                dashboards = new Dashboard { AverageStudentsAge = (int?)Age.Average(), classesDashboards = classesDashboards, countryDashboards = countryDashboards };
                return dashboards;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
    }
}