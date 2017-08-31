using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public NameModel Name { get; set; }
        public AddressModel Address { get; set; }
        public PhoneModel Phone { get; set; }
    }
}
