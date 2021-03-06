# PreRenderComponent

Provides a DI Service and/or a CascadingValue exposing whether the app is in PreRendering or not.

## Usage

Install the nuget https://nuget.org/packages/PreRenderComponent

### Add the service (Required)
Add the service to your startup Configure method
This component has a dependency on HttpContextAccessor, so also add that.

``` CSharp
services.AddHttpContextAccessor();
services.AddScoped<IPreRenderFlag,PreRenderFlag>();
```

Consume the service wherever you need it (unless you want to use the Cascading Value component)
``` HTML
@inject PreRenderComponent.IPreRenderFlag PreRenderFlag
@if (PreRenderFlag.IsPreRendering)
{
    <h1>Pre-Rendering</h1>
}
```
### Cascading Value (Optional)
Wrap the Router component in PreRenderCascade in the App.razor file

``` HTML
<PreRenderComponent.PreRenderCascade>
    <Router AppAssembly="typeof(App).Assembly">
        <Found Context="routeData">
            <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
        </Found>
        <NotFound>
            <LayoutView Layout="@typeof(MainLayout)">
                <p>Sorry, there's nothing at this address.</p>
            </LayoutView>
        </NotFound>
    </Router>
</PreRenderComponent.PreRenderCascade>
```

Consume the CascadingValue in your own pages/components

``` CSharp
@if (IsPreRendering)
{
  <button class="btn btn-dark" onclick="@IncrementCount" disabled>Don't Click me</button>
}
else
{
  <button class="btn btn-primary" onclick="@IncrementCount">Click me</button>
}


@code {
[CascadingParameter(Name = "PreRendering")] 
protected bool IsPreRendering { get; set; }
}
```


