using System.Collections.Generic;

namespace Haulio.FarmFresh.DTO.DTOs
{
    public class ProductToPageDTO 
    {
        public int count { get; set; }
        public List<ProductToListDTO> Products { get; set; }
    }
}
