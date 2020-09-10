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
    [NativeName("Name", "ID3D12DebugDevice")]
    public unsafe partial struct ID3D12DebugDevice
    {
        public ID3D12DebugDevice
        (
            void** lpVtbl = default
        )
        {
            LpVtbl = lpVtbl;
        }


        [NativeName("Type", "")]
        [NativeName("Type.Name", "")]
        [NativeName("Name", "lpVtbl")]
        public void** LpVtbl;
        /// <summary>To be added.</summary>
        public unsafe int QueryInterface(Guid* riid, void** ppvObject)
        {
            fixed (ID3D12DebugDevice* @this = &this)
            {
                int ret = default;
                ret = ((delegate* cdecl<ID3D12DebugDevice*, Guid*, void**, int>)LpVtbl[0])(@this, riid, ppvObject);
                return ret;
            }
        }

        /// <summary>To be added.</summary>
        public unsafe int QueryInterface(Guid* riid, ref void* ppvObject)
        {
            fixed (ID3D12DebugDevice* @this = &this)
            {
                int ret = default;
                fixed (void** ppvObjectPtr = &ppvObject)
                {
                    ret = ((delegate* cdecl<ID3D12DebugDevice*, Guid*, void**, int>)LpVtbl[0])(@this, riid, ppvObjectPtr);
                }
                return ret;
            }
        }

        /// <summary>To be added.</summary>
        public unsafe int QueryInterface(ref Guid riid, void** ppvObject)
        {
            fixed (ID3D12DebugDevice* @this = &this)
            {
                int ret = default;
                fixed (Guid* riidPtr = &riid)
                {
                    ret = ((delegate* cdecl<ID3D12DebugDevice*, Guid*, void**, int>)LpVtbl[0])(@this, riidPtr, ppvObject);
                }
                return ret;
            }
        }

        /// <summary>To be added.</summary>
        public unsafe int QueryInterface(ref Guid riid, ref void* ppvObject)
        {
            fixed (ID3D12DebugDevice* @this = &this)
            {
                int ret = default;
                fixed (Guid* riidPtr = &riid)
                {
                    fixed (void** ppvObjectPtr = &ppvObject)
                    {
                        ret = ((delegate* cdecl<ID3D12DebugDevice*, Guid*, void**, int>)LpVtbl[0])(@this, riidPtr, ppvObjectPtr);
                    }
                }
                return ret;
            }
        }

        /// <summary>To be added.</summary>
        public uint AddRef()
        {
            fixed (ID3D12DebugDevice* @this = &this)
            {
                uint ret = default;
                ret = ((delegate* cdecl<ID3D12DebugDevice*, uint>)LpVtbl[1])(@this);
                return ret;
            }
        }

        /// <summary>To be added.</summary>
        public uint Release()
        {
            fixed (ID3D12DebugDevice* @this = &this)
            {
                uint ret = default;
                ret = ((delegate* cdecl<ID3D12DebugDevice*, uint>)LpVtbl[2])(@this);
                return ret;
            }
        }

        /// <summary>To be added.</summary>
        public int SetFeatureMask(DebugFeature Mask)
        {
            fixed (ID3D12DebugDevice* @this = &this)
            {
                int ret = default;
                ret = ((delegate* cdecl<ID3D12DebugDevice*, DebugFeature, int>)LpVtbl[3])(@this, Mask);
                return ret;
            }
        }

        /// <summary>To be added.</summary>
        public DebugFeature GetFeatureMask()
        {
            fixed (ID3D12DebugDevice* @this = &this)
            {
                DebugFeature ret = default;
                ret = ((delegate* cdecl<ID3D12DebugDevice*, DebugFeature>)LpVtbl[4])(@this);
                return ret;
            }
        }

        /// <summary>To be added.</summary>
        public int ReportLiveDeviceObjects(RldoFlags Flags)
        {
            fixed (ID3D12DebugDevice* @this = &this)
            {
                int ret = default;
                ret = ((delegate* cdecl<ID3D12DebugDevice*, RldoFlags, int>)LpVtbl[5])(@this, Flags);
                return ret;
            }
        }

    }
}