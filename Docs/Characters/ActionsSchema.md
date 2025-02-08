# The Actions.json schema

Each character has animations and actions defined in a json file, called the Actions.json file.

The Actions.json file contains a collection of animations and actions for each character. It serves as a centralized repository for defining the behavior and movement of characters. By modifying this file, you can easily customize and extend the available actions for each character.

``` json
{
  "ActionItems": [
    {
      "Name": "string",
      "Return": "string or null",
      "Frames": [
        {
          "SoundEffect": "string or null",
          "Duration": "integer",
          "ExitBranch": "integer",
          "Images": [
            {
              "Filename": "string",
              "OffsetX": "integer",
              "OffsetY": "integer"
            }
          ],
          "Mouths": [
            {
              "MouthType": "integer",
              "FrameImage": {
                "Filename": "string",
                "OffsetX": "integer",
                "OffsetY": "integer"
              }
            }
          ],
          "Branches": [
            {
              "BranchTo": "integer",
              "Probability": "integer"
            }
          ]
        }
      ],
      "Reverse": "boolean",
      "ActionMenuSelected": "string or null"
    }
  ]
}
```

## Properties

    ActionItems: An array of action items.
        Name: The name of the action item.
        Return: Return type or null.
        Frames: An array of frames in the action.
            SoundEffect: The sound effect filename or null.
            Duration: Duration of the frame in milliseconds.
            ExitBranch: Exit branch index.
            Images: An array of images in the frame.
                Filename: The filename of the image.
                OffsetX: The X offset of the image.
                OffsetY: The Y offset of the image.
            Mouths: An array of mouth configurations.
                MouthType: The type of mouth.
                FrameImage: The frame image for the mouth.
                Filename: The filename of the mouth image.
                OffsetX: The X offset of the mouth image.
                OffsetY: The Y offset of the mouth image.
            Branches: An array of branches for the frame.
                BranchTo: The index to branch to.
                Probability: The probability of branching.
        Reverse: Boolean indicating if the action is reversible.
        ActionMenuSelected: The selected action menu or null.
