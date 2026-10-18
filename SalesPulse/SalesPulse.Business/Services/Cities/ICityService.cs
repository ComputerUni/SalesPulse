using SalesPulse.Core.DTOs.CityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Business.Services.Cities
{
    public interface ICityService
    {
        Task<IEnumerable<ResultCityDto>> GetAllAsync();
    }
}
