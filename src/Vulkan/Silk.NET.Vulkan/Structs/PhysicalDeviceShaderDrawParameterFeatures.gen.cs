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

namespace Silk.NET.Vulkan
{
    [NativeName("Name", "VkPhysicalDeviceShaderDrawParameterFeatures")]
    public unsafe partial struct PhysicalDeviceShaderDrawParameterFeatures
    {
        public PhysicalDeviceShaderDrawParameterFeatures
        (
            StructureType sType = StructureType.PhysicalDeviceShaderDrawParametersFeatures,
            void* pNext = default,
            Bool32 shaderDrawParameters = default
        )
        {
            SType = sType;
            PNext = pNext;
            ShaderDrawParameters = shaderDrawParameters;
        }

/// <summary></summary>
        [NativeName("Type", "VkStructureType")]
        [NativeName("Type.Name", "VkStructureType")]
        [NativeName("Name", "sType")]
        public StructureType SType;
/// <summary></summary>
        [NativeName("Type", "void*")]
        [NativeName("Type.Name", "void")]
        [NativeName("Name", "pNext")]
        public void* PNext;
/// <summary></summary>
        [NativeName("Type", "VkBool32")]
        [NativeName("Type.Name", "VkBool32")]
        [NativeName("Name", "shaderDrawParameters")]
        public Bool32 ShaderDrawParameters;
    }
}
