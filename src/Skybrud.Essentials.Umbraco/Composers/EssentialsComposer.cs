using Microsoft.Extensions.DependencyInjection;
using Skybrud.Essentials.Umbraco.Scheduling;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Skybrud.Essentials.Umbraco.Composers {

    internal class EssentialsComposer : IComposer {

        public void Compose(IUmbracoBuilder builder) {
            builder.Services.AddTransient<TaskHelper>();
        }

    }

}