using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace PreRenderComponent
{
	public class PreRenderCascade : ComponentBase
	{
		[Parameter] public RenderFragment ChildContent { get; set; }
		[Inject] IPreRenderFlag PreRenderFlag { get; set; }
		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			base.BuildRenderTree(builder);
			builder.OpenComponent<CascadingValue<bool>>(0);
			builder.AddAttribute(1, "Value", PreRenderFlag.IsPreRendering);
			builder.AddAttribute(2, "Name", "PreRendering");
			builder.AddAttribute(3, "ChildContent", ChildContent);
			builder.CloseComponent();
		}

	}
}
