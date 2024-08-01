using Polly.Registry;

namespace HttpResilience
{
    public class DummyUserService : IDummyUserService
    {
        private readonly HttpClient _httpClient;
        private readonly ResiliencePipelineProvider<string> _resiliencePipelineProvider;
        public DummyUserService(HttpClient httpClient,
                                ResiliencePipelineProvider<string> resiliencePipelineProvider)
        {
            _httpClient = httpClient;
            _resiliencePipelineProvider = resiliencePipelineProvider;

        }
        public async Task<string> GetDummyUserAsync()
        {
            var pipeline = _resiliencePipelineProvider.GetPipeline("default");
            var response = await pipeline
                .ExecuteAsync(async ct => await _httpClient.GetAsync($"https://dummyjson.com/user/2", ct));

            return await response.Content.ReadAsStringAsync();
        }

    }
}
