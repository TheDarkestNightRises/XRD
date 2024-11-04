<H1> Blogpost 3 </H1>

<H2> Description <H2>

In this update, we have added a skybox to the dimension inside of the portal so that the AR environment to not collide with real-life elements. We've also added a 3D text box that will automatically pop up when the device is looking directly at an object that has that property. A 2D alternative was also implemented so that when the user taps on a specific object, a description of that object will be displayed. For a more vibrant and engaging experience, we've also added some background music to fit with each environment. 

<H2> Skybox <H2>  

<H2> 3D Text box <H2>  

<H2> 2D Object Description (Andrei)<H2>

As a way of learning about specific objects or animals, we have implemented a 2D object description on tap. To be able to find out about some information about a specific object or animal, the user can tap on the hitbox of an object and the text will appear on the top of the screen.
  
<br><img width="251" alt="1" src="https://github.com/user-attachments/assets/7dc4c8d9-a675-4f50-9f57-a1abd08b3c1a"><br><br>

To make that happen, the object should have the Object Description Handler component where the description will be written.

<br>![image](https://github.com/user-attachments/assets/30e37681-72f2-4c4f-8f20-a1bcfeea84d1)<br><br>

The AR scene uses the Object Tap Handler to identify the objects that have a description component and ensures that upon tapping on them, a Panel with a TextMeshPro that takes the description as text, will appear on top of the screen.

<br>![image](https://github.com/user-attachments/assets/71b507a3-e88c-44de-872d-05c6791299d9)<br><br>

<H2> Spatial Music <H2>  
