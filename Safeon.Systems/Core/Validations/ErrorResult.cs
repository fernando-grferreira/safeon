using Safeon.Systems.Contracts;
using System.Collections.Generic;

namespace Safeon.Systems.Core.Validations
{
    public class ErrorResult : IError
    {

        public bool Error { get; set; } = false;

        public IList<ErrorState> ErrorList { get; set; }

        public ErrorResult()
        {
            ErrorList = new List<ErrorState>();
        }

        public ErrorResult(bool error) : this()
        {
            Error = error;
        }

        public ErrorResult(int errorCode, string message, string field) : this(true)
        {
            ErrorList.Add(new ErrorState(errorCode, message));
        }

        public void AddError(string message, int errorCode = 0, string field = null)
        {
            Error = true;
            ErrorList.Add(new ErrorState(errorCode, message, field));
        }
        public void AddError(ErrorState error)
        {
            Error = true;
            ErrorList.Add(error);
        }

        public static T CreateResultWith<T>(ErrorResult result) where T : ErrorResult, new()
        {
            return new T
            {
                Error = result.Error,
                ErrorList = result.ErrorList
            };
        }
    }
}