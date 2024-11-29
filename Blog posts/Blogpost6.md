# Blogpost 6 #
## Description ##
## Enemy Bruiser ##
![image](https://github.com/user-attachments/assets/8307e078-679e-403c-9055-1ee0ea9ff540)# <br>
The enemy bruiser is designed to relentlessly chase the player and apply constant pressure, forcing the player to take immediate action to avoid being overwhelmed.

![image](https://github.com/user-attachments/assets/9071f521-ce87-4a94-b317-81ea8428014e) <br>

To better organize the code structure a `EnemyBase` script was created. All enemies inherit from this script containing different helper methods. For example all enemies have ragdolls and die in the same way so they have the same death method, which simplifies a lot of the code.
![image](https://github.com/user-attachments/assets/8cdb5ede-455d-4489-88cb-4197fcdfbfee) <br>

In the start of the `EnemyBruiser` script we cache the player transform. Then if the distance is closer to the player, the bruiser will get `provoked`. If the enemy is unprovoked he will idle a while a player might be in range.

![image](https://github.com/user-attachments/assets/5e42f4dd-4ff6-4712-8919-389c9721b2e3) <br>

The `EngangeTarget` method is responsible for the enemy behaviour while provoked. If the enemy is in punching range then he will perform a punch motion. Otherwise the enemy will chase the target until its close in range.

![image](https://github.com/user-attachments/assets/f24fbeb4-088c-48de-b674-65326380be96) <br>

The `Punch` method calls the punch animations. The enemy has sphere colliders that on trigger will kill the player if touched. Chasing the target is done using the navmesh surface and setting the destination of the agent to be the player. 

## Katana ##
## AK47 ##
## Grabbables ##

![image](https://github.com/user-attachments/assets/dff595eb-d3eb-420c-873f-5c8bc573d75c)


## VR Object Interaction Script Overview

This Unity script enhances the interaction of VR objects by adding distinctive attachment points for the left and right hands. It enables an object to dynamically switch its attachment point based on which hand grabs it, offering a more natural and intuitive interaction.

## Inheritance from `XRGrabInteractable`

The script inherits from the `XRGrabInteractable` class, which makes the object interactable within the XR (Extended Reality) environment. By doing so, the object can be grabbed and manipulated by the VR controllers.

## Variables

The script defines two variables of type `Transform`:
- **Left Hand Attachment Point**
- **Right Hand Attachment Point**

These variables determine where the object will be attached depending on which hand grabs it.

## Object Grab Logic

Upon an object grab, the script checks the tag of the VR controller to identify whether it is the left or right hand. Based on this, the script positions the attachment point accordingly:
- If the left hand grabs the object, it will be attached to the left hand's specified attachment point.
- If the right hand grabs it, the object will align with the right hand's attachment point.

This script integrates smoothly with Unity's XR Interaction Toolkit, making it simple to implement and providing a seamless, intuitive, and natural in-VR interaction experience with hand motions.

## Shuriken 

The image shows the configuration of the **Shuriken** object, a throwable weapon used in the VR game *SuperNot*. The shuriken is designed for intuitive VR interaction and provides a satisfying combat experience for players.

![image](https://github.com/user-attachments/assets/cfaf9aee-ea18-4d8f-80b5-b55908ee039c)

## Shuriken Features


### Tagging and Prefab
- **Tag:** The shuriken is tagged as a **Weapon** for easy identification within the game.
- **Prefab:** The object uses a prefab for consistency and easy reuse throughout the game.

### Size and Physics Setup
- **Size:** The shuriken’s size is scaled up for a larger, more noticeable appearance, making it easier for players to grab and throw.
- **Rigidbody Component:** 
  - **Mass:** Standard mass to simulate realistic weight and physics.
  - **Drag:** No drag, allowing the shuriken to move freely through the air.
  - **Angular Drag:** Slight angular drag enables the shuriken to spin realistically, gradually slowing over time.
  - **Gravity:** Turned off to keep the shuriken on a controlled flight path, allowing for precise throws.
  - **Collision Detection:** Set to **Discrete** for efficient interaction with other objects and characters.
  - **Dynamic Rigidbody:** Full interaction with forces and collisions in the game world, making the shuriken behave naturally in different scenarios.

### XR Interaction

The shuriken uses the **XR Grab Interactable Two Attach** script, which allows for VR interaction:
- **Interaction Mode:** Set to **Single**, meaning only one interaction (e.g., grabbing or throwing) can happen at a time.

### Movement and Responsiveness
- **Instantaneous Movement:** The shuriken responds immediately when grabbed or thrown, providing sharp, precise control.
- **Position and Rotation Tracking:** It tracks position and rotation for accurate handling, with no smoothing for immediate responsiveness.
- **Throw Smoothing:** Slight smoothing is applied upon throwing to create a more natural flight trajectory.

## Placement and Accessibility

![image](https://github.com/user-attachments/assets/65a23e46-782a-45f8-bfdc-bf76c554f654)


- The shurikens are placed on tables across the labs, positioned for quick and easy access. This setup ensures that players can grab and throw them without interrupting the flow of combat, keeping the gameplay smooth and intuitive.

## Purpose and Effectiveness

The technical integration of the shuriken makes it:
- **Intuitive** and **responsive**, with sharp control over movement and positioning.
- **Accurate**, providing players with reliable precision when throwing the weapon.
- **Versatile** and **effective** in combat, adding a dynamic, satisfying tool for taking down enemies.

This configuration ensures the shuriken is an engaging and functional weapon that enhances the player experience in *SuperNot*.


# Knife 

The **Knife** is a weapon in the VR game, providing dynamic interaction and realistic physics to enhance the player’s combat experience.

## Knife Features

![image](https://github.com/user-attachments/assets/62932291-48a4-4fe8-9bb3-0ab426056d75)


### Tagging and Layer
- **Tag:** The knife is tagged as a **Weapon** to categorize it within the game.
- **Layer:** It is set to the **Default** layer.

### Size and Physics Setup
- **Size:** The knife's size is kept at the default scale.
- **Rigidbody Component:**
  - **Mass:** Set to standard, simulating realistic weight.
  - **Drag:** No drag, allowing the knife to move freely.
  - **Angular Drag:** Slight angular drag enables the knife to spin or tilt naturally and slow down its rotation over time.
  - **Gravity:** Turned on to ensure the knife falls when released.
  - **Dynamic Rigidbody:** Full interaction with physics, allowing the knife to react to forces and collisions.
  - **Collision Detection:** Set to **Discrete** for efficient collision handling.
  - **No Constraints:** The knife is free to move without restrictions.

### XR Interaction Setup

- **XR Grab Interactable Two Attach Script:** This script enables the knife to be picked up and manipulated within the VR environment.
- **XR Interaction Manager:** The knife is linked to the XR Interaction Manager, which handles its interactions in the VR space.
- **Interaction Layer Mask:** is set to **Everything**, allowing the knife to interact with any object in the environment.
- **Interaction Distance:** Calculated from the Collider Position, with no custom reticle defined. The interaction range depends on where the player places their hand.
- **Interaction Modes:**
  - **Select Mode:** Single, allowing only one action or focus at a time.
  - **Focus Mode:** Single, ensuring only one focused interaction (such as grabbing or throwing) occurs at a time.

### Movement and Responsiveness



- **Instantaneous Response:** The knife reacts immediately to the player’s hand movements, tracking both position and rotation for precise control.
- **No Smoothing for Position and Rotation:** Both position and rotation smoothing are disabled to make the movement sharp and direct, ensuring a responsive gameplay experience.
- **Throw Smoothing:** A slight smoothing duration is applied when the knife is thrown, making its flight path more natural while maintaining accuracy.

  

## Purpose and Effectiveness

This configuration allows the knife to be:
- **Realistic** and **responsive** in VR, with dynamic physics that make it react naturally to the player’s actions.
- **Precise** in both close combat and when thrown, tracking position and rotation for tight control.
- **Intuitive** to interact with, offering a seamless and engaging experience during gameplay.

![image](https://github.com/user-attachments/assets/cac4a8dd-fde5-427f-80b0-09f4749a0d3c)


With these settings, the knife becomes an effective and versatile weapon in the VR game, providing a smooth and satisfying experience in both close-quarter combat and ranged throwing.

## Bottle

The Unity inspector panel describes the setup of the **Bottle** a weapon created for combat. It's created using a reusable prefab with adjustments for its placement and use in the game. The bottle is small, upright, and scaled to resemble the size of a real whisky bottle. The bottle gets its 3D form from a **Bottle** mesh, together with a sleek and brilliant material called **"black super hot."** It receives shadows for realism, effectively merging into the dynamic lighting of the game to add that glossy look without heavy performance requirements. It also features motion blur for its movements and responds naturally to light in real life for immersive visuals. A **Box Collider** defines its interaction boundaries, and physics settings make it behave correctly, with proper weight and gravity effects, and nice movement when thrown or rolled.

![image](https://github.com/user-attachments/assets/a0af0847-6ab4-44b5-848e-78b0316b5262)


## Enemy death ##
Killing enemies should be satysfying and rewarding, especially in a game with shooting mechanics. Similar to SuperHot we created a shattering effect with VFX particles and replaceble body parts. <br>
![image](https://github.com/user-attachments/assets/75fc38ed-5194-4504-ad71-b392df1234ad) <br>

The enemy prefab contains game objects for each body part. Each bodypart contains 2 scripts, the `EnemyOnCollison.cs` and the `BodyPartScript.cs`.

![image](https://github.com/user-attachments/assets/06aabb6b-d848-4ed6-8b8e-60966ac88a99) <br>

The enemy on collision instantiates hit particles and calls the bodypart script to replace the body part that was hit. After that it calls the enemy death script in the base class of the enemy. <br>

![image](https://github.com/user-attachments/assets/faf59242-33a2-4f95-ba05-9087a7687ce5) <br>

The body part script is responsible for hiding the specific body part and replacing it with the severed limb. If it was replaced or it was rendered then we return , since the body part was already severed. After that line we instantiate the part and apply a small explosion force to the rigidbody for the limb to fly away. After that we disable the game object and set replaced to true.

![image](https://github.com/user-attachments/assets/24a8aab0-86b9-4b5d-8e19-5427fd7591de)

Each body part was specifically cut using Blender. Blender has a cool option to split an object into different meshes, creating a sastisfying shattering effect. The inside of the body part was colored with an emissive material, to glow and to reflect on lights. Then those body parts were exported into unity where they could be instantiated as game objects.
