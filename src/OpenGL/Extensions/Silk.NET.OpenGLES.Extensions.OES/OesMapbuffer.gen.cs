// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.
using System;
using System.Runtime.InteropServices;
using System.Text;
using Silk.NET.OpenGLES;
using Silk.NET.Core.Native;
using Silk.NET.Core.Attributes;
using Silk.NET.Core.Contexts;
using Silk.NET.Core.Loader;

#pragma warning disable 1591

namespace Silk.NET.OpenGLES.Extensions.OES
{
    [Extension("OES_mapbuffer")]
    public unsafe partial class OesMapbuffer : NativeExtension<GL>
    {
        public const string ExtensionName = "OES_mapbuffer";
        [NativeApi(EntryPoint = "glGetBufferPointervOES")]
        public unsafe partial void GetBufferPointer([Flow(FlowDirection.In)] OES target, [Flow(FlowDirection.In)] OES pname, [Flow(FlowDirection.Out)] void** @params);

        [NativeApi(EntryPoint = "glMapBufferOES")]
        public unsafe partial void* MapBuffer([Flow(FlowDirection.In)] OES target, [Flow(FlowDirection.In)] OES access);

        [NativeApi(EntryPoint = "glUnmapBufferOES")]
        public partial bool UnmapBuffer([Flow(FlowDirection.In)] OES target);

        [NativeApi(EntryPoint = "glGetBufferPointervOES")]
        public unsafe partial void GetBufferPointer([Flow(FlowDirection.In)] BufferTargetARB target, [Flow(FlowDirection.In)] BufferPointerNameARB pname, [Flow(FlowDirection.Out)] void** @params);

        [NativeApi(EntryPoint = "glMapBufferOES")]
        public unsafe partial void* MapBuffer([Flow(FlowDirection.In)] BufferTargetARB target, [Flow(FlowDirection.In)] BufferAccessARB access);

        public OesMapbuffer(INativeContext ctx)
            : base(ctx)
        {
        }
    }
}

