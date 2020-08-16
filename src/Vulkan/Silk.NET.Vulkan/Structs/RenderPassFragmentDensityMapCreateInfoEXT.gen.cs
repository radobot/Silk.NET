// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using System.Runtime.InteropServices;
using System.Text;
using Silk.NET.Core.Native;
using Silk.NET.Core.Attributes;
using Silk.NET.Core.Contexts;
using Silk.NET.Core.Loader;

#pragma warning disable 1591

namespace Silk.NET.Vulkan
{
    [NativeName("Name", "VkRenderPassFragmentDensityMapCreateInfoEXT")]
    public unsafe partial struct RenderPassFragmentDensityMapCreateInfoEXT
    {
        public RenderPassFragmentDensityMapCreateInfoEXT
        (
            StructureType sType = StructureType.RenderPassFragmentDensityMapCreateInfoExt,
            void* pNext = default,
            AttachmentReference fragmentDensityMapAttachment = default
        )
        {
            SType = sType;
            PNext = pNext;
            FragmentDensityMapAttachment = fragmentDensityMapAttachment;
        }

/// <summary></summary>
        [NativeName("Type", "VkStructureType")]
        [NativeName("Type.Name", "VkStructureType")]
        [NativeName("Name", "sType")]
        public StructureType SType;
/// <summary></summary>
        [NativeName("Type", "void*")]
        [NativeName("Type.Name", "void")]
        [NativeName("Name", "pNext")]
        public void* PNext;
/// <summary></summary>
        [NativeName("Type", "VkAttachmentReference")]
        [NativeName("Type.Name", "VkAttachmentReference")]
        [NativeName("Name", "fragmentDensityMapAttachment")]
        public AttachmentReference FragmentDensityMapAttachment;
    }
}
