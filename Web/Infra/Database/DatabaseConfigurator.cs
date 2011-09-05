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
            return SetEntities().BuildSessionFactory();
            
        }

        public static FluentConfiguration SetEntities()
        {
            return Fluently.Configure().Database(
                            SQLiteConfiguration.Standard.UsingFile("agiletickets.db")
                            //MySQLConfiguration.Standard.ConnectionString("Server=localhost;Database=agileticketscsharp;Uid=root;Pwd=;")
                        ).Mappings(m =>
                        {
                            m.FluentMappings.AddFromAssemblyOf<DatabaseConfigurator>();
                        });
        }
    }
}