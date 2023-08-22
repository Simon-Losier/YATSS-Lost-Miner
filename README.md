# YATSS-Lost-Miner
YATSS: Lost Miner | Simon's Havard's CS50g final project

# Contributions
Due to havard academic integrity rules, until the cs50 assignment is submitted and graded contributions(pull requests, bug reports, etc) will be ignored.

# General Documentation

## Movement/Shooting System
The movement system uses the new unity input system to handle input. To do this I used a combination of this tutorial: https://www.youtube.com/watch?v=m5WsmlEOFiA and the unity input system docs: https://docs.unity3d.com/Packages/com.unity.inputsystem@1.6/manual/index.html
At first I used ```transform.position``` to move the player and the cart, using this to do the movement caused issues with collision detection. Instead I used ```Rigidbody.velocity``` after discussion with a peer. 
Rotation uses Vector Based rotations to escape Quaternion weirdness. This works resonobly well for the game.

The shooting system will summon an ball attack ball and rotate the ball's rotation to the players rotation. The ball has a script to move it forward.

## World Generation
The world is procedurally generated. There are 3 elements to the generation. Ores, Sentries and rails.
- The ores(Steel and Steel) are summoned column by column. At each column an amount of ore will be decided at random, than it is pleaced at a random ```Z``` location. However betwen ```z``` 6-8 is reserved for the cart. Than it is chosen by random wether the ore will be steel or gold
- The senteries have a set number chosen procedurally that will determine the amount of senteries summoned. Than it will summon those senteries at random X locations with the preset location above the rail
- The rails are to a preset length, they start from a preset location. At each iteration of the rail there is a chance of it being broken.

## Ores
There are two types of ores, steel and gold. Steel is used to repair the broken rails and gold is used to reach the win state. The ores are mined using the shooting mechanic, they have a health of 2. When the ore is mined they drop a steel/gold ingot when this ingot is pickedup, the steel/gold is added to the inventory.

## Senteries
Senteries goal is to sabotage the player by hurting the player. They can be destroyed by being mined by the player. Every two seconds they will try to hurt the cart by shooting downwards towards the rail with a red glowing ball. They do not aim towards the cart, this is to allow the player to better react to the situation. 

## Rails
The cart runs on rails, they can be fixed if the player walks on them while holding F and the player has Steel in the inventory the rail will be repaired and the cart will be able to roll over the rail. This costs the player 1 steel. 

## States/Scenes
- StartState | The player will see basic instructions of the game, and will be invited to start.
- PlayState | This is the main game state, this is where the player will play the game
- WinState | Displays "You Won", player may play again by pressing space
- GameOverState | Displays "Game Over", player may play again by pressing space.

## Win condition
When the player reaches the gold quota by having enough gold in the inventory, the game is considerd won.

## Loss Conditions
The game will be lost in these events:
- The cart is hit by a sentry bullet
- The cart rolls over a broken rail
- The player is hit by a sentry bullet

## Assets used
- https://kenney.nl/assets/mini-dungeon
- https://kenney.nl/assets/nature-kit

## CS50g Requirement: Complexity and Distinctiveness 
### Complexity
This game has a slightly higher complexity than the unity series of games. I beleave the game hits the complexity requirements as it contains similar systems as other games and mixes them. This game features procedural generation wich is present in most games of the term, item pickup, inventory system, enemies, shooting system. Comparing this to say Dreadhalls, wich contains only procedural generation and a type of pickup, this game is more complex since it contains more systems.

### Distinctiveness
The game is distinct, there is not a game with the gameplay loop of mining ores, fixing rails, destroying sentries. 


# Game Design Doc
## Summary
Mining game where you have to escort a minecart to the end of the mine with monsters trying to stop you. The minecart never stops. 

## Inspiration
1. Binding of isaac
    1. Combat and movement would work great with this game
    2. Rogue-Like
2. Deep rock galatic
    1. The concept of having a mining quota to aquire and to have to fight while mining.

## Story
You are lost in an abandoned mine shaft and you have to bring your quota of gold home.

## Gameplay
### Core Loop
There would be mine cart that is always advancing, creating a sense of ergency. The player will have to stock the mine cart of gold 

### Mechanics
- Cart moves forward at all time
- Gold must be mined and brought to the cart to meet the quota
- Monsters will try to destroy the cart
- Rails may be destroyed and must be repaired with steel.

### Movement/controls
#### Mobile(excluded for CS50 submition):
On screen joystick and another button for shooting/mining in the direction of movement. 

#### PC version:
Movement is inspired from binding of isaac, left stick(WASD) would control the player and A,B,X,Y(arrow keys) would control the attacking/mining. 

### Levels
#### Level Design
The level will be a procedurally generated mineshaft that would be long enough for the level to last 1-2 minutes. Gold, steel and monster placement would be procedurally generated. 
2D rough Sketch of a level: 
![Level](https://github.com/Simon-Losier/YATSS-Lost-Miner/assets/98567864/7d4e9c10-263f-478f-bc86-38fd2127b900)

#### Look
3D Game set underground in a mineshaft
Asset packs to be used:
- https://kenney.nl/assets/mini-dungeon
- https://kenney.nl/assets/nature-kit

