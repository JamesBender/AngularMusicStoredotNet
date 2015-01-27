using System.Collections.Generic;

namespace AngularMusicStore.Core.Entities
{
    public class Artist : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual IList<Album> Albums { get; protected set; }

        public Artist()
        {
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            Albums = new List<Album>();
        }

        public virtual void AddAlbum(Album album)
        {
            album.Parent = this;
            Albums.Add(album);
        }
    }
}