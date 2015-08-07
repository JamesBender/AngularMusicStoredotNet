using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularMusicStore.Core.Entities;
using FluentNHibernate.Mapping;

namespace AngularMusicStore.Core.Persistence.Mappings
{
    class TrackMapping : ClassMap<Track>
    {
        public TrackMapping()
        {
            Id(x => x.Id);
            Map(x => x.AlbumOrder);
            Map(x => x.Name);
            Map(x => x.Length);
            Map(x => x.Rating);
            //            References(x => x.Parent).Column("Artist_id").Cascade.None().Not.LazyLoad();
            References(x => x.Parent).Column("Album_id").Cascade.None().Not.LazyLoad();
        }
    }
}
