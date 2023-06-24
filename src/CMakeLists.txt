cmake_minimum_required(VERSION 3.20)
project(shnative)

set (CMAKE_CXX_STANDARD 11)

add_definitions(-DIMNODES_NAMESPACE=imnodes)

add_subdirectory(../deps/cimgui cimgui)
add_subdirectory(../deps/cimnodes imnodes)
add_subdirectory(../deps/cimguizmo cimguizmo)
add_subdirectory(../deps/cimplot cimplot)

add_library(shnative SHARED
    ../deps/cimgui/imgui/imgui.cpp
    ../deps/cimgui/imgui/imgui_draw.cpp
    ../deps/cimgui/imgui/imgui_demo.cpp
    ../deps/cimgui/imgui/imgui_widgets.cpp
	../deps/cimgui/imgui/imgui_tables.cpp
    ../deps/cimgui/imgui/imgui.cpp
    ImGuiCurveWidget.cpp
)

target_include_directories(shnative PUBLIC ../deps/cimgui/imgui)
target_include_directories(shnative PUBLIC ../deps/cimgui)
set_target_properties(shnative PROPERTIES PREFIX "")