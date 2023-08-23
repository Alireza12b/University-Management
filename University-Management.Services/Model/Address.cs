using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Management.Core.Common;

namespace University_Management.Core
{
    public class Address : BaseEntity
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Alley { get; set; }
        public string PostalCode { get; set; }

        public int ProvinceId { get; set; }
        public Province Province { get; set; }

        public int AddressOfStudentId { get; set; }
        public Student Student { get; set; }
    }
}
