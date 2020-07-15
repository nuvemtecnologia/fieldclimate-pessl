using System.Threading.Tasks;

namespace Fieldclimate.Pessl.Domain.Services.Contratos
{
    public interface ISystemService
    {
        Task<bool> GetStatus();
        Task<dynamic> GetSensors();
        Task<dynamic> GetGroups();
        Task<dynamic> GetGroupSensors();
        Task<dynamic> GetTypes();
        Task<dynamic> GetCountries();
        Task<dynamic> GetDiseases();
    }
}