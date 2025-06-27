using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Domain.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string UserId { get; set; }
        public string DistrictId { get; set; }
        public string CityId { get; set; }
        public string Detail { get; set; }
    }
}
