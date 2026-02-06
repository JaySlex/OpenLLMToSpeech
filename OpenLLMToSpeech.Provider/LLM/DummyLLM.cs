using OpenLLMToSpeech.Core.Interface;
using System.Threading;
using System.Threading.Tasks;

public sealed class DummyLLM : LLM
{
    public override Task<string> GenerateResponseAsync(
        string prompt,
        object? options = null,
        CancellationToken ct = default
    )
    {
        return Task.FromResult(
            $"[DummyLLM] You said: {prompt}"
        );
    }
}
