Using the Windows Application Packaging Project the app breaks due to native/satalite assemblies. This is most obvious with SQLite and any DLL that you want to load as an extension.

In good ole WPF land this all works as expected (you can run the .exe and see for yourself)

The packaged app does not include the DLLs from sqlite nor the project referenced C++ DLL (this holds true for other nugets such as CefSharp). 

The current workaround I am employing is using a post-build script to copy over the assembies into the AppX folder, but that is not at all maintainable nor ideal.

The two part issue is first copying over `SQLite.Interop.dll` from the respective x86/x64 folders, and then making sure that it also includes `ProjectReference` with `<OutputItemType>Content</OutputItemType>` or provide some suitable workaround that doesn't require referencing static DLLs.