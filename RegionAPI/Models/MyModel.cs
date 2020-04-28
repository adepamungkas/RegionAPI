using RegionAPI.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegionAPI.Models
{
    public class MyModel: BaseModel
    {
        [Key]
        public override long Id { get; set; }
        //[Key]
        //public int Id { get; set; }
        public string Name { get; set; }
    }
}
