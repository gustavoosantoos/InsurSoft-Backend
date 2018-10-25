using System.Collections.Generic;

namespace InsurSoft.Backend.Shared.Funcional
{
    public interface IResult
    {
        bool IsFailure { get; }
        bool IsSuccess  { get; }
    }
}
