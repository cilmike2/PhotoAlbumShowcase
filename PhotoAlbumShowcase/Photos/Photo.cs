﻿using System.Text.Json.Serialization;

namespace PhotoAlbumShowcase.Photos
{
    public class Photo
    {
        [JsonPropertyName("albumId")]
        public int AlbumId { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }




        public override string ToString()
        {
            return $"[{Id}] -  Album: {AlbumId}, Photo Title: {Title}";
        }
    }
}
