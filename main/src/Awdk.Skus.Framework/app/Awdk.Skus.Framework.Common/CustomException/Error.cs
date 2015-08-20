using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Awdk.Skus.Framework.Common.CustomException
{
    /// <summary>
    /// Utility class for creating and unwrapping Exception instances.
    /// </summary>
    public static class Error
    {
        /// <summary>
        /// Formats the specified resource string using CultureInfo.CurrentCulture.
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>The formatted string.</returns>
        public static string Format(string format, params object[] args)
        {
            return String.Format(CultureInfo.CurrentCulture, format, args);
        }

        /// <summary>
        /// Creates an RecordNotFoundException with the provided properties.
        /// </summary>
        /// <param name="messageFormat">A composite format string explaining the reason for the exception.</param>
        /// <param name="messageArgs">An object array that contains zero or more objects to format.</param>
        /// <returns>RecordNotFoundException.</returns>
        public static RecordNotFoundException RecordNotFound(string messageFormat, params object[] messageArgs)
        {
            return new RecordNotFoundException(Format(messageFormat, messageArgs));
        }

        public static Exception RecordNotFound(Type entityType, Type keyType, object key)
        {
            return new RecordNotFoundException(entityType, keyType, key);
        }

        public static Exception DuplicateJobException()
        {
            return new DuplicationJobException();
        }


        public static Exception InvalidUserRequest(string messageFormat, params object[] messageArgs)
        {
            return new InvalidUserRequestException(Format(messageFormat, messageArgs)); 
        }
    }
}
