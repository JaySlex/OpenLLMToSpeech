# OpenLLMToSpeech

OpenLLMToSpeech is a small provider-agnostic bridge between LLMs and text‑to‑speech systems. The goal is to make it straightforward to plug in different LLM & TTS providers and (eventually) local models.

## Goals

- Minimal core logic, no provider‑specific coupling
- Easy to add new LLM providers
- Designed to expand toward local inference

## How It Works

1. The core receives a text input and configuration
2. A provider is selected
3. The provider generates a response using its own backend
4. The output is returned to the TTS layer

The core does not care _how_ the text is generated, only that the provider respects the expected interface.

## Current Providers

### LLM

- OpenAI

### Text-to-Speech (TTS)

- OpenAI TTS
- SAM (Software Automatic Mouth) (made by [thislookshard/SamSharpPublic](https://github.com/thislookshard/SamSharp))

A minimal **DummyProvider** is included as a reference implementation for adding new providers. Additional providers can be added with very little boilerplate.

## Adding a New Provider

The recommended way to add a provider is to copy the `DummyLLM/TTS.cs` and adapt it.

### Steps

1. Create the `provider` directory
2. Rename it to your provider name
3. Implement the provider interface

## Planned Expansion

- Support for Hugging Face models
- Multiple provider selection at runtime
- ASP API interface
- Support for Speech to Text for fully audio conversation

## Feature Requests and Contributions

Feature requests are welcome. If you need support for a specific provider, model, or workflow, open an issue and describe the use case clearly.

Pull requests should:

- Keep the core provider‑agnostic
- Follow the existing provider interface
- Avoid adding unnecessary abstractions

## License

MIT
