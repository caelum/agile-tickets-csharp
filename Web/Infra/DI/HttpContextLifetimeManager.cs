using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;

namespace AgileTickets.Web.Infra.DI
{
    public class HttpContextLifetimeManager<T> : LifetimeManager, IDisposable
    {
        private Func<T, bool> close;

        public HttpContextLifetimeManager(Func<T, bool> close)
        {
            this.close = close;
        }

        public override object GetValue()
        {
            return HttpContext.Current.Items[typeof(T).AssemblyQualifiedName];
        }

        public override void RemoveValue()
        {
            HttpContext.Current.Items.Remove(typeof(T).AssemblyQualifiedName);
        }

        public override void SetValue(object newValue)
        {
            HttpContext.Current.Items[typeof(T).AssemblyQualifiedName] = newValue;
        }

        public void Dispose()
        {
            T obj = (T) HttpContext.Current.Items[typeof(T).AssemblyQualifiedName];
            RemoveValue();
            if(obj!=null) close(obj);
        }
    }
}