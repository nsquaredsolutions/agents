using nsquared.agents;
namespace SimpleCharacter;

public class Character : IAgent
{
    public string Name { get => "SimpleCharacter"; set => throw new NotImplementedException(); }
    public string AssemblyName { get => "SimpleCharacter"; set => throw new NotImplementedException(); }
    public Uri ActionsFileUri => new Uri($"avares://{AssemblyName}/Assets/Actions.json");
    public string AudioFilesPath => $"{Name}.Assets.Audio.";
    public string FrameAssetPath => $"avares://{AssemblyName}/Assets/Frames/";
    public string IconPath => $"avares://{AssemblyName}/Assets/Icon.ico";
}
