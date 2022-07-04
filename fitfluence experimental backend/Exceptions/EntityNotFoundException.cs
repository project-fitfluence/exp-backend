using System.Runtime.Serialization;

namespace fitfluence_experimental_backend.Exceptions
{
    [Serializable]
    internal class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string name, object key) : base($"{name} with id ({key}) was not found")
        {

        }
    }
}