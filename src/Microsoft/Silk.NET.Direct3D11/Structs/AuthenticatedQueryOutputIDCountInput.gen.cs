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
    [NativeName("Name", "D3D11_AUTHENTICATED_QUERY_OUTPUT_ID_COUNT_INPUT")]
    public unsafe partial struct AuthenticatedQueryOutputIDCountInput
    {
        public AuthenticatedQueryOutputIDCountInput
        (
            AuthenticatedQueryInput input = default,
            void* deviceHandle = default,
            void* cryptoSessionHandle = default
        )
        {
            Input = input;
            DeviceHandle = deviceHandle;
            CryptoSessionHandle = cryptoSessionHandle;
        }


        [NativeName("Type", "D3D11_AUTHENTICATED_QUERY_INPUT")]
        [NativeName("Type.Name", "D3D11_AUTHENTICATED_QUERY_INPUT")]
        [NativeName("Name", "Input")]
        public AuthenticatedQueryInput Input;

        [NativeName("Type", "HANDLE")]
        [NativeName("Type.Name", "HANDLE")]
        [NativeName("Name", "DeviceHandle")]
        public void* DeviceHandle;

        [NativeName("Type", "HANDLE")]
        [NativeName("Type.Name", "HANDLE")]
        [NativeName("Name", "CryptoSessionHandle")]
        public void* CryptoSessionHandle;
    }
}