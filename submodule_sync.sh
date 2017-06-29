echo init git submodule
git submodule init

echo update git submodule
git submodule update

echo specific hack for submodule
.nuget/nuget.exe restore ./Heroes.ReplayParser/MpqTool/MpqTool.csproj -PackagesDirectory ./Heroes.ReplayParser/Packages/
