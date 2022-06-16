namespace fitfluence_experimental_backend.Data
{
    public class MuscleGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Exercise> Exercises { get; set; }
    }
}