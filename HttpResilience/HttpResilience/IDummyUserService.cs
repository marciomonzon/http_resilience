namespace HttpResilience
{
    public interface IDummyUserService
    {
        Task<string> GetDummyUserAsync();
    }
}
