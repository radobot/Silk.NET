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
    [NativeName("Name", "D3D12_ROOT_SIGNATURE_DESC1")]
    public unsafe partial struct RootSignatureDesc1
    {
        public RootSignatureDesc1
        (
            uint numParameters = default,
            RootParameter1* pParameters = default,
            uint numStaticSamplers = default,
            StaticSamplerDesc* pStaticSamplers = default,
            RootSignatureFlags flags = default
        )
        {
            NumParameters = numParameters;
            PParameters = pParameters;
            NumStaticSamplers = numStaticSamplers;
            PStaticSamplers = pStaticSamplers;
            Flags = flags;
        }


        [NativeName("Type", "UINT")]
        [NativeName("Type.Name", "UINT")]
        [NativeName("Name", "NumParameters")]
        public uint NumParameters;

        [NativeName("Type", "const D3D12_ROOT_PARAMETER1 *")]
        [NativeName("Type.Name", "const D3D12_ROOT_PARAMETER1 *")]
        [NativeName("Name", "pParameters")]
        public RootParameter1* PParameters;

        [NativeName("Type", "UINT")]
        [NativeName("Type.Name", "UINT")]
        [NativeName("Name", "NumStaticSamplers")]
        public uint NumStaticSamplers;

        [NativeName("Type", "const D3D12_STATIC_SAMPLER_DESC *")]
        [NativeName("Type.Name", "const D3D12_STATIC_SAMPLER_DESC *")]
        [NativeName("Name", "pStaticSamplers")]
        public StaticSamplerDesc* PStaticSamplers;

        [NativeName("Type", "D3D12_ROOT_SIGNATURE_FLAGS")]
        [NativeName("Type.Name", "D3D12_ROOT_SIGNATURE_FLAGS")]
        [NativeName("Name", "Flags")]
        public RootSignatureFlags Flags;
    }
}