namespace FinalProject14231.Application.Common.Interfaces
{
    public interface IUser
    {
        string? Id { get; }
        string GetUserId();
        string GetUserName();
        bool IsAuthenticated();
    }
}
