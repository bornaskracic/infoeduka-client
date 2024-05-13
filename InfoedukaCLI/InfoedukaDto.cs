using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace InfoedukaDto
{
    public partial class InfoedukaResponse
    {
        [JsonProperty("data")]
        public AkademskaGodina[] Data { get; set; }
    }

    public partial class AkademskaGodina
    {
        [JsonProperty("akademskaGodina")]
        public string Godina { get; set; }

        [JsonProperty("semestar")]
        public string Semestar { get; set; }

        [JsonProperty("godine")]
        public UpisanaGodina[] UpisaneGodine { get; set; }
    }

    public partial class UpisanaGodina
    {
        [JsonProperty("studij")]
        public string Studij { get; set; }

        [JsonProperty("godina")]
        public string Godina { get; set; }

        [JsonProperty("smjer")]
        public string Smjer { get; set; }

        [JsonProperty("nacin")]
        public string Nacin { get; set; }

        [JsonProperty("grupa")]
        public string Grupa { get; set; }

        [JsonProperty("predmeti")]
        public Predmet[] Predmeti { get; set; }
    }

    public partial class Predmet
    {
        [JsonProperty("idPredmet")]
        public long IdPredmet { get; set; }

        [JsonProperty("predmet")]
        public string ImePredmeta { get; set; }

        [JsonProperty("sifra")]
        public string Sifra { get; set; }

        [JsonProperty("ects")]
        public long Ects { get; set; }

        [JsonProperty("potpis")]
        public bool Potpis { get; set; }

        [JsonProperty("potpisDatum")]
        public string PotpisDatum { get; set; }

        [JsonProperty("ocjena")]
        public int? Ocjena { get; set; }

        [JsonProperty("ocjenaOpisno")]
        public string? OcjenaOpisno { get; set; }

        [JsonProperty("ocjenaDatum")]
        public string? OcjenaDatum { get; set; }

        [JsonProperty("polozenBezOcjene")]
        public bool PolozenBezOcjene { get; set; }

        [JsonProperty("polozenBezOcjeneKolokviran")]
        public bool PolozenBezOcjeneKolokviran { get; set; }

        [JsonProperty("priznat")]
        public bool Priznat { get; set; }

        [JsonProperty("priznatCertifikat")]
        public bool PriznatCertifikat { get; set; }

        [JsonProperty("dodatno")]
        public object[] Dodatno { get; set; }
    }

    public partial struct Ocjena
    {
        public long? Integer;
        public string String;

        public static implicit operator Ocjena(long Integer) => new Ocjena { Integer = Integer };
        public static implicit operator Ocjena(string String) => new Ocjena { String = String };
    }

    public partial class InfoedukaResponse
    {
        public static InfoedukaResponse FromJson(string json) => JsonConvert.DeserializeObject<InfoedukaResponse>(json, InfoedukaDto.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this InfoedukaResponse self) => JsonConvert.SerializeObject(self, InfoedukaDto.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
