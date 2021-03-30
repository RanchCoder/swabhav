using FluentNHibernate.Cfg;
using NHibernate;
using FluentNHibernate.Cfg.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Tool.hbm2ddl;

namespace CustomerOrderLineItem
{
   public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory SessionFactory {
            get {
                if (_sessionFactory == null)
                    InitializeSessionFactory(); return _sessionFactory;    
                
            }
        }

        public static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                              .Database(MsSqlConfiguration.MsSql2012.ConnectionString("server=.\\SQLEXPRESS;Database=customerOrderLineItem;User Id=sa;Password=root"))
                              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                              .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, false))
                              .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
