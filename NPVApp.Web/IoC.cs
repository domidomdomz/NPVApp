using NPVApp.Business;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace NPVApp.Web
{
    public class IoC
    {
        public Container Container { get; set; }

        public IoC()
        {
            Container = new Container();
            Container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            Container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            RegisterClasses();
            Container.Verify();
        }

        private void RegisterClasses()
        {
            var lifeStyle = Lifestyle.Scoped;

            // Business
            Container.Register<IDB, DB>(lifeStyle);
            Container.Register<ICalculationLogic, CalculationLogic>(lifeStyle);
            Container.Register<ICalculateNPVResultsLogic, CalculateNPVResultsLogic>(lifeStyle);
            Container.Register<ICalculateNPVRequestsLogic, CalculateNPVRequestsLogic>(lifeStyle);
        }

        public TInterface Resolve<TInterface>()
            where TInterface : class
        {
            return Container.GetInstance<TInterface>();
        }
    }
}