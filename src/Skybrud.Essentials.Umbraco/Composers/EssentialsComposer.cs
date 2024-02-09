using Microsoft.Extensions.DependencyInjection;
using Skybrud.Essentials.Umbraco.Scheduling;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

#pragma warning disable CS1591

namespace Skybrud.Essentials.Umbraco.Composers;

public class EssentialsComposer : IComposer {

    public void Compose(IUmbracoBuilder builder) {
        builder.Services.AddTransient<TaskHelper>();
    }

}