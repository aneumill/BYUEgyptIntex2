using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BYUEgyptIntex2.Models
{
    public class MummyModel
    {
        [Key]
        public int MummyID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string BodyPart { get; set; }
    }
}
