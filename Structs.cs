using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
struct RAWINPUTDEVICE
{
    public ushort UsagePage;
    public ushort Usage;
    public uint RawInputDeviceFlags;
    public IntPtr Target;
}

[StructLayout(LayoutKind.Sequential)]
struct RAWINPUT
{
    public RAWINPUTHEADER header;
    public RAWMOUSE data;
}

[StructLayout(LayoutKind.Sequential)]
struct RAWINPUTHEADER
{
    public int dwType;
    public int dwSize;
    public IntPtr hDevice;
    public IntPtr wParam;
}

[StructLayout(LayoutKind.Sequential)]
struct RAWMOUSE
{
    public ushort usFlags;
    public uint ulButtons;
    public uint ulRawButtons;
    public int lLastX;
    public int lLastY;
    public uint ulExtraInformation;
}
