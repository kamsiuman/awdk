using System;

namespace Awdk.Skus.Framework.Common.CustomException
{
    [Serializable]
    public class InvalidUserRequestException : Exception
    {
        public InvalidUserRequestException(string message) :base(message)
        {
        }
    }
}