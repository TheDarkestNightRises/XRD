<H1> Blogpost 2 </H1>

<H2> Description <H2>

In this update, we have implemented the portal and the method to place it, along with a custom portal shader that ensures objects within the portal are only visible from inside of it. Additionally, we configured the AR scene, which includes essential components such as buttons for summoning the portal, XR Origin, XR Interaction Manager, and AR Session

<H2> AR Scene (Andrei)<H2>

This Augmented Reality allows users to place virtual objects in the real world using their mobile phones.

![image](https://github.com/user-attachments/assets/cf2b2e6f-0dd0-4e1b-8aba-a043e46c22b0)

The structure of it has the following elements:

1. AR Session - responsible for managing the AR session lifecycle, including device tracking and environmental understanding.
   
2. XR Interaction Manager - responsible for managing the position and movement of the camera in the AR environment. It contains a camera offset ensuring that the main camera is correctly placed relative to the user device position. The main camera is the actual camera for capturing the AR scene enabling device-based tracking to overlay virtual content on the real world
   
3. XR Origin - responsible for coordinating interaction events and making sure that the input from the user (gestures and taps) is properly connected to components and objects in the scene that answer these inputs.
   
4. Canvas - which represents the UI of the application (buttons for summoning the portal and object description pop-up)

<H2> Portal placement <H2>

<H2> Portal collision <H2>

<H2> Portal Shader <H2>  