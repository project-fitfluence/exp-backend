using AutoMapper;
using fitfluence_experimental_backend.Contracts;
using fitfluence_experimental_backend.Data;
using Microsoft.EntityFrameworkCore;

namespace fitfluence_experimental_backend.Repository
{
    public class MuscleGroupsRepository : GenericRepository<MuscleGroup>, IMuscleGroupsRepository
    {
        private readonly FitfluenceDbContext _context;

        public MuscleGroupsRepository(FitfluenceDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<MuscleGroup> GetDetails(int id)
        {
            return await _context.MuscleGroups.Include(q => q.Exercises)
                .FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
