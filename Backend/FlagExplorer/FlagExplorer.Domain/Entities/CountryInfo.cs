using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagExplorer.Domain.Entities
{
    public class CountryInfo
    {
        [JsonProperty("name")]
        public NameInfo Name { get; set; }

        [JsonProperty("tld")]
        public List<string> Tld { get; set; }

        [JsonProperty("cca2")]
        public string Cca2 { get; set; }

        [JsonProperty("ccn3")]
        public string Ccn3 { get; set; }

        [JsonProperty("cca3")]
        public string Cca3 { get; set; }

        [JsonProperty("independent")]
        public bool? Independent { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("unMember")]
        public bool UnMember { get; set; }

        [JsonProperty("currencies")]
        public Dictionary<string, CurrencyInfo> Currencies { get; set; }

        [JsonProperty("idd")]
        public IddInfo Idd { get; set; }

        [JsonProperty("capital")]
        public List<string> Capital { get; set; }

        [JsonProperty("altSpellings")]
        public List<string> AltSpellings { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("languages")]
        public Dictionary<string, string> Languages { get; set; }

        [JsonProperty("translations")]
        public Dictionary<string, TranslationInfo> Translations { get; set; }

        [JsonProperty("latlng")]
        public List<double> Latlng { get; set; }

        [JsonProperty("landlocked")]
        public bool Landlocked { get; set; }

        [JsonProperty("area")]
        public double Area { get; set; }

        [JsonProperty("demonyms")]
        public Dictionary<string, DemonymInfo> Demonyms { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonProperty("maps")]
        public MapInfo Maps { get; set; }

        [JsonProperty("population")]
        public int Population { get; set; }

        [JsonProperty("car")]
        public CarInfo Car { get; set; }

        [JsonProperty("timezones")]
        public List<string> Timezones { get; set; }

        [JsonProperty("continents")]
        public List<string> Continents { get; set; }

        [JsonProperty("flags")]
        public FlagInfo Flags { get; set; }

        [JsonProperty("coatOfArms")]
        public object CoatOfArms { get; set; }

        [JsonProperty("startOfWeek")]
        public string StartOfWeek { get; set; }

        [JsonProperty("capitalInfo")]
        public CapitalInfo CapitalInfo { get; set; }
    }

    public class NameInfo
    {
        [JsonProperty("common")]
        public string Common { get; set; }

        [JsonProperty("official")]
        public string Official { get; set; }

        [JsonProperty("nativeName")]
        public Dictionary<string, NativeNameInfo> NativeName { get; set; }
    }

    public class NativeNameInfo
    {
        [JsonProperty("official")]
        public string Official { get; set; }

        [JsonProperty("common")]
        public string Common { get; set; }
    }

    public class CurrencyInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }

    public class IddInfo
    {
        [JsonProperty("root")]
        public string Root { get; set; }

        [JsonProperty("suffixes")]
        public List<string> Suffixes { get; set; }
    }

    public class TranslationInfo
    {
        [JsonProperty("official")]
        public string Official { get; set; }

        [JsonProperty("common")]
        public string Common { get; set; }
    }

    public class DemonymInfo
    {
        [JsonProperty("f")]
        public string Female { get; set; }

        [JsonProperty("m")]
        public string Male { get; set; }
    }

    public class MapInfo
    {
        [JsonProperty("googleMaps")]
        public string GoogleMaps { get; set; }

        [JsonProperty("openStreetMaps")]
        public string OpenStreetMaps { get; set; }
    }

    public class CarInfo
    {
        [JsonProperty("signs")]
        public List<string> Signs { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }
    }

    public class FlagInfo
    {
        [JsonProperty("png")]
        public string Png { get; set; }

        [JsonProperty("svg")]
        public string Svg { get; set; }
    }

    public class CapitalInfo
    {
        [JsonProperty("latlng")]
        public List<double> Latlng { get; set; }
    }
}
