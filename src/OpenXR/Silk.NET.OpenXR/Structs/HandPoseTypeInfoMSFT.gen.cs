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

namespace Silk.NET.OpenXR
{
    [NativeName("Name", "XrHandPoseTypeInfoMSFT")]
    public unsafe partial struct HandPoseTypeInfoMSFT
    {
        public HandPoseTypeInfoMSFT
        (
            StructureType type = StructureType.TypeHandPoseTypeInfoMsft,
            void* next = default,
            HandPoseTypeMSFT handPoseType = default
        )
        {
            Type = type;
            Next = next;
            HandPoseType = handPoseType;
        }

/// <summary></summary>
        [NativeName("Type", "XrStructureType")]
        [NativeName("Type.Name", "XrStructureType")]
        [NativeName("Name", "type")]
        public StructureType Type;
/// <summary></summary>
        [NativeName("Type", "void*")]
        [NativeName("Type.Name", "void")]
        [NativeName("Name", "next")]
        public void* Next;
/// <summary></summary>
        [NativeName("Type", "XrHandPoseTypeMSFT")]
        [NativeName("Type.Name", "XrHandPoseTypeMSFT")]
        [NativeName("Name", "handPoseType")]
        public HandPoseTypeMSFT HandPoseType;
    }
}
