using System;
using System.Threading;
using System.Threading.Tasks;

namespace OpenLLMToSpeech.Core.Interface
{
    public abstract class LLM
    {
        public abstract Task<string> GenerateResponseAsync(
            string prompt,
            object? options = null,
            CancellationToken ct = default
        );
    }
}
