using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace SHNativeNET
{
    public unsafe class Wrapper
    {
        [DllImport("shnative", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetImGuiContext(IntPtr ctx);
        [DllImport("shnative", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Bezier(byte* label, Vector4* P);
        [DllImport("shnative", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ShowBezierDemo();
    }
}
