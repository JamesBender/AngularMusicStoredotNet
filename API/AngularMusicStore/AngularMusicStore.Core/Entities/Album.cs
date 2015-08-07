using System;
using System.Collections;
using System.Collections.Generic;

namespace AngularMusicStore.Core.Entities
{
    public class Album : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual DateTime ReleaseDate { get; set; }
        public virtual string CoverUri { get; set; }
        public virtual Artist Parent { get; set; }
        public virtual IList<Track> Tracks { get; protected set; }

        public Album()
        {
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            Tracks = new List<Track>();
        }

        public virtual void AddTrack(Track track)
        {
            track.Parent = this;
            Tracks.Add(track);
        }
    }
}