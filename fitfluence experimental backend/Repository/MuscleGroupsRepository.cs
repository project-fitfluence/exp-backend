using fitfluence_experimental_backend.Contracts;
using fitfluence_experimental_backend.Data;

namespace fitfluence_experimental_backend.Repository
{
    public class MuscleGroupsRepository : GenericRepository<MuscleGroup>, IMuscleGroupsRepository
    {
        public MuscleGroupsRepository(FitfluenceDbContext context): base(context)
        {
               
        }
    }
}
