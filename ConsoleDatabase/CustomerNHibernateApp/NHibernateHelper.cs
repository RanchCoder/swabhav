using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using CustomerNHibernateApp.Model;

namespace CustomerNHibernateApp
{

   public class NHibernatHelper
    {
        private static ISessionFactory _sessionFactory;


        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();
                return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {

            string connectionString = System.Configuration.ConfigurationManager.AppSettings["connection_string"];

            _sessionFactory = Fluently.Configure()
                 .Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(@"server=.\SQLEXPRESS; Database=swabhav;User Id=sa;Password=root;")
                .ShowSql()).
                Mappings(m => m.FluentMappings.AddFromAssemblyOf<Contact>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, false))
                .BuildSessionFactory();
        }

        /* Create session */
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}

