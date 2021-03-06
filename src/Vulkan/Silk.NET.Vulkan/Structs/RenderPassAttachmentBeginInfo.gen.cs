// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.


using System;
using System.Runtime.InteropServices;
using System.Text;
using Silk.NET.Core.Native;
using Ultz.SuperInvoke;

#pragma warning disable 1591

namespace Silk.NET.Vulkan
{
    public unsafe struct RenderPassAttachmentBeginInfo
    {
        public RenderPassAttachmentBeginInfo
        (
            StructureType sType = StructureType.RenderPassAttachmentBeginInfo,
            void* pNext = default,
            uint attachmentCount = default,
            ImageView* pAttachments = default
        )
        {
           SType = sType;
           PNext = pNext;
           AttachmentCount = attachmentCount;
           PAttachments = pAttachments;
        }

/// <summary></summary>
        public StructureType SType;
/// <summary></summary>
        public void* PNext;
/// <summary></summary>
        public uint AttachmentCount;
/// <summary></summary>
        public ImageView* PAttachments;
    }
}
