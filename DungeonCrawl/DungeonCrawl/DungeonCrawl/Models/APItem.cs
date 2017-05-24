using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawl.Models
{
    public class APItem
    {
        [JsonProperty(PropertyName = "Image")]
        public string Image;
        [JsonProperty(PropertyName = "Name")]
        public string Name;
        [JsonProperty(PropertyName = "Description")]
        public string Description;
        [JsonProperty(PropertyName = "Tier")]
        public int Tier;
        [JsonProperty(PropertyName = "BodyPart")]
        public string BodyPart;
        [JsonProperty(PropertyName = "AttribMod")]
        public string AttribMod;
        [JsonProperty(PropertyName = "Usage")]
        public int Usage;
        [JsonProperty(PropertyName = "Creator")]
        public string Creator;

    }
}
