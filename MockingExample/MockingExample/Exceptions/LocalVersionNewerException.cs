namespace MockingExample.Exceptions
{
    public class LocalVersionNewerException : System.Exception
    {
        public LocalVersionNewerException() : base() { }
        public LocalVersionNewerException(string message) : base(message) { }
        public LocalVersionNewerException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an 
        // exception propagates from a remoting server to the client.  
        protected LocalVersionNewerException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }
}