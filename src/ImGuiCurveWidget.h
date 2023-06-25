#pragma once

#define IMGUI_DEFINE_MATH_OPERATORS
#include <imgui.h>

#if defined _WIN32 || defined __CYGWIN__
    #define API __declspec(dllexport)
#else
    #ifdef __GNUC__
        #define API  __attribute__((__visibility__("default")))
    #else
        #define API
    #endif
#endif

#define EXTERN extern "C"

namespace SHNative
{
    EXTERN API void SetImGuiContext(ImGuiContext* imGuiContext);

    EXTERN API bool Bezier(const char *label, float P[5]);

    EXTERN API void ShowBezierDemo();
}