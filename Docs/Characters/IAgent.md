# The IAgent Interface

This interface is used to define an animated character that renders in the nsquared agents application.

| Field          | Type |  Description   |
|----------------|------|----------------|
| Name           | String | The name of the character |
| AssemblyName   | String | The name of the assembly that contains the character |
| ActionsFileUri | Uri   | The uri of the actions file for the character. This should be a uri that points to a json file that contains the actions that the character can perform. This file should be stored as an AvaaloniaResource in the assembly named by the AssemblyName. |
| AudioFilesPath | String | The path to the audio files for the character. The audio files should be stored as embedded resources in the assembly named by the AssemblyName. All the audio files should be in the folder identified by this path.|
| FrameAssetPath | String | The path to the folder containing the frames for the character. The frames should be stored as AvaloniaResources in the assembly named by the AssemblyName. All the frames should be in the folder identified by this path. |
| IconPath | String | The path to the icon for the character. The icon should be stored as content in the assembly named by the AssemblyName. |

See also:

- [Instructions on building your own character.](./Creating%20a%20Simple%20Character.md)
