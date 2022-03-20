using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RihalChallenge.Data
{
    public class students
    {
        [Key]
        public int id { get; set; }
        public int? class_Id { get; set; }
        public int? country_Id { get; set; }
        public string name { get; set; }
        public DateTime? date_of_birth { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifitedDate { get; set; }

        #region Foreign_keys
        public virtual classes Classes { get; set; }
        public virtual countries Countries { get; set; }
        #endregion

        #region AutoData
        public students()
        {
            CreatedDate = DateTime.Now;
        }
        #endregion
    }
}
