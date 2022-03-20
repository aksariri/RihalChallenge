using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RihalChallenge.VModel
{
    public class Dashboard
    {
        public List<classesDashboard> classesDashboards { get; set; }
        public List<CountryDashboard> countryDashboards { get; set; }
        public int? AverageStudentsAge { get; set; }
    }
    public class classesDashboard
    {
        public int studentCount { get; set; }
        public string className { get; set; }
    }
    public class CountryDashboard
    {
        public int studentCount { get; set; }
        public string CountryName { get; set; }
    }
}
