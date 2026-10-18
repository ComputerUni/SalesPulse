using SalesPulse.Core.DTOs.CityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.DataAccess.Repositories.Cities
{
    public interface ICityRepository
    {
        Task<IEnumerable<ResultCityDto>> GetAllAsync();
    }
}
