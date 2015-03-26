using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using AngularMusicStore.Core.Entities;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Ninject.Activation;

namespace AngularMusicStore.Core.Factories
{
    [ExcludeFromCodeCoverage]
    public class SessionFactoryProvider : Provider<ISessionFactory>
    {
        protected override ISessionFactory CreateInstance(IContext context)
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(c => c.Is(ConfigurationManager.ConnectionStrings["AngularMusicStore"].ToString())))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<BaseEntity>())
//                .ExposeConfiguration(cfg =>
//                {
//                    var schemaExport = new SchemaExport(cfg);
//                    schemaExport.Drop(false, true);
//                    schemaExport.Create(false, true);
//                })
                .BuildSessionFactory();
        }
    }
}