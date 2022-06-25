using fitfluence_experimental_backend.Contracts;
using fitfluence_experimental_backend.Data;
using Microsoft.EntityFrameworkCore;

namespace fitfluence_experimental_backend.Repository
{
    public class ExercisesRepository : GenericRepository<Exercise>, IExercisesRepository
    {
        private readonly FitfluenceDbContext _context;

        public ExercisesRepository (FitfluenceDbContext context): base(context)
        {
            this._context = context;
        }
    }
}
