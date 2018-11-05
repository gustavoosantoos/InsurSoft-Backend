namespace InsurSoft.Backend.Shared.Functional
{
    public interface IResult
    {
        bool IsFailure { get; }
        bool IsSuccess  { get; }
    }
}
