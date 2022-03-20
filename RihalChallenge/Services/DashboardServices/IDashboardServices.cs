using RihalChallenge.Data;
using RihalChallenge.VModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RihalChallenge.Services.DashboardServices
{
    public interface IDashboardServices
    {
        Task<Dashboard> getDashboardData();
    }
}
