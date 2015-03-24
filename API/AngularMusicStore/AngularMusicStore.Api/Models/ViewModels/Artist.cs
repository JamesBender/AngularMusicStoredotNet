using System;
using System.Collections.Generic;

namespace AngularMusicStore.Api.Models.ViewModels
{
    public class Artist
    {
        public Guid Id  { get; set; }
        public string Name { get; set; }
        public IList<Album> Albums { get; private set; }
        public virtual string Bio { get; set; }
        public virtual string PictureUrl { get; set; }
        public virtual IList<Artist> RelatedArtists { get; protected set; } 

        public Artist()
        {
            Albums = new List<Album>();
        }

        public void AddAlbum(Album album)
        {
            album.Parent = this;
            Albums.Add(album);
        }
    }
}