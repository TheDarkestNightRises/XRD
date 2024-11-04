# Blogpost 3 #

## Description ##

In this update, we have added a skybox to the dimension inside of the portal so that the AR environment to not collide with real-life elements. We've also added a 3D text box that will automatically pop up when the device is looking directly at an object that has that property. A 2D alternative was also implemented so that when the user taps on a specific object, a description of that object will be displayed. For a more vibrant and engaging experience, we've also added some background music to fit with each environment. 

## Skybox ##  
![image](https://github.com/user-attachments/assets/b0faed82-3aab-4388-a5d5-6d3a1b17e26b)

In Unity AR projects, a typical skybox isn’t rendered because the real-world camera feed takes priority. To circumvent this we added a quad where a camera will project the look of the skybox using a render material. <br>
First, a secondary `Skybox Camera` is created specifically to render only the skybox, which optimizes performance by ignoring other layers. This Skybox Camera is made a child of the main AR camera so it moves and rotates together, ensuring the skybox effect stays consistent with the user's view. The Skybox Camera’s output is directed to a Render Texture, which is then applied to a material. This material, now containing the skybox view, is applied to a large quad positioned far away from the main camera, simulating a distant sky. <br>
To create a beautiful skybox a procedural skybox was used. The values of the tint color and the ground tint were changed to simulate more of a sunset.

## 3D Text box ##  

### Interactive Storytelling with Pop-Up Text Features
To make the Leonardo's portal experience both educational and immersive, I integrated a pop-up text feature that provides background information on each invention. Here’s an overview of how this interaction is implemented:

- FaceCamera Script: The FaceCamera script in Unity ensures that a GameObject continuously faces the main camera. It stores a reference to the camera's transform and uses the Update method to rotate the GameObject toward the camera using transform.LookAt(cam). It then modifies the local rotation angles to lock the x and z axes at 0, preventing any tilt or roll. This behavior is ideal for UI elements or labels that should always remain oriented toward the camera for visibility.

![image](https://github.com/user-attachments/assets/9d908641-eef3-4ba9-91df-4e4ef7ef505b)
  
- Gaze Script: The Gaze script in Unity allows a GameObject to display information when the player looks at it. It uses raycasting to detect if the object being gazed at has the tag "hasInfo". If so, it retrieves the InfoBehaviour component and opens the associated information. If the player gazes away or looks at a different object, it closes the current information display. This enhances interactivity by providing relevant context about objects in the scene.

![image](https://github.com/user-attachments/assets/6d8e469d-61d9-4287-b626-ac93e30fbe36)

- InfoBehaviour Script: The InfoBehaviour script controls the animation of pop-up panels that display information about specific inventions. When a user focuses on a particular object, the associated information panel scales up smoothly to provide relevant details, enhancing user engagement and interactivity. Conversely, as the user’s gaze moves away, the panel scales back down to zero, ensuring that the interface remains uncluttered and visually appealing.

![image](https://github.com/user-attachments/assets/fae712fa-3ea1-4ead-941c-23424c67a56d)


![popuptext](https://github.com/user-attachments/assets/ed67d19b-e6fe-49b0-bebc-460f730f1a6e)

### Enhancing Engagement and Learning with Pop-Up Text
The pop-up text system encourages focused exploration, displaying information only when the visitor is actively engaging with a model. This design choice avoids information overload and helps create a more interactive and personalized learning experience. Visitors are free to explore each invention at their own pace, gaining a deeper understanding of Leonardo's contributions to engineering.

## 2D Object Description (Andrei)##

As a way of learning about specific objects or animals, we have implemented a 2D object description on tap. To be able to find out about some information about a specific object or animal, the user can tap on the hitbox of an object and the text will appear on the top of the screen.
  
<br><img width="251" alt="1" src="https://github.com/user-attachments/assets/7dc4c8d9-a675-4f50-9f57-a1abd08b3c1a"><br><br>

To make that happen, the object should have the Object Description Handler component where the description will be written.

<br>![image](https://github.com/user-attachments/assets/30e37681-72f2-4c4f-8f20-a1bcfeea84d1)<br><br>

The AR scene uses the Object Tap Handler to identify the objects that have a description component and ensures that upon tapping on them, a Panel with a TextMeshPro that takes the description as text, will appear on top of the screen.

<br>![image](https://github.com/user-attachments/assets/71b507a3-e88c-44de-872d-05c6791299d9)<br><br>

## Spatial Music ##  

# Interactive Portal Project

In this interactive portal project, visitors can embark on **immersive journeys** through different eras, each with its own distinctive atmosphere.

## Viking-Inspired Environment music

One path leads to a **Viking-inspired environment**, where epic, atmospheric music sets the tone, transporting visitors into the world of **Norse explorers** and legendary warriors. The evocative soundscape brings this ancient setting to life, adding a sense of **adventure and discovery**.

## Leonardo da Vinci environment music

In the **Leonardo da Vinci** section, a soothing piano melody fills the air, creating a calm, contemplative ambiance ideal for exploring **Leonardo’s mechanical innovations**. This relaxing soundtrack enhances the thoughtful design and interactive storytelling, inviting visitors to reflect on **Leonardo’s genius** and the impact of his inventions.

## Prehistoric Environment music

Another path offers a **prehistoric environment** steeped in mystery, with subtle dinosaur sounds that evoke the **primal landscapes of ancient Earth**.

Each of these environments is carefully crafted, combining **ambient sound, design, and interactivity** to fully engage visitors in the stories of **innovation and history**, making each exploration a memorable journey through time.

![image](https://github.com/user-attachments/assets/288ed01e-1bb7-4ed4-8bad-55ede0f8994d)

The Inspector panel in Unity for the **BackgroundMusic** object shows its **Audio Source** component settings. The audio file titled *music* is assigned to play automatically when the scene loads, and it will loop continuously. The sound is centered, with a moderate volume of just over half, and will be affected by environmental effects like reverb zones since all the bypass options are unchecked.

The audio has **3D effects** meaning that the volume and direction will change based on the listener's position. It has a standard **Doppler effect**, and the volume decreases logarithmically with distance, ensuring a natural sound experience. The volume is full within a radius of **0.37 units** and drops off significantly beyond **100 units**.

The rolloff graph illustrates how the volume fades with distance, while other parameters like **spatial blend** and **reverb zone mix** remain relatively stable. Overall, these settings contribute to an immersive audio experience, making it feel like the music is part of the 3D environment.
