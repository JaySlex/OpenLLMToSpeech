using OpenLLMToSpeech.Core.Interface;
using System.Threading;
using System.Threading.Tasks;

public sealed class LLMtoTTS
{
    private readonly LLM _llm;
    private readonly TTS _tts;

    public LLMtoTTS(LLM llm, TTS tts)
    {
        _llm = llm;
        _tts = tts;
    }

    public async Task<byte[]> RunAsync(
        string prompt,
        object? llmOptions = null,
        object? ttsOptions = null,
        CancellationToken ct = default
    )
    {
        // 1. Prompt → text
        string response = await _llm.GenerateResponseAsync(
            prompt,
            llmOptions,
            ct
        );
        Console.WriteLine( response );
        // 2. Text → audio
        byte[] audio = await _tts.SynthesizeAsync(
            response,
            ttsOptions,
            ct
        );

        return audio;
    }
}

