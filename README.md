Assets taken from [PixelFrog](https://pixelfrog-assets.itch.io/pixel-adventure-1)

# Instructions how to run in Unity:
1. Clone the repository
```bash
    git clone https://github.com/MilanuA/Platformer_prototype.git
```

2. Download Unity Version `6000.0.29`
3. Open the project in Unity


# Instructions how to run the game:
1. Go to Releases and under `Game release` download either the Linux or Windows version
2. Extract the ZIP file
3. If Windows version: Go to the extracted folder and press `Platformer_protytpe.exe`
4. If Linux version: Go to the extracted folder and press `Linux_version.x86_64`


## Approach
- **Score management:** `ScoreManager` handles score updates and manages text for the collectables. Score update is managed through the event
- **Collectables** Implemented an `ICollectable` interface, allowing for different types of collectables. This makes it easier to add new collectables with different/unique behaviors
- **Levels:** Created simple ScriptableObject for managing levels. This can be expanded in future in case if we want to , for example, check if the level is unlocked or was visited
- **Player Movement:** Managed in `Movement.cs`, featuring "faster" falling and a state system (`Grounded`, `Falling`, `Jumping`) for better control. I am using **New Input System**, as I am more familiar with it
- **Audio:** A simple script with an event that is triggered when a collectable is collected
- **Level Selection:** Designed to be modular, dynamically spawning buttons based on the number of available levels in the list
