using System;
using Newtonsoft.Json;

namespace DomainModel.Meetup 
{

public partial class Welcome
    {
        [JsonProperty("created")]
        public long Created { get; set; }

        [JsonProperty("updated")]
        public long Updated { get; set; }

        [JsonProperty("response")]
        public string Response { get; set; }

        [JsonProperty("guests")]
        public long Guests { get; set; }

        [JsonProperty("event")]
        public Event Event { get; set; }

        [JsonProperty("group")]
        public Group Group { get; set; }

        [JsonProperty("member")]
        public Member Member { get; set; }

        [JsonProperty("venue")]
        public Venue Venue { get; set; }
    }

    public partial class Event
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("yes_rsvp_count")]
        public long YesRsvpCount { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("utc_offset")]
        public long UtcOffset { get; set; }
    }

    public partial class Group
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("urlname")]
        public string Urlname { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("who")]
        public string Who { get; set; }

        [JsonProperty("members")]
        public long Members { get; set; }

        [JsonProperty("join_mode")]
        public string JoinMode { get; set; }

        [JsonProperty("localized_location")]
        public string LocalizedLocation { get; set; }
    }

    public partial class Attendee 
    {
        [JsonProperty("member")]
        public Member Member { get; set; }
    }

    public partial class Member
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("photo", NullValueHandling = NullValueHandling.Ignore)]
        public Photo Photo { get; set; }

        [JsonProperty("event_context")]
        public EventContext EventContext { get; set; }

        [JsonProperty("bio", NullValueHandling = NullValueHandling.Ignore)]
        public string Bio { get; set; }

        [JsonProperty("role", NullValueHandling = NullValueHandling.Ignore)]
        public string Role { get; set; }
    }

    public partial class EventContext
    {
        [JsonProperty("host")]
        public bool Host { get; set; }
    }

    public partial class Photo
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("highres_link")]
        public Uri HighresLink { get; set; }

        [JsonProperty("photo_link")]
        public Uri PhotoLink { get; set; }

        [JsonProperty("thumb_link")]
        public Uri ThumbLink { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("base_url")]
        public Uri BaseUrl { get; set; }
    }

    public partial class Venue
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("repinned")]
        public bool Repinned { get; set; }

        [JsonProperty("address_1")]
        public string Address1 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("localized_country_name")]
        public string LocalizedCountryName { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}