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
  ],
   "States": {
        "name": [
            "actionitem name"
        ]
    }
}
```

## Properties

### ActionItems

An array of Action Items. An Action Item represents an animation that the character can perform.

#### Action Item Properties

**Name**: The name of the action item.

**Return**: The name of the action item that returns the character to the resting state, or null.

**Frames**: An array of frames in the action.

**Reverse**: Boolean indicating if the action is reversible.

**ActionMenuSelected**: The selected action menu or null.

#### Frame Properties

**SoundEffect**: The sound effect filename or null.

**Duration**: Duration of the frame in milliseconds.

**ExitBranch**: Index of frame to go to if the animation is exiting. -1 if no option from this frame.

**Images**: An array of images in the frame.

**Mouths**: An array of mouths in the frame.

**Branches**: An array of possible branches for the frame.

#### Image Properties

**Filename**: The filename of the image.

**OffsetX**: The X offset of the image.

**OffsetY**: The Y offset of the image.

**Mouths**: An array of mouth configurations.

#### Mouth Properties

**MouthType**: The type of mouth.

**FrameImage**: The frame image for the mouth.

**Filename**: The filename of the mouth image.

**OffsetX**: The X offset of the mouth image.

**OffsetY**: The Y offset of the mouth image.

#### Branch Properties

**BranchTo**: The index of the frame to which this branch should go.

**Probability**: The probability of this branch occurring on this frame.

### States

An array of named states. Each named state contains an array of ActionItem names.

See also:

> [Instructions on building your own character.](./Creating%20a%20Simple%20Character)
