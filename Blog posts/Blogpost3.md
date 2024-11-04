# Blogpost 3 #

## Description ##

In this update, we have added a skybox to the dimension inside of the portal so that the AR environment to not collide with real-life elements. We've also added a 3D text box that will automatically pop up when the device is looking directly at an object that has that property. A 2D alternative was also implemented so that when the user taps on a specific object, a description of that object will be displayed. For a more vibrant and engaging experience, we've also added some background music to fit with each environment. 

## Skybox ##  
![image](https://github.com/user-attachments/assets/b0faed82-3aab-4388-a5d5-6d3a1b17e26b)

In Unity AR projects, a typical skybox isn’t rendered because the real-world camera feed takes priority. To circumvent this we added a quad where a camera will project the look of the skybox using a render material. 
First, a secondary `kybox Camera` is created specifically to render only the skybox, which optimizes performance by ignoring other layers. This Skybox Camera is made a child of the main AR camera so it moves and rotates together, ensuring the skybox effect stays consistent with the user's view. The Skybox Camera’s output is directed to a Render Texture, which is then applied to a material. This material, now containing the skybox view, is applied to a large quad positioned far away from the main camera, simulating a distant sky.
To create a beautiful skybox a procedural skybox was used. The values of the tint color and the ground tint were changed to simulate more of a sunset.

## 3D Text box ##  

## 2D Object Description (Andrei)##

As a way of learning about specific objects or animals, we have implemented a 2D object description on tap. To be able to find out about some information about a specific object or animal, the user can tap on the hitbox of an object and the text will appear on the top of the screen.
  
<br><img width="251" alt="1" src="https://github.com/user-attachments/assets/7dc4c8d9-a675-4f50-9f57-a1abd08b3c1a"><br><br>

To make that happen, the object should have the Object Description Handler component where the description will be written.

<br>![image](https://github.com/user-attachments/assets/30e37681-72f2-4c4f-8f20-a1bcfeea84d1)<br><br>

The AR scene uses the Object Tap Handler to identify the objects that have a description component and ensures that upon tapping on them, a Panel with a TextMeshPro that takes the description as text, will appear on top of the screen.

<br>![image](https://github.com/user-attachments/assets/71b507a3-e88c-44de-872d-05c6791299d9)<br><br>

## Spatial Music ##  
