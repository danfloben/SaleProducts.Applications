using AgencyApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using SaleProducts.Data.DTO;

namespace AgencyApp.Data.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly AppDbContext _appDbContext;
        public SaleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<SaleDTO> Create(SaleDTO saleDTO)
        {
            using (var transaction = _appDbContext.Database.BeginTransaction())
            {
                try
                {
                    _appDbContext.Customers.Add(saleDTO.Sale.Customer);
                    _appDbContext.Sales.Add(saleDTO.Sale);
                    saleDTO.Products.ForEach(product => product.Sale = saleDTO.Sale);
                    _appDbContext.Products.AddRange(saleDTO.Products);

                    _appDbContext.SaveChanges();

                    transaction.Commit();
                }
                catch (DbUpdateException ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Error in SaleRepository: " + ex.Message);
                }
            }

            return saleDTO;
        }
    }
}