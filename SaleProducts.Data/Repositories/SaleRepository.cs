using AgencyApp.Data.Context;
using SaleProducts.Data.DTO;
using SaleProducts.Data.Models;

namespace AgencyApp.Data.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly AppDbContext _appDbContext;
        public SaleRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public async Task<SaleDTO> Create(SaleDTO saleDTO)
        {
            await _appDbContext.Set<Sale>().AddAsync(saleDTO.Sale);
            await _appDbContext.SaveChangesAsync();
            return saleDTO;
        }
    }
}