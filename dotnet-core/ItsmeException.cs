using System;
namespace Itsme
{
    public class ItsmeException : Exception
    {
        internal ItsmeException()
        {
        }

        internal ItsmeException(string message)
            : base(message)
        {
        }

        internal ItsmeException(Error error)
            : base(error.Message)
        {
        }
    }

}
