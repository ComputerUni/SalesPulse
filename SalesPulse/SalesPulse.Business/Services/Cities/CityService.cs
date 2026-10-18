using SalesPulse.Core.DTOs.CityDtos;
using SalesPulse.DataAccess.Repositories.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Business.Services.Cities
{
    public class CityService(ICityRepository _cityRepository) : ICityService
    {
        public async Task<IEnumerable<ResultCityDto>> GetAllAsync()
        {
            return await _cityRepository.GetAllAsync();
        }
    }
}
