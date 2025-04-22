using Microsoft.EntityFrameworkCore;
using Vepeeta.Data.Entity;
using Vepeeta.infrustructure.Abstracts;
using Vepeeta.Service.Abstract;

namespace Vepeeta.Service.Implemention
{
    public class RateService : IRateService
    {
        private readonly IRateRepository _rateRepository;

        public RateService(IRateRepository rateRepository)
        {
            _rateRepository = rateRepository;
        }
        public async Task<string> CreateRateAsync(Rateing rateing)
        {
            await _rateRepository.AddAsync(rateing);
            return "Created";
        }

        public async Task<string> DeleteRateAsync(Rateing rateing)
        {
            await _rateRepository.DeleteAsync(rateing);
            return "Deleted";
        }

        public Task<List<Rateing>> GetAllRatesByDoctorIdAsync(string doctorId)
        {
            return _rateRepository.GetTableNoTracking()
                .Where(x => x.DoctorId == doctorId)
                .Include(x => x.Doctor)
                .ToListAsync();
        }

        public Task<Rateing?> GetRateByIdAsync(int id)
        {
            return _rateRepository.GetTableNoTracking()
                 .Include(x => x.Doctor)
                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<string> UpdateRateAsync(Rateing rateing)
        {
            await _rateRepository.UpdateAsync(rateing);
            return "Updated";

        }
    }
}
