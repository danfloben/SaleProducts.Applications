using AgencyApp.Business.Services.interfaces;
using AgencyApp.Data.Repositories;
using Newtonsoft.Json;
using SaleProducts.Data.DTO;
using SaleProducts.Data.Models;
using System;

namespace AgencyApp.Business.Services
{
    public class SaleServices : ISaleServices
    {
        public readonly ISaleRepository _repository;
        public SaleServices(ISaleRepository repository)
        {
            _repository = repository;
        }
        public bool CreateAsync(string dataJson)
        {
            var saleDTO = JsonConvert.DeserializeObject<SaleDTO>(dataJson);
            if (_repository.Create(saleDTO) != null)
            {
                return true;
            }
            return false;
        }
     
    }
}
