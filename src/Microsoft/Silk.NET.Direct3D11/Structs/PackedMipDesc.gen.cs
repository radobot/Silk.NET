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

namespace Silk.NET.Direct3D11
{
    [NativeName("Name", "D3D11_PACKED_MIP_DESC")]
    public unsafe partial struct PackedMipDesc
    {
        public PackedMipDesc
        (
            byte numStandardMips = default,
            byte numPackedMips = default,
            uint numTilesForPackedMips = default,
            uint startTileIndexInOverallResource = default
        )
        {
            NumStandardMips = numStandardMips;
            NumPackedMips = numPackedMips;
            NumTilesForPackedMips = numTilesForPackedMips;
            StartTileIndexInOverallResource = startTileIndexInOverallResource;
        }


        [NativeName("Type", "UINT8")]
        [NativeName("Type.Name", "UINT8")]
        [NativeName("Name", "NumStandardMips")]
        public byte NumStandardMips;

        [NativeName("Type", "UINT8")]
        [NativeName("Type.Name", "UINT8")]
        [NativeName("Name", "NumPackedMips")]
        public byte NumPackedMips;

        [NativeName("Type", "UINT")]
        [NativeName("Type.Name", "UINT")]
        [NativeName("Name", "NumTilesForPackedMips")]
        public uint NumTilesForPackedMips;

        [NativeName("Type", "UINT")]
        [NativeName("Type.Name", "UINT")]
        [NativeName("Name", "StartTileIndexInOverallResource")]
        public uint StartTileIndexInOverallResource;
    }
}