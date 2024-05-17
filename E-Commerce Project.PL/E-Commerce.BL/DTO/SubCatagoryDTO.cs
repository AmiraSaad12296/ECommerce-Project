namespace E_Commerce.BL.DTO
{
    public class SubCatagoryDTO
    {
        public int SubCatId { get; set; }
        public string SubCatName { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
