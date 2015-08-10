using AngularMusicStore.Core.Entities;
using FluentNHibernate.Mapping;

namespace AngularMusicStore.Core.Persistence.Mappings
{
    public class AlbumMapping : ClassMap<Album>
    {
        public AlbumMapping()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.CoverUri);
            Map(x => x.ReleaseDate);
            References(x => x.Parent).Column("Artist_id").Cascade.None().Not.LazyLoad();
            HasMany(x => x.Tracks).Cascade.AllDeleteOrphan().Not.LazyLoad();
        }
    }
}