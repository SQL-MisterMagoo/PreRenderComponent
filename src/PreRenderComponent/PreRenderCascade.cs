using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using System.Reflection;

namespace PreRenderComponent
{
	public class PreRenderCascade : ComponentBase
	{
		[Parameter] protected RenderFragment ChildContent { get; set; }
		bool IsPreRendering { get; set; }
		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			DetectRenderMode(builder);
			base.BuildRenderTree(builder);
			builder.OpenComponent<CascadingValue<bool>>(0);
			builder.AddAttribute(1, "Value", IsPreRendering);
			builder.AddAttribute(2, "Name", "PreRendering");
			builder.AddAttribute(3, "ChildContent", ChildContent);
			builder.CloseComponent();
		}

		private void DetectRenderMode(RenderTreeBuilder builder)
		{
			try
			{
				var btype = builder.GetType();
				var rendererFI = btype.GetField("_renderer", BindingFlags.NonPublic | BindingFlags.Instance);
				if (rendererFI is null)
				{
					IsPreRendering = false;
					return;
				}
				var renderer = rendererFI.GetValue(builder);
				if (renderer is null)
				{
					IsPreRendering = false;
					return;
				}
				var rendererType = renderer.GetType();
				if (rendererType is null)
				{
					IsPreRendering = false;
					return;
				}
				var renderModeFI = rendererType.GetField("_prerenderMode", BindingFlags.NonPublic | BindingFlags.Instance);
				if (renderModeFI is null)
				{
					IsPreRendering = false;
					return;
				}

				IsPreRendering = (bool)renderModeFI.GetValue(renderer);
			}
			catch
			{
				// older previews didn't have pre-render
			}
		}
	}
}
