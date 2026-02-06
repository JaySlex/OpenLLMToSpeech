using OpenLLMToSpeech.Core.Interface;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

public sealed class OpenAiTTS : TTS
{
    private static readonly HttpClient _http = new HttpClient();
    private readonly string _apiKey;
    private readonly string _voice;
    private readonly string _model;

    public OpenAiTTS(
        string apiKey,
        string model = "gpt-4o-mini-tts",
        string voice = "alloy"
    )
    {
        _apiKey = apiKey;
        _model = model;
        _voice = voice;

        _http.DefaultRequestHeaders.Clear();
        _http.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
    }

    public override async Task<byte[]> SynthesizeAsync(
        string text,
        object? options = null,
        CancellationToken ct = default
    )
    {
        var payload = new
        {
            model = _model,
            voice = _voice,
            input = text,
            format = "wav"
        };

        var json = JsonSerializer.Serialize(payload);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        using var response = await _http.PostAsync(
            "https://api.openai.com/v1/audio/speech",
            content,
            ct
        );

        if (!response.IsSuccessStatusCode)
        {
            var err = await response.Content.ReadAsStringAsync(ct);
            throw new Exception($"OpenAI TTS error: {err}");
        }

        return await response.Content.ReadAsByteArrayAsync(ct);
    }
}
