using RihalChallenge.Data;
using RihalChallenge.VModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RihalChallenge.Services.StudentServices
{
    public interface IStudentsServices
    {
        Task<bool> addedditdeleteDatastudents(students students, string code);
        List<studentsVM> GetListofstudents();
        Task<bool> postRandomSeedDataFaker();
    }
}
