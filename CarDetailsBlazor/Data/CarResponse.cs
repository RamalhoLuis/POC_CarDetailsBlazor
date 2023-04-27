using System.Text.Json.Serialization;

namespace CarDetailsBlazor.Data
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class CarResponse
    {
        [JsonPropertyName("result")]
        public CarDetailsAPI.Models.CarsModel Result { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("exception")]
        public object Exception { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("isCanceled")]
        public bool IsCanceled { get; set; }

        [JsonPropertyName("isCompleted")]
        public bool IsCompleted { get; set; }

        [JsonPropertyName("isCompletedSuccessfully")]
        public bool IsCompletedSuccessfully { get; set; }

        [JsonPropertyName("creationOptions")]
        public int CreationOptions { get; set; }

        [JsonPropertyName("asyncState")]
        public object AsyncState { get; set; }

        [JsonPropertyName("isFaulted")]
        public bool IsFaulted { get; set; }
    }
}
