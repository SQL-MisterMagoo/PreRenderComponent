using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;
using System;

namespace PreRenderComponent
{
    public class PreRenderFlag : IPreRenderFlag
    {
        private bool _isPreRendering = false;
#nullable enable
        [Inject] IJSRuntime? JSRuntime { get; set; }
#nullable disable
        public PreRenderFlag()
        {
            if (JSRuntime is null || !(JSRuntime is IJSInProcessRuntime))
            {
                throw new ApplicationException("Please add an HttpContextAccessor to detect PreRendering");
            }
        }
        public PreRenderFlag(IHttpContextAccessor httpContextAccessor)
        {
            HttpContext = httpContextAccessor.HttpContext;
            if (HttpContext.Response.HasStarted)
            {
                _isPreRendering = false;
            }
            else
            {
                _isPreRendering = true;
            }
        }
        public bool IsPreRendering { get => _isPreRendering; }
        public HttpContext HttpContext { get; }
    }
}
