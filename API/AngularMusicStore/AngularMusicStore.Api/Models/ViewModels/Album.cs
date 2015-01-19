using System;

namespace AngularMusicStore.Api.Models.ViewModels
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CoverUrl { get; set; }
        public Artist Parent { get; set; }
    }
}