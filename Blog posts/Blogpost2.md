<H1> Blogpost 2 </H1>

<H2> Description <H2>

In this update, we have implemented the portal and the method to place it, along with a custom portal shader that ensures objects within the portal are only visible from inside of it. Additionally, we configured the AR scene, which includes essential components such as buttons for summoning the portal, XR Origin, XR Interaction Manager, and AR Session

<H3> AR Scene (Andrei)<H3>

This Augmented Reality is allowing users to place virtual objects in the real world using their mobile phones.

The structure of it has the following elements:

1. Ar Session - responsible for managing the AR session lifecycle, including device tracking and environmental understanding.
2. XR Interaction Manager - responsible for managing the position and movement of the camera in the AR environment. It contains a camera offset ensuring that the main camera is correctly placed relative to the user device position. The main camera is the actual camera for capturing the AR scene enabling device-based tracking to overlay virtual content on the real world
3. XR Origin - responsible for coordinating interaction events and making sure that the input from the user (gestures and taps) is properly connected to components and objects in the scene that answer these inputs. 
4. Canvas - which represents the UI of the application (buttons for summoning the portal and object description pop-up)

<H3> Portal placement <H3>

<H3> Portal collision <H3>

<H3> Portal Shader <H3>  