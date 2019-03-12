# PreRenderComponent

Provides a CascadingValue exposing whether the app is in PreRendering or not.

## Usage

Install the nuget https://nuget.org/packages/PreRenderComponent

Add references to Components/_ViewImports.cshtml

```
@using PreRenderComponent
@addTagHelper *, PreRenderComponent
```

Wrap the Router component in PreRenderCascade in the App.razor file

```
<PreRenderCascade>
    <Router AppAssembly="typeof(Startup).Assembly" />
</PreRenderCascade>
```

Consume the CascadingValue in your own pages/components

```
@if (IsPreRendering)
{
  <button class="btn btn-dark" onclick="@IncrementCount" disabled>Don't Click me</button>
}
else
{
  <button class="btn btn-primary" onclick="@IncrementCount">Click me</button>
}


@functions {
[CascadingParameter(Name = "PreRendering")] 
protected bool IsPreRendering { get; set; }
}
```


