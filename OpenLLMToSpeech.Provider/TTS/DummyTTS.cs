using OpenLLMToSpeech.Core.Interface;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public sealed class DummyTTS : TTS
{
    public override Task<byte[]> SynthesizeAsync(
        string text,
        object? options = null,
        CancellationToken ct = default
    )
    {
        // Fake "audio" – just UTF8 bytes so you can see it works
        var fakeAudio = Encoding.UTF8.GetBytes(
            $"[DummyTTS audio for]: {text}"
        );

        return Task.FromResult(fakeAudio);
    }
}
