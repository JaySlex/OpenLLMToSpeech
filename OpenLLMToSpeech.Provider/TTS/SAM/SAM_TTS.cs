using OpenLLMToSpeech.Core.Interface;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SamSharp;
public sealed class SAM_TTS : TTS
{
    public override Task<byte[]> SynthesizeAsync(
        string text,
        object? options = null,
        CancellationToken ct = default
    )
    {
        Sam sam = new Sam();
        byte[] audio = sam.Speak(text);

        return Task.FromResult(WavWriter.Write8BitMonoBytes(audio));
    }
}
