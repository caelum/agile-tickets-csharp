using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using FluentNHibernate;
using AgileTickets.Web.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace AgileTickets.Web.Infra.Database
{
    public class DatabaseConfigurator
    {
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure().Database(
                MySQLConfiguration.Standard.ConnectionString(c => c.FromAppSetting("connection_string"))
            ).Mappings(m =>
            {
                m.FluentMappings.AddFromAssemblyOf<Estabelecimento>();
            }).BuildSessionFactory();
            
        }
    }
}