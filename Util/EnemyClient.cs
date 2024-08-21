using System.Text.Json;
using BlazorDex.Models;

namespace BlazorDex.Util
{
    public class EnemyClient
    {
        public class HeroClient
        {
            public HttpClient Client { get; set; }

            public HeroClient(HttpClient client)
            {
                this.Client = client;
            }

            public async Task<Hero> GetHero(string id)
            {
                var response = await this.Client.GetAsync($"http://localhost:5024/api/heroes/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to fetch hero. Status code: {response.StatusCode}");
                }

                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Hero>(content, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }

        }
    }
}