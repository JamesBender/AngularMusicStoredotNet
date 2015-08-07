using System;

namespace AngularMusicStore.Core.Entities
{
    public class Track : BaseEntity
    {
        public virtual Album Parent { get; set; }
        public virtual int AlbumOrder { get; set; }
        public virtual TimeSpan Length { get; set; }
        public virtual string Name { get; set; }
        public virtual int Rating { get; set; }

    }
}
