namespace AgencyApp.Data.Repositories
{
    using SaleProducts.Data.DTO;
    public interface ISaleRepository
    {
        Task<SaleDTO> Create(SaleDTO saleDTO);
    }
}
