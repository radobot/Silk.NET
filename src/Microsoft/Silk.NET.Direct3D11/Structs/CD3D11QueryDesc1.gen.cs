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
    [NativeName("Name", "CD3D11_QUERY_DESC1")]
    public unsafe partial struct CD3D11QueryDesc1
    {
        public CD3D11QueryDesc1
        (
            Query query = default,
            uint miscFlags = default,
            ContextType contextType = default
        )
        {
            Query = query;
            MiscFlags = miscFlags;
            ContextType = contextType;
        }


        [NativeName("Type", "D3D11_QUERY")]
        [NativeName("Type.Name", "D3D11_QUERY")]
        [NativeName("Name", "Query")]
        public Query Query;

        [NativeName("Type", "UINT")]
        [NativeName("Type.Name", "UINT")]
        [NativeName("Name", "MiscFlags")]
        public uint MiscFlags;

        [NativeName("Type", "D3D11_CONTEXT_TYPE")]
        [NativeName("Type.Name", "D3D11_CONTEXT_TYPE")]
        [NativeName("Name", "ContextType")]
        public ContextType ContextType;
    }
}