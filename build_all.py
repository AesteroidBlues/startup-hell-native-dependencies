import os
import shutil
import glob

project_root = "F:\\Projects"

source_path = os.path.join(".", "src")
build_root = os.path.join(".", "build")

archs = ("x86", "x64")
arch_names = {
    "x86": "Win32",
    "x64": "x64"
}

lib_names = ("cimgui", "cimnodes", "shnative")
file_extensions = ("*.pdb", "*.dll")

lib_destination_root = os.path.join(
    project_root, "games", "startup-hell", "lib")

for arch in archs:
    out_dir = os.path.join(build_root, arch)
    print(f"Running CMAKE for arch {arch} in {out_dir}")
    os.system(
        f"cmake -A {arch_names[arch]} -S {source_path} -B {out_dir}")
    os.system(f"msbuild {os.path.join(out_dir, 'shnative.sln')}")

    for lib in lib_names:
        lib_name = lib
        if (lib == "shnative"):
            lib_name = ""
        debug_path = os.path.join(out_dir, lib_name, "Debug")
        for ext in file_extensions:
            file_filter = os.path.join(debug_path, ext)
            files = glob.iglob(file_filter)
            for file in files:
                lib_dest = os.path.join(
                    lib_destination_root, lib, arch)
                print(f"Copying {file_filter} to {lib_dest}")
                shutil.copy(file, lib_dest)
