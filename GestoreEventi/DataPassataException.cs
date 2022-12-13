namespace GestoreEventi {
    public class DataPassataException : NotSupportedException {
        public DataPassataException() {
        }

        public DataPassataException(string message) : base(message) {
        }

        public DataPassataException(string message, Exception innerException) : base(message, innerException) {
        }
    }
}
