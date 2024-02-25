# `UmbracoContextAccessorExtensions` extension methods

In ASP.NET Core versions of Umbraco, the <code type="Umbraco.Cms.Core.Web.IUmbracoContextAccessor">IUmbracoContextAccessor</code> interface represents an injectable service that allows getting the current <code type="Umbraco.Cms.Core.Web.IUmbracoContext">IUmbracoContext</code> instance - if one is available.

The <code type="Umbraco.Cms.Core.Web.IUmbracoContextAccessor">IUmbracoContextAccessor</code> describes a `TryGetUmbracoContext` method as well as a `GetRequiredUmbracoContext` extension method.

The `TryGetUmbracoContext` generally works well when you need to check whether an <code type="Umbraco.Cms.Core.Web.IUmbracoContext">IUmbracoContext</code> is currently available, and the `GetRequiredUmbracoContext` extension method will get the current <code type="Umbraco.Cms.Core.Web.IUmbracoContext">IUmbracoContext</code> - or throw an exception if not available.

We have found ourselves in situations where it's not super important whether an <code type="Umbraco.Cms.Core.Web.IUmbracoContext">IUmbracoContext</code> is available - eg. because we have addtional checks further down our code. For this, we've introduced a `GetUmbracoContext` extension method that returns the <code type="Umbraco.Cms.Core.Web.IUmbracoContext">IUmbracoContext</code> if available, or <code>null</code> if not.

In the example below, we have a custom service that injects <code type="Umbraco.Cms.Core.Web.IUmbracoContextAccessor">IUmbracoContextAccessor</code>, and then uses our `GetUmbracoContext` as part of a method chain for finding the news list from the ID of it's parent site:

```csharp
using Skybrud.Essentials.Umbraco;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;

public class MyService {

    private readonly IUmbracoContextAccessor _umbracoContextAccessor;

    public MyService(IUmbracoContextAccessor umbracoContextAccessor) {
        _umbracoContextAccessor = umbracoContextAccessor;
    }

    public IPublishedContent? GetNewsList(int siteId) {
        return _umbracoContextAccessor
            .GetUmbracoContext()?.Content?
            .GetById(siteId)?
            .FirstChildOfType("newsList");

    }

}
```