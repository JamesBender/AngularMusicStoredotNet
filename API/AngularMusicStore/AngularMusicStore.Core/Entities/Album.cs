using System;
using System.Security.Principal;

namespace AngularMusicStore.Core.Entities
{
    public class Album : BaseEntity
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CoverUrl { get; set; }
        public Artist Parent { get; set; }
    }
}