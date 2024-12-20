# Blogpost 6 #

## Description ##

We have added a bruiser enemy which works the same as the gunner enemies but instead, they are fighting with their fists. To better manage the enemies' state we have added an "EnemyBase" script from which both bruiser and gunner enemies inherit. We have also added new weapons: a katana which is capable of slicing enemies and destroying bullets,  an ak47 which can be grabbed with two hands and fire at a high rate,  a shuriken which can be thrown at a high speed, and a knife which can be used as a melee weapon or throw at enemies. We have also implemented VFX effects for enemies death and now the bodies dynamically detach upon death.

## Enemy Bruiser ##
![image](https://github.com/user-attachments/assets/8307e078-679e-403c-9055-1ee0ea9ff540)# <br>
The enemy bruiser is designed to relentlessly chase the player and apply constant pressure, forcing the player to take immediate action to avoid being overwhelmed.

![image](https://github.com/user-attachments/assets/9071f521-ce87-4a94-b317-81ea8428014e) <br>

To better organize the code structure a `EnemyBase` script was created. All enemies inherit from this script containing different helper methods. For example, all enemies have ragdolls and die in the same way so they have the same death method, which simplifies a lot of the code.
![image](https://github.com/user-attachments/assets/8cdb5ede-455d-4489-88cb-4197fcdfbfee) <br>

At the start of the `EnemyBruiser` script we cache the player transform. Then if the distance is closer to the player, the bruiser will get `provoked`. If the enemy is unprovoked he will idle a while a player might be in range.

![image](https://github.com/user-attachments/assets/5e42f4dd-4ff6-4712-8919-389c9721b2e3) <br>

The `EngangeTarget` method is responsible for the enemy's behavior while provoked. If the enemy is in punching range then he will perform a punch motion. Otherwise, the enemy will chase the target until it is close in range.

![image](https://github.com/user-attachments/assets/f24fbeb4-088c-48de-b674-65326380be96) <br>

The `Punch` method calls the punch animations. The enemy has sphere colliders that on trigger will kill the player if touched. Chasing the target is done using the navmesh surface and setting the destination of the agent to be the player. 

## Katana ##

Katana is a Japanese sword and it is one of our weapons that can be used to slice enemies. It has a box collider to be able to make the collision with the enemies. To be able to grab it it has the "XR Grab interactable two attachments" attached to it. That script also lets the user grab the katana in either hand with a different grabbing point. The katana has 2 main functionalities: slice enemies and destroy bullets. To destroy enemies it uses the "On trigger Die script" which uses "OnTriggerEnter" to check if it is colliding with an enemy. For the bullets, it is using the "Destroy Bullet" script which is also using "OnTriggerEnter"
to check if collides with a bullet. On collision, it destroys the bullet object.

![image](https://github.com/user-attachments/assets/d37b199e-8483-43d7-a439-40a0e1cf78e9)

## AK47 ##

AK47 known also as "Avtomat Kalashnikova" it's a weapon from 1947 that is commonly used in games. It's an atypical weapon from the other since it uses two grabbing points. 

![image](https://github.com/user-attachments/assets/5720c7ad-6dce-41c2-bbe6-d291a46a1aec)

To make that possible the "XR Grab Interactible" script was used with an "attach transform" and an "secondary attach transform".

![image](https://github.com/user-attachments/assets/78c8e316-6c45-43e4-98e1-1dcf256d4006)

To be able to fire from it the AK47 has an "AK47 Fire" script. The Fire method stores the last fire time to ensure the fire rate of the AK47. Then spawns a new bullet prefab at the gun's spawn point and applies velocity in the forward direction using the Rigidbody component. For a better performance, the bullets are destroyed automatically after 5 seconds.

![image](https://github.com/user-attachments/assets/118887f0-8034-4df2-808f-e23227c52dca)

## Grabbables ##

![image](https://github.com/user-attachments/assets/dff595eb-d3eb-420c-873f-5c8bc573d75c)

This Unity script enhances the interaction of VR objects, adding distinctive attachment points for the left and right hands. This script inherits from the `XRGrabInteractable` class, thus enabling an object to dynamically switch its attachment point depending on which hand grabbed it. The script defines two variables of type Transform, one for the left hand and one for the right. Upon object grab, it checks the VR controller's tag to identify it as either the left or right hand and thus positions the attachment point accordingly. To set this up create two empty GameObjects in the scene as attachment points, and assign them via the script in the Inspector. Also tag the left and right controllers in Unity's **Tags & Layers** settings as "Left Hand" and "Right Hand". Then the script will automatically align the object with the proper hand. Because it integrates neatly with Unity's XR Interaction Toolkit, making a solution simple to implement that could provide in-VR interaction to objects that feel intuitive and natural with hand motions.


## Shuriken 

The image shows the configuration of the **Shuriken** object, a throwable weapon. The shuriken is designed for intuitive VR interaction and provides a satisfying combat experience for players.

![image](https://github.com/user-attachments/assets/cfaf9aee-ea18-4d8f-80b5-b55908ee039c)

The shurikens are positioned on tables across the labs, placed conveniently for quick access. This setup ensures that grabbing and throwing them is intuitive, fitting smoothly into the flow of combat without breaking the pace. The technical integration makes these launchable shurikens a dynamic and satisfying tool for taking down enemies in the game.

The shuriken size is scaled up for a larger appearance. A Rigidbody component is added to handle physics with a standard mass, no drag, and slight angular drag, allowing the shuriken to spin realistically while gradually slowing. Gravity is turned off to keep it on a course of flight for controlled, precise throws. Collision Detection is set to Discrete for efficient handling of interactions. The Rigidbody is dynamic, enabling full interaction with forces and collisions in the game.
The **XR Grab Interactable Two Attach** script allows for VR interaction, enabling the shuriken to be grabbed and thrown within the VR environment. The interaction mode is set to Single, allowing only one action or focus at a time.
The movement of the shuriken is Instantaneous. It immediately responds on the instant of grabbing or throwing it. It tracks position and rotation for precise control, with no smoothing for sharp responsiveness. Slight smoothing upon throw gives a more natural trajectory.
This setup keeps the shuriken intuitive, responsive, and accurate-pretty versatile, and effective as a throwable weapon in-game.


![image](https://github.com/user-attachments/assets/65a23e46-782a-45f8-bfdc-bf76c554f654)

- The shurikens are placed on tables across the labs, positioned for quick and easy access. This setup ensures that players can grab and throw them without interrupting the flow of combat, keeping the gameplay smooth and intuitive.



# Knife 

![image](https://github.com/user-attachments/assets/62932291-48a4-4fe8-9bb3-0ab426056d75)

![image](https://github.com/user-attachments/assets/b9e36f5b-8eb6-4d83-a8a8-5454ebb00b95)


In Unity, the **Knife** object has been set up to be a usable weapon for the VR game. It has been tagged as a Weapon and set to the Default layer, while its size is left to the default scale. It adds a Rigidbody component, which allows it to interact with physics; its mass is set to standard, and it has no drag, but slight angular drag allows it to naturally spin or tilt and also slow down rotation over time. It has gravity turned on to make sure it falls when let loose. Its Rigidbody is set to Dynamic and the collision detection to Discrete for efficiency; thus, no constraints have been set, and that will make the knife free to move. To enable interaction in VR, the **XR Grab Interactable Two Attach** script allows the knife to be picked up and manipulated, supporting two-handed interactions if needed. It is linked to the XR Interaction Manager, which manages how the object is handled in the VR environment. The Interaction Layer Mask is set to Everything, which allows the knife to interact with any object. Interaction distance is calculated from the Collider Position, with no custom reticle defined; it depends on where the player places his hand. Select Mode and Focus Mode are Single, so only one action or focus is allowed at a time. The movement of the knife is responsive and intuitive, reacting instantaneously to the player's hand movement, tracking position, and rotation so that it precisely follows the controller's movements. Both position and rotation have Smoothing disabled to make it sharp and direct during gameplay. When released, the knife can be thrown with a slight Throw Smoothing Duration to make it natural yet accurate. This configuration allows the knife to be a very realistic, responsive weapon inside VR because of dynamic physics with precise interaction by the player in close combat and when thrown.


## Bottle

![image](https://github.com/user-attachments/assets/2d0dc403-15c2-407e-966c-9a67bdf857de)

The Unity inspector panel describes the setup of the **Bottle** a weapon created for combat. It's created using a reusable prefab with adjustments for its placement and use in the game. The bottle is small, upright, and scaled to resemble the size of a real whisky bottle. The bottle gets its 3D form from a **Bottle** mesh, together with a sleek and brilliant material called **"black super hot."** It receives shadows for realism, effectively merging into the dynamic lighting of the game to add that glossy look without heavy performance requirements. It also features motion blur for its movements and responds naturally to light in real life for immersive visuals. A **Box Collider** defines its interaction boundaries, and physics settings make it behave correctly, with proper weight and gravity effects, and nice movement when thrown or rolled.

![image](https://github.com/user-attachments/assets/a0af0847-6ab4-44b5-848e-78b0316b5262)


## Enemy death ##
Killing enemies should be satisfying and rewarding, especially in a game with shooting mechanics. Similar to SuperHot we created a shattering effect with VFX particles and replaceable body parts. <br>
![image](https://github.com/user-attachments/assets/75fc38ed-5194-4504-ad71-b392df1234ad) <br>

The enemy prefab contains game objects for each body part. Each body part contains 2 scripts, the `EnemyOnCollison.cs` and the `BodyPartScript.cs`.

![image](https://github.com/user-attachments/assets/06aabb6b-d848-4ed6-8b8e-60966ac88a99) <br>

The enemy on collision instantiates hit particles and calls the body part script to replace the body part that was hit. After that, it calls the enemy death script in the base class of the enemy. <br>

![image](https://github.com/user-attachments/assets/faf59242-33a2-4f95-ba05-9087a7687ce5) <br>

The body part script is responsible for hiding the specific body part and replacing it with the severed limb. If it was replaced or it was rendered then we return, since the body part was already severed. After that line, we instantiate the part and apply a small explosion force to the rigid body for the limb to fly away. After that, we disable the game object and set replaced to true.

![image](https://github.com/user-attachments/assets/24a8aab0-86b9-4b5d-8e19-5427fd7591de)

Each body part was specifically cut using Blender. Blender has a cool option to split an object into different meshes, creating a sastisfying shattering effect. The inside of the body part was colored with an emissive material, to glow and to reflect on lights. Then those body parts were exported into unity where they could be instantiated as game objects.
