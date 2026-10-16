# The `IAgent` interface

Implement `nsquared.agents.IAgent` in a .NET 10 class library to describe an animated character
and locate its assets in the character assembly.

| Member | Type | Description |
|---|---|---|
| `Name` | `string` (get/set) | Character name shown by the application. |
| `AssemblyName` | `string` (get/set) | Assembly name used by the character's asset URIs. |
| `ActionsFileUri` | `Uri` | URI of the character's `Actions.json`, normally an `avares://` URI to an Avalonia resource. |
| `AudioFilesPath` | `string` | Manifest-resource prefix for audio files embedded in the assembly. |
| `FrameAssetPath` | `string` | `avares://` URI prefix for animation frames stored as Avalonia resources. |
| `IconPath` | `string` | URI/path for the character icon included as content in the assembly. |
| `WakeWord` | `string` | Voice activation word. Defaults to `"agent"` when not overridden. |
| `Personality` | `string?` | Optional personality description used by AI-powered commands to shape their responses. |
| `Voice` | `string?` | Optional default voice for this character. `null` or empty uses the user's global voice setting. |

The asset paths must match how the files are included in the project: actions and frames are
Avalonia resources, audio is embedded, and the icon is content. The
[simple character guide](Creating%20a%20Simple%20Character.md) shows a complete implementation.

See also:

> [Instructions on building your own character](Creating%20a%20Simple%20Character.md).
