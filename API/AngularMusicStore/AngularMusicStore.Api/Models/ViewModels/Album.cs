using System;
using System.Collections;
using System.Collections.Generic;

namespace AngularMusicStore.Api.Models.ViewModels
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CoverUri { get; set; }
        public Artist Parent { get; set; }
        public IList<Track> Tracks { get; protected set; }

        public Album()
        {
            Tracks = new List<Track>();
        }

        public void AddTrack(Track track)
        {
            track.Parent = this;
            Tracks.Add(track);
        }
    }
}