# AT03---Programming
Unity Version - 6000.0.60f1 LTS /
6000.2.8f1 
 
## Project Name: RPG Adventure

### Project Objective:
The objective of this project is to design and develop a small but feature-complete Unity game prototype that simulates a simple RPG adventure experience. The game will integrate essential gameplay systems such as player movement, camera control, dialogue interactions, menus, and a basic saving/loading system. The project’s goal is to provide a cohesive gameplay experience where players can explore, interact, and progress through the adventure. The final product should highlight the development of a functional prototype that incorporates these systems seamlessly to create an engaging RPG experience. 

### Team Members & Tasks:
**Callum** - Movement, Camera, Interaction   
**Shane** - Stats and leveling, Saving stats, Respawning  
**Elise** - Dialogue, Menu and Options Menu, Saving Options 

### Version Control Techniques
- Branches will be named Featurname_contributorname eg. MainMenu_Elise
- All branches will be off the dev branch
- Once a branch is ready to be merged, we will submit a pull request and another contributor will review it
- Commit every time you complete a function, or at least commit regularly
- Dot points for commit messsages
- Commits should be named after the function they changed or created, and describe what state the features created/changed are in and what they do

### Project Features & Scope

#### Menu and Options Menu 
- The game will feature a main menu allowing players to start a new game, load a saved game, or exit. 
- The options menu will enable players to adjust sound settings, graphic preferences, and gameplay settings. 

#### Saving and Loading Options 
- The game will allow players to save their menu preferences, such as sound settings, graphic settings, and key bindings. 
- These settings will persist across sessions, ensuring that the player’s preferred configurations are automatically loaded when the game starts. 
- The system will store these preferences in a file format, enabling easy retrieval and modification. 

#### Player Movement 
- The player can move freely within the game world using keyboard inputs (WASD or arrow keys). 
- The Player can change speeds between crouch and sprint. 
- Movement is smooth and responsive, with a simple collision detection system to prevent the player from passing through objects. 

#### Camera Control 
- The camera will follow the player, providing a dynamic perspective of the game world. 
- The camera's position and rotation will adjust smoothly as the player moves, ensuring a clear and focused view of the action. 
- The player can optionally adjust the camera angle and zoom in/out using the mouse. 

#### Dialogue System 
- Players can read through text-based responses and make choices that affect the conversation. 
- Dialogue options will trigger different responses or actions based on player decisions. 

#### Interaction 
- The player can interact with NPCs, objects, and environments through simple prompts. 
- Interactions will trigger actions such as opening doors, picking up items, or starting dialogues. 
- The interaction system will be simple and context-sensitive, adapting to the object or NPC being interacted with. 

#### Stats and Leveling 
- The player will have stats such as health, experience points (XP), and level, which improve as they progress. 
- The leveling system will improve stats as the player advances. 

#### Saving and Loading Stats 
- Player stats will be saved during the game save process. 
- Stats will be stored in a file for easy management and retrieval when loading the game. 
- Any changes to the player’s stats (such as leveling up) will be automatically saved. 
- The player’s position, rotation, and other transform-related data will be saved when the game is saved. 
- When the game is loaded, the player will return to their exact last location and state, preserving the continuity of gameplay. 

#### Respawn 
- When the player’s character dies, they will respawn at a predefined location, such as a checkpoint or starting area. 
- Respawn will restore the player's health to a default value. 
- The respawn system will include a short delay before the player is returned to the game world to avoid instant re-engagement after death. 
- The game will provide a visual or audio cue to indicate the respawn event, ensuring the player is aware of their return to the game. 
- Player stats, including experience points and level, will remain intact upon respawn, maintaining the player’s progression despite death. 
