using System;

namespace AngularMusicStore.Core.Entities
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
    }
}