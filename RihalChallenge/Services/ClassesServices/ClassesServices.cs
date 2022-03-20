using Microsoft.EntityFrameworkCore;
using RihalChallenge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RihalChallenge.Services.ClassesServices
{
    public class ClassesServices : IClassesServices
    {
        #region Property  
        private RihalChallengeContext _rihalChallengeContext;
        #endregion

        #region Constructor  
        public ClassesServices(RihalChallengeContext rihalChallengeContext)
        {
            _rihalChallengeContext = rihalChallengeContext;
        }
        public async Task<bool> addedditdeleteDataClasses(classes classes, string code)
        {
            try
            {
                classes _classes = new classes();
                if (code == "EDIT")
                {
                    if (classes.id == 0)
                    {
                        classes.name = classes.name;
                        await _rihalChallengeContext.AddAsync(classes);
                    }
                    else
                    {
                        _classes = await (from c in _rihalChallengeContext.classes
                                          where c.id == classes.id
                                          select c).FirstOrDefaultAsync();
                        _classes.name = classes.name;
                        _classes.ModifitedDate = DateTime.Now;
                        _rihalChallengeContext.Update(_classes);
                    }
                }
                else
                {
                    _classes = await (from c in _rihalChallengeContext.classes
                                      where c.id == classes.id
                                      select c).FirstOrDefaultAsync();
                    _rihalChallengeContext.Remove(_classes);
                }
                await _rihalChallengeContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false; ;
            }
        }
        public List<classes> GetListofClasses()
        {
            try
            {
                List<classes> _classes = new List<classes>();
                _classes = (from c in _rihalChallengeContext.classes
                                  select c).ToList();
                return _classes;
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
                int count = await _rihalChallengeContext.classes.CountAsync();
                for (int i = count; i <6; i++)
                {
                    classes classes = new classes()
                    {
                        
                        name = "Class" + i
                    };
                    await _rihalChallengeContext.AddAsync(classes);
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
