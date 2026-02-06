namespace OpenLLMToSpeechTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Enter your prompt: ");
            string prompt = Console.ReadLine();

            var llm = new OpenAiLLM(
                "enter your key here",
                "gpt-5-nano"
                );

            var tts = new OpenAiTTS(
                "enter your key here"
                );

            var pipeline = new LLMtoTTS(llm, tts);

            byte[] audio = await pipeline.RunAsync(
                prompt
            );

            File.WriteAllBytes("./output.wav", audio);

            Console.ReadLine();
        }
    }
}
