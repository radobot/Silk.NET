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
    [NativeName("Name", "D3D12_FEATURE_DATA_VIDEO_PROCESSOR_SIZE")]
    public unsafe partial struct FeatureDataVideoProcessorSize
    {
        public FeatureDataVideoProcessorSize
        (
            uint nodeMask = default,
            VideoProcessOutputStreamDesc* pOutputStreamDesc = default,
            uint numInputStreamDescs = default,
            VideoProcessInputStreamDesc* pInputStreamDescs = default,
            ulong memoryPoolL0Size = default,
            ulong memoryPoolL1Size = default
        )
        {
            NodeMask = nodeMask;
            POutputStreamDesc = pOutputStreamDesc;
            NumInputStreamDescs = numInputStreamDescs;
            PInputStreamDescs = pInputStreamDescs;
            MemoryPoolL0Size = memoryPoolL0Size;
            MemoryPoolL1Size = memoryPoolL1Size;
        }


        [NativeName("Type", "UINT")]
        [NativeName("Type.Name", "UINT")]
        [NativeName("Name", "NodeMask")]
        public uint NodeMask;

        [NativeName("Type", "const D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC *")]
        [NativeName("Type.Name", "const D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC *")]
        [NativeName("Name", "pOutputStreamDesc")]
        public VideoProcessOutputStreamDesc* POutputStreamDesc;

        [NativeName("Type", "UINT")]
        [NativeName("Type.Name", "UINT")]
        [NativeName("Name", "NumInputStreamDescs")]
        public uint NumInputStreamDescs;

        [NativeName("Type", "const D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC *")]
        [NativeName("Type.Name", "const D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC *")]
        [NativeName("Name", "pInputStreamDescs")]
        public VideoProcessInputStreamDesc* PInputStreamDescs;

        [NativeName("Type", "UINT64")]
        [NativeName("Type.Name", "UINT64")]
        [NativeName("Name", "MemoryPoolL0Size")]
        public ulong MemoryPoolL0Size;

        [NativeName("Type", "UINT64")]
        [NativeName("Type.Name", "UINT64")]
        [NativeName("Name", "MemoryPoolL1Size")]
        public ulong MemoryPoolL1Size;
    }
}