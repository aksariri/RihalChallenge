using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RihalChallenge.Data
{
    public class classes
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifitedDate { get; set; }

        #region Reverse_Navigation
        public virtual ICollection<students> Students { get; set; }
        #endregion

        #region AutoData
        public classes()
        {
            CreatedDate = DateTime.Now;
        }
        #endregion
    }
}
