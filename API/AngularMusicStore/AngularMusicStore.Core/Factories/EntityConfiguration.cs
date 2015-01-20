using System;
using FluentNHibernate.Automapping;

namespace AngularMusicStore.Core.Factories
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class EntityConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.Namespace == "AngularMusicStore.Core.Entities";
        }
    }
}