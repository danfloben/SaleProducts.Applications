using AgencyApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using SaleProducts.Data.DTO;
using SaleProducts.Data.Models;

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
            try
            {
                _appDbContext.Customers.Add(saleDTO.Sale.Customer);

                _appDbContext.SaveChanges();
                saleDTO.Sale.Customer = saleDTO.Sale.Customer;
                _appDbContext.Sales.Add(saleDTO.Sale);
                _appDbContext.SaveChanges();
                foreach (var product in saleDTO.Products)
                {
                    product.Sale = saleDTO.Sale;
                }
                _appDbContext.Products.AddRange(saleDTO.Products);
                _appDbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in SaleRepository: " + ex.Message);
            }
            
            return saleDTO;
        }
    }
}