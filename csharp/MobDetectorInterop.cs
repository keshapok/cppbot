using System.Runtime.InteropServices;

public static class MobDetectorInterop
{
    [DllImport("CppOpenCvDetector.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int DetectMobs(
        byte[] imageData,
        int width,
        int height,
        int[] outBuffer,
        int bufferSize);
}
