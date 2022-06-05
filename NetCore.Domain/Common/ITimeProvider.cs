namespace NetCore.Domain.Common
{
    public interface ITimeProvider
    {
        DateTime utcDateTime();
    }
}