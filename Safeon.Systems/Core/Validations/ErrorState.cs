namespace Safeon.Systems.Core.Validations
{
    public class ErrorState
    {
        public int ErrorCode { get; set; }

        public string Message { get; set; }

        public string Field { get; set; }


        public ErrorState()
        {

        }

        public ErrorState(int code, string message, string field = null)
        {
            ErrorCode = code;
            Message = message;
            Field = field;
        }
    }
}