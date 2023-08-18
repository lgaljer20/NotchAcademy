using cassiopeia_be.Business.DTO;

namespace cassiopeia_be.Business.Interfaces
{
    public interface ISatelliteInfoService : IService
    {

        Task<IEnumerable<SatelliteInfoDTO>> GetAllAsync();

        Task<SatelliteInfoDTO> GetByIdAsync(int id);

        Task<SatelliteInfoDTO> CreateAsync(CreateEditSatelliteInfoDTO model); 

        Task<SatelliteInfoDTO> UpdateAsync(int id, CreateEditSatelliteInfoDTO model);
    }
}
