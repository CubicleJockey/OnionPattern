using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace OnionPattern.Api.StartupConfigurations
{
    /// <inheritdoc />
    /// <summary>
    /// 
    /// </summary>
    public class DefaultRoutePrefixConvention : IApplicationModelConvention
    {
        /// <inheritdoc />
        public void Apply(ApplicationModel application)
        {
            foreach (var applicationController in application.Controllers)
            {
                applicationController.Selectors.Add(new SelectorModel
                {
                    AttributeRouteModel = new AttributeRouteModel
                    {
                        Template = "api/[controller]"
                    }
                });
            }
        }
    }
}
