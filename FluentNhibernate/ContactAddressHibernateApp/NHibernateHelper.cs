using NHibernate;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Tool.hbm2ddl;

namespace ContactAddressHibernateApp
{
    class NHibernateHelper
    {
        private ISessionFactory _sessionFactory;
        public virtual ISessionFactory SessionFactory
        {
            get
            {
                if(_sessionFactory == null)
                {
                    InitializeSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public virtual void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString("server=.\\SQLEXPRESS;database=ContactAddress;User Id=sa;Password=root;"))
                .Mappings(m=>m.FluentMappings.AddFromAssemblyOf<Program>())
                .ExposeConfiguration(cfg=>new SchemaExport(cfg).Create(true,false))
                .BuildSessionFactory();
        }

        public virtual ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
