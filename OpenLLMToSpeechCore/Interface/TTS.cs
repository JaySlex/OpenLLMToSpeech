using System.Threading;
using System.Threading.Tasks;

namespace OpenLLMToSpeech.Core.Interface
{
    public abstract class TTS
    {
        public abstract Task<byte[]> SynthesizeAsync(
            string text,
            object? options = null,
            CancellationToken ct = default
        );
    }

}
