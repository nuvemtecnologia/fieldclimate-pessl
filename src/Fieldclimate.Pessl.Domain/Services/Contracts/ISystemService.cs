using System.Collections.Generic;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Model;

namespace FieldClimate.Pessl.Domain.Services.Contracts
{
    public interface ISystemService
    {
        Task<bool> GetStatus();
        Task<dynamic> GetSensors();
        Task<dynamic> GetGroups();
        Task<dynamic> GetGroupSensors();
        Task<dynamic> GetTypes();
        Task<IEnumerable<Country>> GetCountries();
        Task<IEnumerable<SystemDisease>> GetDiseases();
    }
}