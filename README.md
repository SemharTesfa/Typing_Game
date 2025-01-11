### Game Development Project: Typing Game
This is Game Development Project for the Typing Game. This repository contains all necessary assets and code required to run and further develop the game. The project utilizes Unity as its primary engine and includes various resources such as animations, fonts, prefabs, scripts, and more.

## Project Structure
This repository is organized by type of assets and functionality to facilitate easy navigation and understanding:

# Animations
Controllers: Manage animation states for different character actions.
Walk_0.controller: Handles looping walk animations.
Death_0.controller: Triggers animations related to character death.
Animation Clips: Define the actual motion sequences.
TriggerDeath.anim: Activates the death animation sequence.
walk_0_animation.anim: Defines the character's walking animation.
# Fonts
Custom Fonts: Enhance visual appeal and user interface readability.
AlexBrush-Regular.ttf: Used primarily for UI elements and display text.
# Prefabs
Game Components: Reusable templates for game objects.
Typer.prefab: Manages text input within the game.
WordBank.prefab: Stores and manages the words used in the game.
# Scenes
Environment Setup: Where all elements come together to form the game environment.
SampleScene.unity: The main scene where the game mechanics are demonstrated.
# Scripts
Game Logic: Core scripts that drive game functionality.
Typer.cs: Controls the typing mechanics in the game.
WordBank.cs: Handles the storage and retrieval of words.
# Sounds
Audio Files: Enhance the game experience with audio feedback.
ding.wav: Played when the player successfully types a word.
# Sprites
Visual Assets: Images and icons used throughout the game.
Death.png, Walk.png, typing_bg.png: Various sprites used for character and background visuals.
## Getting Started
To get the project up and running on your local machine for development and testing purposes, follow these steps:

# Prerequisites
Ensure you have Unity installed (specify the required version, e.g., Unity 2020.3 LTS) to open and run the project.

Installation
Clone the repository:

```bash
git clone https://github.com/yourusername/game_dev.git
```
# Open the project in Unity:
Launch Unity Hub.
Click on 'Add' and select the cloned project directory.
Open the main scene and play:

Navigate to the Scenes folder.
Double-click SampleScene.unity to open it.
Press the play button in Unity to start the game.
