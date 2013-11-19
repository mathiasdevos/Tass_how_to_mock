namespace MockingExample.Exceptions
{
    public class FileToShortException : System.Exception
    {
        public FileToShortException() : base() { }
        public FileToShortException(string message) : base(message) { }
        public FileToShortException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an 
        // exception propagates from a remoting server to the client.  
        protected FileToShortException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }
}