// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Silk.NET.Core.Attributes;
using Silk.NET.Core.Contexts;
using Silk.NET.Core.Native;

namespace Silk.NET.OpenAL.Extensions.Enumeration
{
    /// <summary>
    /// Exposes the API in the Enumeration extension.
    /// </summary>
    [Extension("ALC_ENUMERATION_EXT")]
    [NativeApi(Prefix = "alc")]
    public partial class Enumeration : ContextExtensionBase
    {
        /// <inheritdoc cref="ExtensionBase" />
        protected Enumeration(INativeContext ctx)
            : base(ctx)
        {
        }

        /// <inheritdoc />
        public unsafe partial string GetString(Device* device, GetEnumerationContextString param);

        /// <inheritdoc />
        public unsafe partial char* GetStringList(Device* device, GetEnumerationContextStringList param);

        /// <inheritdoc cref="GetString(Device*, GetEnumerationContextString)" />
        public IEnumerable<string> GetStringList(GetEnumerationContextStringList param)
        {
            unsafe {
                var result = GetStringList(null, param);
                if (result == (char*) 0) {
                    return new List<string>();
                }

                var strings = new List<string>();

                var currentPos = result;
                while (true) {
                    var currentString = Marshal.PtrToStringAnsi(new IntPtr(currentPos));
                    if (string.IsNullOrEmpty(currentString)) {
                        break;
                    }

                    strings.Add(currentString);
                    currentPos += currentString.Length + 1;
                }

                return strings;
            }
        }
    }
}
