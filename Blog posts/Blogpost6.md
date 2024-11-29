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
# VR Object Interaction Script Overview

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

## Integration with XR Interaction Toolkit

This script integrates smoothly with Unity's XR Interaction Toolkit, making it simple to implement and providing a seamless, intuitive, and natural in-VR interaction experience with hand motions.


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
