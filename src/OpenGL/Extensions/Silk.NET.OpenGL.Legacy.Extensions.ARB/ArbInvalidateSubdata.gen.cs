// This file is part of Silk.NET.
// 
// You may modify and distribute Silk.NET under the terms
// of the MIT license. See the LICENSE file for details.
using System;
using System.Runtime.InteropServices;
using System.Text;
using Silk.NET.OpenGL.Legacy;
using Silk.NET.Core.Native;
using Silk.NET.Core.Attributes;
using Silk.NET.Core.Contexts;
using Silk.NET.Core.Loader;

#pragma warning disable 1591

namespace Silk.NET.OpenGL.Legacy.Extensions.ARB
{
    [Extension("ARB_invalidate_subdata")]
    public unsafe partial class ArbInvalidateSubdata : NativeExtension<GL>
    {
        public const string ExtensionName = "ARB_invalidate_subdata";
        [NativeApi(EntryPoint = "glInvalidateBufferData")]
        public partial void InvalidateBufferData([Flow(FlowDirection.In)] uint buffer);

        [NativeApi(EntryPoint = "glInvalidateBufferSubData")]
        public partial void InvalidateBufferSubData([Flow(FlowDirection.In)] uint buffer, [Flow(FlowDirection.In)] IntPtr offset, [Flow(FlowDirection.In)] UIntPtr length);

        [NativeApi(EntryPoint = "glInvalidateFramebuffer")]
        public unsafe partial void InvalidateFramebuffer([Flow(FlowDirection.In)] ARB target, [Flow(FlowDirection.In)] uint numAttachments, [Count(Parameter = "numAttachments"), Flow(FlowDirection.In)] ARB* attachments);

        [NativeApi(EntryPoint = "glInvalidateFramebuffer")]
        public partial void InvalidateFramebuffer([Flow(FlowDirection.In)] ARB target, [Flow(FlowDirection.In)] uint numAttachments, [Count(Parameter = "numAttachments"), Flow(FlowDirection.In)] Span<ARB> attachments);

        [NativeApi(EntryPoint = "glInvalidateSubFramebuffer")]
        public unsafe partial void InvalidateSubFramebuffer([Flow(FlowDirection.In)] ARB target, [Flow(FlowDirection.In)] uint numAttachments, [Count(Parameter = "numAttachments"), Flow(FlowDirection.In)] ARB* attachments, [Flow(FlowDirection.In)] int x, [Flow(FlowDirection.In)] int y, [Flow(FlowDirection.In)] uint width, [Flow(FlowDirection.In)] uint height);

        [NativeApi(EntryPoint = "glInvalidateSubFramebuffer")]
        public partial void InvalidateSubFramebuffer([Flow(FlowDirection.In)] ARB target, [Flow(FlowDirection.In)] uint numAttachments, [Count(Parameter = "numAttachments"), Flow(FlowDirection.In)] Span<ARB> attachments, [Flow(FlowDirection.In)] int x, [Flow(FlowDirection.In)] int y, [Flow(FlowDirection.In)] uint width, [Flow(FlowDirection.In)] uint height);

        [NativeApi(EntryPoint = "glInvalidateTexImage")]
        public partial void InvalidateTexImage([Flow(FlowDirection.In)] uint texture, [Flow(FlowDirection.In)] int level);

        [NativeApi(EntryPoint = "glInvalidateTexSubImage")]
        public partial void InvalidateTexSubImage([Flow(FlowDirection.In)] uint texture, [Flow(FlowDirection.In)] int level, [Flow(FlowDirection.In)] int xoffset, [Flow(FlowDirection.In)] int yoffset, [Flow(FlowDirection.In)] int zoffset, [Flow(FlowDirection.In)] uint width, [Flow(FlowDirection.In)] uint height, [Flow(FlowDirection.In)] uint depth);

        [NativeApi(EntryPoint = "glInvalidateFramebuffer")]
        public unsafe partial void InvalidateFramebuffer([Flow(FlowDirection.In)] FramebufferTarget target, [Flow(FlowDirection.In)] uint numAttachments, [Count(Parameter = "numAttachments"), Flow(FlowDirection.In)] InvalidateFramebufferAttachment* attachments);

        [NativeApi(EntryPoint = "glInvalidateFramebuffer")]
        public partial void InvalidateFramebuffer([Flow(FlowDirection.In)] FramebufferTarget target, [Flow(FlowDirection.In)] uint numAttachments, [Count(Parameter = "numAttachments"), Flow(FlowDirection.In)] Span<InvalidateFramebufferAttachment> attachments);

        [NativeApi(EntryPoint = "glInvalidateSubFramebuffer")]
        public unsafe partial void InvalidateSubFramebuffer([Flow(FlowDirection.In)] FramebufferTarget target, [Flow(FlowDirection.In)] uint numAttachments, [Count(Parameter = "numAttachments"), Flow(FlowDirection.In)] InvalidateFramebufferAttachment* attachments, [Flow(FlowDirection.In)] int x, [Flow(FlowDirection.In)] int y, [Flow(FlowDirection.In)] uint width, [Flow(FlowDirection.In)] uint height);

        [NativeApi(EntryPoint = "glInvalidateSubFramebuffer")]
        public partial void InvalidateSubFramebuffer([Flow(FlowDirection.In)] FramebufferTarget target, [Flow(FlowDirection.In)] uint numAttachments, [Count(Parameter = "numAttachments"), Flow(FlowDirection.In)] Span<InvalidateFramebufferAttachment> attachments, [Flow(FlowDirection.In)] int x, [Flow(FlowDirection.In)] int y, [Flow(FlowDirection.In)] uint width, [Flow(FlowDirection.In)] uint height);

        public unsafe void InvalidateBufferSubData([Flow(FlowDirection.In)] uint buffer, [Flow(FlowDirection.In)] int offset, [Flow(FlowDirection.In)] uint length)
        {
            // IntPtrOverloader
            InvalidateBufferSubData(buffer, new IntPtr(offset), new UIntPtr(length));
        }

        public ArbInvalidateSubdata(INativeContext ctx)
            : base(ctx)
        {
        }
    }
}

