using E_Commerce.DAL.Models;

namespace E_Commerce.BL.DTO
{
    public class CatagoryDTO
    {
        public int CatId { get; set; }
        public string CatName { get; set; }

        public string CatImage { get; set; }

        public bool IsActive { get; set; }

        public List<SubCatagoryDTO> SubCategories { get; set; }
        public DateTime CreatedDate { get; set; }

        
    }
}
