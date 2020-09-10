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
    [NativeName("Name", "D3D12_RAYTRACING_PIPELINE_CONFIG")]
    public unsafe partial struct RaytracingPipelineConfig
    {
        public RaytracingPipelineConfig
        (
            uint maxTraceRecursionDepth = default
        )
        {
            MaxTraceRecursionDepth = maxTraceRecursionDepth;
        }


        [NativeName("Type", "UINT")]
        [NativeName("Type.Name", "UINT")]
        [NativeName("Name", "MaxTraceRecursionDepth")]
        public uint MaxTraceRecursionDepth;
    }
}