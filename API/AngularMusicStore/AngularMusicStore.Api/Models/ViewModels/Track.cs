using System;

namespace AngularMusicStore.Api.Models.ViewModels
{
    public class Track
    {
        public Guid Id { get; set; }
        public Album Parent { get; set; }
        public int AlbumOrder { get; set; }
        public TimeSpan Length { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
    }
}
