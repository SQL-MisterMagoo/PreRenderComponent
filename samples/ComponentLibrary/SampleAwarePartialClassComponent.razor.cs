using Microsoft.AspNetCore.Components;
using PreRenderComponent;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComponentLibrary
{
    public partial class SampleAwarePartialClassComponent : OwningComponentBase
    {
        IPreRenderFlag PreRenderFlag { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            try
            {
                PreRenderFlag = (IPreRenderFlag)ScopedServices.GetService(typeof(IPreRenderFlag));
            }
            catch
            {
            }
        }
    }
}
