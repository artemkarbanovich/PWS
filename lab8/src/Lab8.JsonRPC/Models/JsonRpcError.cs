namespace lab8.Models
{
    public class JsonRpcError
    {
        public int code { get; set; }
        public string message { get; set; }
        public object data { get; set; }

        public JsonRpcError() { }
        public JsonRpcError(string data) => this.data = data;
    }

    public class ParseErrorJsonRPC : JsonRpcError
    {
        public ParseErrorJsonRPC()
        {
            code = -32700;
            message = @"
                Invalid JSON was received by the server.
                An error occurred on the server while parsing the JSON text";
        }
        public ParseErrorJsonRPC(string data) : this() => this.data = data;
    }

    public class InvalidRequestErrorJsonRPC : JsonRpcError
    {
        public InvalidRequestErrorJsonRPC()
        {
            code = -32600;
            message = @"The JSON sent is not a valid Request object";
        }
        public InvalidRequestErrorJsonRPC(string data) : this() => this.data = data;
    }

    public class MethodNotFoundErrorJsonRPC : JsonRpcError
    {
        public MethodNotFoundErrorJsonRPC()
        {
            code = -32601;
            message = @"The method does not exist / is not available";
        }
        public MethodNotFoundErrorJsonRPC(string data) : this() => this.data = data;
    }

    public class InvalidParamsErrorJsonRPC : JsonRpcError
    {
        public InvalidParamsErrorJsonRPC()
        {
            code = -32602;
            message = @"Invalid parameters";
        }
        public InvalidParamsErrorJsonRPC(string data) : this() => this.data = data;
    }

    public class InternalErrorJsonRPC : JsonRpcError
    {
        public InternalErrorJsonRPC()
        {
            code = -32603;
            message = @"Internal JSON-RPC error";
        }
        public InternalErrorJsonRPC(string data) : this() => this.data = data;
    }

    public class ServerErrorJsonRPC : JsonRpcError
    {
        public ServerErrorJsonRPC()
        {
            code = -32000;
            message = @"Reserved for implementation-defined server-errors";
        }
        public ServerErrorJsonRPC(string data) : this() => this.data = data;
    }
}
