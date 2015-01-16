using System;
using System.Collections.Generic;

namespace AngularMusicStore.Api.Models.ViewModels
{
    public class Artist
    {
        public Guid Id  { get; set; }
        public string Name { get; set; }
        public IList<Album> Albums { get; private set; }

        public Artist()
        {
            Albums = new List<Album>();
        }
    }
}