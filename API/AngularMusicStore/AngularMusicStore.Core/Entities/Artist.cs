using System.Collections.Generic;

namespace AngularMusicStore.Core.Entities
{
    //I don't like making sealed clases, but nHibernate wont let me
    //make the set on the Albums list private, so...
    public class Artist : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual IList<Album> Albums { get; protected set; }

        public Artist()
        {
            Albums = new List<Album>();
        }

        public virtual void AddAlbum(Album album)
        {
            album.Parent = this;
            Albums.Add(album);
        }
    }
}