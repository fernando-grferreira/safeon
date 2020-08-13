using Safeon.Systems.Core.Validations;
using System.Collections.Generic;

namespace Safeon.Systems.Contracts
{
    public interface IError
    {
        bool Error { get; set; }

        IList<ErrorState> ErrorList { get; set; }
    }
}