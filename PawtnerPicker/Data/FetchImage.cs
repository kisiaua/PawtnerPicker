using Newtonsoft.Json.Linq;

namespace PawtnerPicker.Data;

public static class FetchImage
{
    public static async Task<string?> GetImageUrl(string breedName)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("X-Api-Key", Environment.GetEnvironmentVariable("X-Api-Key-Dogs"));
        var response = await client.GetAsync($"https://api.api-ninjas.com/v1/dogs?name={breedName}");

        string? desiredProperty = null;
        if (!response.IsSuccessStatusCode) return desiredProperty;
        
        var responseJson = await response.Content.ReadAsStringAsync();
        var jsonArray = JArray.Parse(responseJson);
        var jsonObject = (JObject)jsonArray[0];
        desiredProperty = (string)jsonObject["image_link"] ?? null;

        return desiredProperty;
    }
}