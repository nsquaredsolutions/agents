using nsquared.agents;

namespace SimpleCharacter;

public class Character : IAgent
{
    public string Name { get; set; } = "SimpleCharacter";
    public string AssemblyName { get; set; } = "SimpleCharacter";
    public Uri ActionsFileUri => new($"avares://{AssemblyName}/Assets/Actions.json");
    public string AudioFilesPath => $"{Name}.Assets.Audio.";
    public string FrameAssetPath => $"avares://{AssemblyName}/Assets/Frames/";
    public string IconPath => $"avares://{AssemblyName}/Assets/Icon.ico";
    public string WakeWord => "SimpleCharacter";
    public string? Personality => "You are a friendly, concise desktop assistant.";
    public string? Voice => null;
}
