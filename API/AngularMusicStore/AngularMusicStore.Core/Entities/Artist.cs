using System.Collections.Generic;

namespace AngularMusicStore.Core.Entities
{
    //I don't like making sealed clases, but nHibernate wont let me
    //make the set on the Albums list private, so...
    public sealed class Artist : BaseEntity
    {
        public string Name { get; set; }
        public IList<Album> Albums { get; protected set; }

        public Artist()
        {
            Albums = new List<Album>();
        }
    }
}