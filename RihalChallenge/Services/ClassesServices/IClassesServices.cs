using RihalChallenge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RihalChallenge.Services.ClassesServices
{
    public interface IClassesServices
    {
        Task<bool> addedditdeleteDataClasses(classes classes, string code);
        List<classes> GetListofClasses();
        Task<bool> postRandomSeedDataFaker();
    }
}
