using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace Awdk.Skus.Framework.Common.CustomException
{
    [Serializable]
    public class RecordNotFoundException : Exception
    {
        public Type EntityType { get; private set; }
        public Type KeyType   { get; private set; }
        public object Key { get; private set; }

        public RecordNotFoundException()
        {
        }


        public RecordNotFoundException(Type entityType, Type keyType, object key)
        {
            this.EntityType = entityType;
            this.KeyType = keyType;
            this.Key = key;
        }

        public RecordNotFoundException(string message)
            : base(message)
        {
        }

        protected RecordNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if(info == null)
                throw new ArgumentException("info");
        }

        public RecordNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {

        }
    }
}
