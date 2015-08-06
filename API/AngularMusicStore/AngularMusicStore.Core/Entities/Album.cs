﻿using System;

namespace AngularMusicStore.Core.Entities
{
    public class Album : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual DateTime ReleaseDate { get; set; }
        public virtual string CoverUri { get; set; }
        public virtual Artist Parent { get; set; }
        
    }
}