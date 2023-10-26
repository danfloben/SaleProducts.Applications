namespace AgencyApp.Data.Repositories
{
    using SaleProducts.Data.DTO;
    using SaleProducts.Data.Models;
    public interface ISaleRepository
    {
        Task<SaleDTO> Create(SaleDTO saleDTO);
    }
}
