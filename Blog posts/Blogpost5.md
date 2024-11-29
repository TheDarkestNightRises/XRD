# Blogpost 5 #

## Description ##
## VR setup ##
## Pistol ##

![image](https://github.com/user-attachments/assets/256af9ce-b48c-4338-8e57-26fa0c241480)


The **Pistol** object in this case defines both the functionality and physical properties of a pistol for use in *SuperNot* game. The name of the object is "Pistol", attached to a prefab, and no overrides are applied. No tag has been added to it, nor is it assigned to any layer. Its position is set in the game world, no rotation applied, and a scale to size it accordingly. A **Box Collider** component is applied to define the physical bounds of the pistol for collision detection. The collider is small, with slight offsets, and is set to be a solid object rather than a trigger.  

The pistol has a **Rigidbody** component attached to it, which enables the pistol to interact with Unity's physics. It has a standard mass and low angular drag to provide some resistance to rotation. Gravity is turned on, so if the pistol is not supported, it will fall. Its collision detection is discrete; the object is not marked as kinematic, meaning it will respond to physical forces in the game world.  

![image](https://github.com/user-attachments/assets/01a1042a-a734-448f-a4bd-478d4f19f498)

A custom script named **FireBullet** has been created to handle the shooting mechanics. It references a bullet prefab and an exact spawn point at which bullets are instantiated. The bullets are given a set speed, and an audio clip is played through an attached Audio Source component when the pistol is fired. A particle system is also used to create a muzzle flash for the pistol, providing visual feedback whenever the pistol is fired.  

This setup will ensure that the pistol will have realistic physics interactions, be able to fire projectiles complete with sound and visual effects, making it a fully functional weapon in the VR game environment.

## Enemy Gunner ##
![image](https://github.com/user-attachments/assets/1a844cac-a23e-4c68-a184-a318b698d85b) <br>
The enemy gunner is one of the most prominent enemies in our game. He is using the same script as the pistol that was explained previously and tries to shot down the player by aiming at his head. 
To create the enemy a 3d model was imported which is similar to the one in SuperHot , a geometrical blob with a bunch of features. <br>
![image](https://github.com/user-attachments/assets/b3eaa08c-1fd8-4cc8-b220-5dcb77e62454) <br>
The character contains joints for legs, arms , head etc. We first started addin g a ragdoll to the character. 
When the enemy dies then he could roll over the floor creating an interesting effect. At the start of the game we setup the ragdoll by setting all the rigidbody's in body parts kinematic to true. 
That way we could enable ragdoll later when the enemy dies.
The enemy gunner is using NavMesh Agent AI. We baked a navmesh surface for the levels so that the enemy could understand how to reach the player. <br>
![image](https://github.com/user-attachments/assets/e49edde1-fb1f-45af-b967-8f0a3f947f4d) <br>
At the start of the game the player head and the player transform is cached. In the update loop we set the agent destination to be close to player. When the player is reaching the attack range then we stop the agent and the enemy gunner faces the target.
The `Shoot` animation is triggered, and during its apex, an animation event is invoked. <br>
![image](https://github.com/user-attachments/assets/31bdc63f-59ad-4218-8a7d-84ec27e18761) <br>
The event animation will call the method `ShootEnemy`. This method will calculate slightl a skewed distance from the head of the player by using a random number and then subtracting the number. This results in the enemy missing shoots from time to time as to not make the game unfair. 
Then we align the spawnpoint of the bullet which is present on the gun script to be the same as the direction where we are firing. Finally we call the gun fire method which will spawn a bullet on that trajectory.  <br>
![image](https://github.com/user-attachments/assets/e95b1c65-4c3f-42ca-bcfd-3ae5c87e8a5a) <br>
When the enemy dies he will throw the gun. First we reset the local rotation of the gun because we changed it at the moment of firing. Then we would calculate a parabolic path from the gun position to the player position using the method `BallisticVelocityVector`.  <br>
![image](https://github.com/user-attachments/assets/0d25ae33-bd4a-4f14-a6af-88323223742a) <br>
The `BallisticVelocityVector` calculates the required velocity for the gun to create a parobilc path like in the picture above. This parabolic path starts from the initial position of the hand and then we will end up slightly above the player's head.
This method is using a projectile motion formnula. It uses the positions of the source and target, adjusts for height differences, and applies a specified launch angle to compute the velocity. 
The method ensures the object follows a parabolic trajectory by factoring in gravity and trigonometric calculations, resulting in a natural throw. 
To learn more on how this effect can be acheived I will link this video, because it will take me a lot of time to explain this: https://www.youtube.com/watch?v=8NLzuURxFwY&t=708s
## Time manager ## 
