using Newtonsoft.Json;

public class Place
{
    [JsonProperty(PropertyName = "place name")]
    public string Placename { get; set; }
    public string Longitude { get; set; }
    public string State { get; set; }

    [JsonProperty(PropertyName = "state abbreviation")]
    public string Stateabbreviation { get; set; }
    public string Latitude { get; set; }
}



