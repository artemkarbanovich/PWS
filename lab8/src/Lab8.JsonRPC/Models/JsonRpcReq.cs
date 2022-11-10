namespace lab8.Models
{
    public class JsonRpcReq
    {
        public string jsonrpc { get; set; }
        public string method { get; set; }
        public DataModel @params { get; set; }
        public string id { get; set; }
    }
}
