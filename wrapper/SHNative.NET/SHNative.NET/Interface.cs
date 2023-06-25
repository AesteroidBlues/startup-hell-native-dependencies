using ImGuiNET;
using System;
using System.Numerics;
using System.Text;

namespace SHNativeNET
{
    public static unsafe class SHNative
    {
        public static void SetImGuiContext(IntPtr context)
        {
            Wrapper.SetImGuiContext(context);
        }

        public static bool Bezier(string label, ref Vector4 values)
        {
            byte* native_label;
            int label_byteCount = 0;
            if (label != null)
            {
                label_byteCount = Encoding.UTF8.GetByteCount(label);
                if (label_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_label = Util.Allocate(label_byteCount + 1);
                }
                else
                {
                    byte* native_label_stackBytes = stackalloc byte[label_byteCount + 1];
                    native_label = native_label_stackBytes;
                }

                int native_label_offset = Util.GetUtf8(label, native_label, label_byteCount);
                native_label[native_label_offset] = 0;
            }
            else
            {
                native_label = null;
            }

            fixed (Vector4* native_v = &values)
            {
                return Wrapper.Bezier(native_label, native_v);
            }
        }

        public static void ShowBezierDemo()
        {
            Wrapper.ShowBezierDemo();
        }
    }
}
