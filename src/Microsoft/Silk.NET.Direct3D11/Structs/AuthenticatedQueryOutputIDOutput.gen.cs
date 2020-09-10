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
    [NativeName("Name", "D3D11_AUTHENTICATED_QUERY_OUTPUT_ID_OUTPUT")]
    public unsafe partial struct AuthenticatedQueryOutputIDOutput
    {
        public AuthenticatedQueryOutputIDOutput
        (
            AuthenticatedQueryOutput output = default,
            void* deviceHandle = default,
            void* cryptoSessionHandle = default,
            uint outputIDIndex = default,
            ulong outputID = default
        )
        {
            Output = output;
            DeviceHandle = deviceHandle;
            CryptoSessionHandle = cryptoSessionHandle;
            OutputIDIndex = outputIDIndex;
            OutputID = outputID;
        }


        [NativeName("Type", "D3D11_AUTHENTICATED_QUERY_OUTPUT")]
        [NativeName("Type.Name", "D3D11_AUTHENTICATED_QUERY_OUTPUT")]
        [NativeName("Name", "Output")]
        public AuthenticatedQueryOutput Output;

        [NativeName("Type", "HANDLE")]
        [NativeName("Type.Name", "HANDLE")]
        [NativeName("Name", "DeviceHandle")]
        public void* DeviceHandle;

        [NativeName("Type", "HANDLE")]
        [NativeName("Type.Name", "HANDLE")]
        [NativeName("Name", "CryptoSessionHandle")]
        public void* CryptoSessionHandle;

        [NativeName("Type", "UINT")]
        [NativeName("Type.Name", "UINT")]
        [NativeName("Name", "OutputIDIndex")]
        public uint OutputIDIndex;

        [NativeName("Type", "UINT64")]
        [NativeName("Type.Name", "UINT64")]
        [NativeName("Name", "OutputID")]
        public ulong OutputID;
    }
}