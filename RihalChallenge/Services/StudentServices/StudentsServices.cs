using Microsoft.EntityFrameworkCore;
using RihalChallenge.Data;
using RihalChallenge.VModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RihalChallenge.Services.StudentServices
{
    public class StudentsServices : IStudentsServices
    {
        #region Property  
        private RihalChallengeContext _rihalChallengeContext;
        #endregion

        #region Constructor  
        public StudentsServices(RihalChallengeContext rihalChallengeContext)
        {
            _rihalChallengeContext = rihalChallengeContext;
        }
        #endregion
        #region funcations
        public async Task<bool> addedditdeleteDatastudents(students students, string code)
        {
            try
            {
                students _students = new students();
                if (code == "EDIT")
                {
                    if (students.id == 0)
                    {
                        students.name = students.name;
                        await _rihalChallengeContext.AddAsync(students);
                    }
                    else
                    {
                        _students = await (from c in _rihalChallengeContext.students
                                           where c.id == students.id
                                           select c).FirstOrDefaultAsync();
                        _students.name = students.name;
                        _students.class_Id = students.class_Id;
                        _students.country_Id = students.country_Id;
                        _students.date_of_birth = students.date_of_birth;
                        _rihalChallengeContext.Update(_students);
                    }
                }
                else
                {
                    _students = await (from c in _rihalChallengeContext.students
                                       where c.id == students.id
                                       select c).FirstOrDefaultAsync();
                    _rihalChallengeContext.Remove(_students);
                }
                await _rihalChallengeContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false; ;
            }
        }
        public List<studentsVM> GetListofstudents()
        {
            try
            {
                List<studentsVM> _students = new List<studentsVM>();
                _students = (from c in _rihalChallengeContext.students
                             select new studentsVM
                             {
                                 id = c.id,
                                 name = c.name,
                                 classes = c.Classes,
                                 countries = c.Countries,
                                 date_of_birth = c.date_of_birth
                             }
                                 ).ToList();
                return _students;
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
                DateTime start = new DateTime(1995, 1, 1);
                int count = await _rihalChallengeContext.students.CountAsync();
                for (int i = count; i < 20; i++)
                {
                    int range = (DateTime.Today - start).Days;
                    students students = new students()
                    {

                        name = Faker.Name.FullName(),
                        date_of_birth = start.AddDays(Faker.RandomNumber.Next(range)),
                        country_Id = (from c in _rihalChallengeContext.countries
                                      where c.name == Faker.Country.Name()
                                      select c.id).FirstOrDefault(),
                        class_Id = (from c in _rihalChallengeContext.countries
                                    where c.name == "Class" + i
                                    select c.id).FirstOrDefault(),
                    };
                    await _rihalChallengeContext.AddAsync(students);
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
