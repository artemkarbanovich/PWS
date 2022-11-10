namespace lab8.Models
{
    public class JsonRpcResp
    {
        public readonly string jsonrpc = "2.0";
        public readonly object result = null;
        public readonly JsonRpcError error = null;
        public readonly string id = null;

        public JsonRpcResp(JsonRpcError error) => this.error = error;
        public JsonRpcResp(JsonRpcError error, string id)
        {
            this.id = id;
            this.error = error;
        }
        public JsonRpcResp(object result, string id)
        {
            this.result = result;
            this.id = id;
        }
    }
}
