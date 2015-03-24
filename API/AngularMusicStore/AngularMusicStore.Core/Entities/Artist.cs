using System.Collections.Generic;

namespace AngularMusicStore.Core.Entities
{
    public class Artist : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual IList<Album> Albums { get; protected set; }
        public virtual string Bio { get; set; }
        public virtual string PictureUrl { get; set; }
        public virtual IList<Artist> RelatedArtists { get; protected set; } 

        public Artist()
        {
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            Albums = new List<Album>();
            RelatedArtists = new List<Artist>();
        }

        public virtual void AddAlbum(Album album)
        {
            album.Parent = this;
            Albums.Add(album);
        }

        public virtual void AddRelatedArtist(Artist artist)
        {
            RelatedArtists.Add(artist);
        }
    }
}