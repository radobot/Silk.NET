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

namespace Silk.NET.Direct3D12
{
    [NativeName("Name", "D3D12_DESCRIPTOR_RANGE1")]
    public unsafe partial struct DescriptorRange1
    {
        public DescriptorRange1
        (
            DescriptorRangeType rangeType = default,
            uint numDescriptors = default,
            uint baseShaderRegister = default,
            uint registerSpace = default,
            DescriptorRangeFlags flags = default,
            uint offsetInDescriptorsFromTableStart = default
        )
        {
            RangeType = rangeType;
            NumDescriptors = numDescriptors;
            BaseShaderRegister = baseShaderRegister;
            RegisterSpace = registerSpace;
            Flags = flags;
            OffsetInDescriptorsFromTableStart = offsetInDescriptorsFromTableStart;
        }


        [NativeName("Type", "D3D12_DESCRIPTOR_RANGE_TYPE")]
        [NativeName("Type.Name", "D3D12_DESCRIPTOR_RANGE_TYPE")]
        [NativeName("Name", "RangeType")]
        public DescriptorRangeType RangeType;

        [NativeName("Type", "UINT")]
        [NativeName("Type.Name", "UINT")]
        [NativeName("Name", "NumDescriptors")]
        public uint NumDescriptors;

        [NativeName("Type", "UINT")]
        [NativeName("Type.Name", "UINT")]
        [NativeName("Name", "BaseShaderRegister")]
        public uint BaseShaderRegister;

        [NativeName("Type", "UINT")]
        [NativeName("Type.Name", "UINT")]
        [NativeName("Name", "RegisterSpace")]
        public uint RegisterSpace;

        [NativeName("Type", "D3D12_DESCRIPTOR_RANGE_FLAGS")]
        [NativeName("Type.Name", "D3D12_DESCRIPTOR_RANGE_FLAGS")]
        [NativeName("Name", "Flags")]
        public DescriptorRangeFlags Flags;

        [NativeName("Type", "UINT")]
        [NativeName("Type.Name", "UINT")]
        [NativeName("Name", "OffsetInDescriptorsFromTableStart")]
        public uint OffsetInDescriptorsFromTableStart;
    }
}