using System.Text.Json;
using BlazorDex.Models;
using System.Text;


namespace BlazorDex.Util
{

    public class HeroStateService
    {
        public Hero Hero { get; private set; }
        public event Action OnChange;

        public void SetHero(Hero hero)
        {
            Hero = hero;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }

    public class HeroClient
    {
        public HttpClient Client { get; set; }

        public HeroClient(HttpClient client)
        {
            this.Client = client;
        }

        public async Task<Hero> GetHero(string id)
        {
            var response = await this.Client.GetAsync($"https://kreshnik-api.onrender.com/api/heroes/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to fetch hero. Status code: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Hero>(content, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }
        public async Task UpdateHero(Hero hero)
        {
            var heroJson = JsonSerializer.Serialize(hero);
            var content = new StringContent(heroJson, Encoding.UTF8, "application/json");
            var response = await this.Client.PutAsync($"https://kreshnik-api.onrender.com/api/heroes/{hero.Id}", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to update hero. Status code: {response.StatusCode}");
            }
        }

    }
}
