using System.Configuration;
using AngularMusicStore.Core.Entities;
using AngularMusicStore.Core.Persistence;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Ninject.Activation;

namespace AngularMusicStore.Core.Factories
{
    public class SessionFactoryProvider : Provider<ISessionFactory>
    {
        protected override ISessionFactory CreateInstance(IContext context)
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(c => c.Is(ConfigurationManager.ConnectionStrings["AngularMusicStore"].ToString())))
                .Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<Artist>(new EntityConfiguration())
                    .IgnoreBase<BaseEntity>().Conventions.Setup(x =>
                    {
                        x.Add(DefaultCascade.All());
                        x.Add(DefaultLazy.Never());
                    })))
                    .ExposeConfiguration(cfg =>
                    {
                        var schemaExport = new SchemaExport(cfg);
                        schemaExport.Drop(true, true);
                        schemaExport.Create(true, true);
                    })
                    .BuildSessionFactory();
        }
    }
}