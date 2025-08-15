using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zamazon.Cargo.Dto.Dtos.CargoDetailDtos
{
    public class CreateCargoDetailDto
    {
 
        public string SenderCustomer { get; set; }

        public string RecieverCustomer { get; set; }
        public string Barcode { get; set; }
        public int CargoCompanyId { get; set; }
    }
}
