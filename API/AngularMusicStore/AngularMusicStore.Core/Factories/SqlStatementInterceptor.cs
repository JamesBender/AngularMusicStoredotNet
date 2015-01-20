using System.Diagnostics;
using NHibernate;
using NHibernate.SqlCommand;

namespace AngularMusicStore.Core.Factories
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class SqlStatementInterceptor : EmptyInterceptor
    {
        public override SqlString OnPrepareStatement(SqlString sql)
        {
            Trace.WriteLine(sql.ToString());
            Debug.WriteLine(sql.ToString());
            return base.OnPrepareStatement(sql);
        }
    }
}