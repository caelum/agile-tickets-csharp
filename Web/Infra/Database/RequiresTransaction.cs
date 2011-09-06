using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;

namespace AgileTickets.Web.Infra.Database
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RequiresTransaction : ActionFilterAttribute
    {
        public ISession session { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            session.BeginTransaction();
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            try
            {
                if (session.Transaction != null) session.Transaction.Commit();
            }
            catch
            {
                session.Transaction.Rollback();
                throw;
            }
        }
    }
}