using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Autofac;
using Autofac.Integration.Mvc;
using Autoshop.Infrastructure;

namespace AutoShop.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Стандартная настройка MVC
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Настройка Autofac
            var builder = new ContainerBuilder();

            // Регистрация DbContext. Предполагается, что MyStoreContext - ваш класс контекста
            builder.RegisterType<JewelryStoreContext>().AsSelf().InstancePerRequest();

            // Остальные регистрации зависимостей
            // builder.RegisterType<SomeDependency>().As<ISomeInterface>();

            // Создаем новый контейнер с зарегистрированными зависимостями
            var container = builder.Build();

            // Заменяем стандартный DependencyResolver на AutofacDependencyResolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
        
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket != null && !authTicket.Expired)
                {
                    var roles = authTicket.UserData.Split(',');
                    HttpContext.Current.User = new GenericPrincipal(new FormsIdentity(authTicket), roles);
                }
            }
        }
    }
}