namespace DigitalMarket_API.Domain.Service
{
    public enum ErrorReason
    {
        AlreadyExist,
        NotFound,
    }

    public record class Error(ErrorReason Reason, string Message);
}
