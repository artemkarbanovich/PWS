namespace lab_1.Responses
{
    public class JsonResponse
    {
        public JsonResponse(string result = null, string error = null)
        {
            Result = result;
            Error = error;
        }

        public string Result { get; private set; }

        public string Error { get; private set; }

        public override string ToString() => Error == null ? "{\"result\": \"" + Result + "\"}" : "{\"error\": \"" + Error + "\"}";
    }
}
