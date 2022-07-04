using System.Runtime.Serialization;

namespace fitfluence_experimental_backend.Exceptions
{
    [Serializable]
    internal class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {

        }
    }
}