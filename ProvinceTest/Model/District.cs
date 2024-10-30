using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvinceTest.Model
{
    public class District 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
