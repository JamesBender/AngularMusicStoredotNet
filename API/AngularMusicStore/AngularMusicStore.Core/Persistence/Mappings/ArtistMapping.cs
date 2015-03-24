using AngularMusicStore.Core.Entities;
using FluentNHibernate.Mapping;

namespace AngularMusicStore.Core.Persistence.Mappings
{
    public class ArtistMapping : ClassMap<Artist>
    {
        public ArtistMapping()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            HasMany(x => x.Albums).Cascade.AllDeleteOrphan().Not.LazyLoad();
            HasMany(x => x.RelatedArtists).Not.LazyLoad();
        } 
    }
}