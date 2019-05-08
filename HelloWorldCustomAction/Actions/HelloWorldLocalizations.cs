using System.Collections.Generic;
using Cireson.Core.DataAccess.Extensions;
using Cireson.Core.DataAccess.Models;
using Cireson.Core.Interfaces.DataAccess;
using Cireson.Core.Interfaces.LifecycleInterfaces;
using Microsoft.Practices.Unity;

namespace HelloWorldCustomAction.Actions
{
    /// <summary>
    /// Executes at specified bootstrap stage Stages after S0150_AppDomainConfig will be available to Extensions.  
    /// Earlier stages are only for internal Platform use, and will be ignored in Extensions.
    /// </summary>
    [BootstrapStage(BootstrapStage.S0640_DataContextReady, Order = 0)]
    public class Localizations : IBootstrapHandler
    {
        public void OnExecute(IBootstrapStageManager manager)
        {
            var container = manager.GetBootstrapComponent<Cireson.Core.Interfaces.Containers.IPlatformContainer>().CommonContainer;
            var dataContext = container.Resolve<IDataContext>();

            var localizations = new List<Localization>
                {
                    // Set Action Name Value
                    // This will be the displayed name for your custom action
                    // Replace default value with your action name
                    new Localization { Key = "HelloWorld", Value = "Hello World", Description = "Custom Action Name"},
                    // Set Icon Value
                    // This will be the actual icon to be displayed in your custom action button
                    // Replace default value with the desired icon name
                    new Localization { Key = "HelloWorldIcon", Value = "attention", Description = "Custom Action Icon"},
                    // Set Category Title
                    // This is used for templating purposes and it is displayed under remote actions flyout
                    // Default: Custom Actions
                    // Currently only displayed for Remote Actions
                    new Localization { Key = "RCA", Value = "Custom Actions", Description = "Category Title"}
            };

            dataContext.Set<Localization>().UpsertSmartDefaults(localizations,
                (l1, l2) => l1.Key == l2.Key && l1.Culture == l2.Culture,
                l => l.Description,
                l => l.Value);
            dataContext.SaveChanges();
        }
    }
}