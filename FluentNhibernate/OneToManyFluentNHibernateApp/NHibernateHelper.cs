using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace OneToManyFluentNHibernateApp
{

    public class NHibernateHelper
    {

        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory(); return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                                       .Database(MsSqlConfiguration.MsSql2012.ConnectionString("server=.\\SQLEXPRESS; Database=swabhav;User Id=sa;Password=root"))
                                       .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                                                                      .ExposeConfiguration(cfg => new SchemaExport(cfg)
                                                                      .Create(true, false))
                                                                      .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

    }
    }
