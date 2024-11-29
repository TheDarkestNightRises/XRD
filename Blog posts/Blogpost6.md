# Blogpost 6 #
## Description ##
## Enemy Bruiser ##
## Katana ##
## AK47 ##
## Grabbables ##
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
