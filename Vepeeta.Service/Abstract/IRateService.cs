using Vepeeta.Data.Entity;

namespace Vepeeta.Service.Abstract
{
    public interface IRateService
    {
        public Task<string> CreateRateAsync(Rateing rateing);
        public Task<string> UpdateRateAsync(Rateing rateing);
        public Task<string> DeleteRateAsync(Rateing rateing);
        public Task<Rateing> GetRateByIdAsync(int id);
        public Task<List<Rateing>> GetAllRatesByDoctorIdAsync(string doctorId);
    }
}
