using System;
using System.IO;
using System.Text;

public static class WavWriter
{
    public static byte[] Write8BitMonoBytes(
    byte[] pcmData,
    int sampleRate = 22050)
    {
        using var ms = new MemoryStream();
        using var bw = new BinaryWriter(ms);

        int dataSize = pcmData.Length;
        int fileSize = 36 + dataSize;

        // RIFF header
        bw.Write(Encoding.ASCII.GetBytes("RIFF"));
        bw.Write(fileSize);
        bw.Write(Encoding.ASCII.GetBytes("WAVE"));

        // fmt chunk
        bw.Write(Encoding.ASCII.GetBytes("fmt "));
        bw.Write(16);                 // PCM chunk size
        bw.Write((short)1);           // Audio format = PCM
        bw.Write((short)1);           // Channels = mono
        bw.Write(sampleRate);         // Sample rate
        bw.Write(sampleRate);         // Byte rate (8-bit mono)
        bw.Write((short)1);           // Block align
        bw.Write((short)8);           // Bits per sample

        // data chunk
        bw.Write(Encoding.ASCII.GetBytes("data"));
        bw.Write(dataSize);
        bw.Write(pcmData);

        bw.Flush();
        return ms.ToArray();
    }

}
