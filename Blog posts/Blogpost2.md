# Blogpost 2 #

![image](https://github.com/user-attachments/assets/6e2ad8b2-499e-41b1-aba9-aabeb50c60ce)

In this blog post update, we have implemented the portal and the method to place it, along with a custom portal shader that ensures objects within the portal are only visible from inside of it. Additionally, we configured the AR scene, which includes essential components such as buttons for summoning the portal, XR Origin, XR Interaction Manager, and AR Session 

## AR Scene ##

This Augmented Reality allows users to place virtual objects in the real world using their mobile phones.

![image](https://github.com/user-attachments/assets/cf2b2e6f-0dd0-4e1b-8aba-a043e46c22b0)

The structure of it has the following elements:

1. AR Session - responsible for managing the AR session lifecycle, including device tracking and environmental understanding.
   
2. XR Interaction Manager - responsible for managing the position and movement of the camera in the AR environment. It contains a camera offset ensuring that the main camera is correctly placed relative to the user device position. The main camera is the actual camera for capturing the AR scene enabling device-based tracking to overlay virtual content on the real world
   
3. XR Origin - responsible for coordinating interaction events and making sure that the input from the user (gestures and taps) is properly connected to components and objects in the scene that answer these inputs.
   
4. Canvas - which represents the UI of the application (buttons for summoning the portal and object description pop-up)

## Portal placement ##

![image](https://github.com/user-attachments/assets/1859c7e8-a9bb-48b3-8bcd-452bc4c7c3ad)

The **PortalPlacer** script allows us to place portals using unity's AR raycast manager. It starts by using Unity’s `ARRaycastManager` and `ARPlaneManager` to scan the environment for flat horizontal surfaces. The portal placer inherits from the press input base which listens to touch input.

![image](https://github.com/user-attachments/assets/75e61b54-8c5d-4c33-8764-fd2d2e9830af)

When the user taps the screen, the `OnPress` method is invoked. If the user was actually touching an UI element then we will not perform the summoning of the portal. We can check if the user pressed a button by using `EventSystem.current.IsPointerOverGameObject();`. Also if there is no marker present at the time means that the user is not pointing to the centre of the screen, which means we shouldn't place a portal. If there is a portal in effect we will destroy that portal and make sure we instantiate another one. The `SwitchLocation` method allows the user to switch between what kind of portal can be instantiated.


## Portal collision ##
![image](https://github.com/user-attachments/assets/0aa4d63d-6800-4d1c-8ba6-163d3d8e37cd)

For the portal effect, we detect when the camera collides with the portal's box collider. Once a collision is detected, we adjust the stencil buffer settings to make the portal's contents either visible or invisible based on the camera's position relative to the portal. In the `Start` function we cache the camera component and we set all materials to false (invisible). In the set materials function we first create a `stencilTest` compare boolean. If the `render` is false then it's NotEqual otherwise the value is Equal. We cast this value to int (the _StencilTest is an int comparison) and pass it to the material so that we can 
programatically change the render of the object. 

![image](https://github.com/user-attachments/assets/7968e685-daf4-493b-806f-95e792ec8acc)

The `IsInFront()` method checks whether the camera is positioned in front of or behind the portal. It does this by converting the camera position to the portal’s local space using InverseTransformPoint(), which helps determine if the camera is in front of or behind the portal. We also add an offsett forward to avoid the camera annoying clipping effect when colliding with objects.

![image](https://github.com/user-attachments/assets/fc82db4d-8e8e-4af2-bcc9-7087ee903ac9)

`The WhileColliding()` method constantly checks if the camera has crossed the portal’s threshold. If the camera’s front/back state has changed, we toggle inVirtualWorld to indicate if the camera is in the virtual world (which means that we should render all objects to visible). That means that we can swap between the `virtualWorld` inside of the portal and the real life outside. 
This script allows for a seamless portal effect by determining when the camera crosses the portal's threshold, toggling visibility between real and virtual worlds accordingly. 

## Portal Shader ##  
![image](https://github.com/user-attachments/assets/06bf79d3-1bb2-4e72-9db1-d0f839b51d88)
Using Unity’s ShaderLab, we can develop powerful shaders that control how the GPU renders objects. This is incredibly useful for managing which parts of a scene should or shouldn’t be rendered, enabling effects like object masking, outlines, mirrors, and shadows with ease.

In the code above, a custom shader named `Custom/FilterShader` is created. It defines two properties: a color (defaulting to white) and a stencil property, `_StencilTest`. The `_StencilTest` property can be set to either Equal or NotEqual. When set to Equal and the stencil buffer value is `1`, the shader will render objects on the screen, making them visible. If set to NotEqual, objects using this shader will not be rendered in areas marked with `1` in the stencil buffer. This property effectively controls whether objects are displayed on the screen, which can be useful in scenarios like switching between real-world and virtual-world like in our portal.

In the `Stencil` block, we define the stencil reference value as 1, and then compare the stencil buffer to this value. If `_StencilTest` is set to Equal, only areas marked with 1 will render objects. Conversely, if _StencilTest is set to NotEqual, those areas will mask the objects, hiding them from view. This setup enables the portal to act as an interactive medium, where we can switch between displaying objects in the real world and in a virtual world.

In the project, similar shaders(Lit, Skybox, Unlit,etc.) were created with the same `_StencilTest` property to accommodate different needs, while following the same logic to control object visibility through code. This flexible approach allows us to dynamically set whether objects render or not based on the stencil buffer values, adapting to the requirements of different effects.

![image](https://github.com/user-attachments/assets/c2939e27-ea8d-4da9-a10c-320d71ed5984)

For the `PortalShader` the approach is similar but we should also take into account that this object can be walked through. The portal shader should be see through and should not use many resources to render since it will only display the virtual world. We tag this object as `Opaque` so that it is processed in the appropiate queue, this helps with clipping and rendering even though the object is meant to be transparent. The `LOD` is set to 100 which means that the object will not have a high level of detail since its not rendering any complex visual effects. The `ZWRITE` property is set to off because the object should not have any depth as to not obscure anything in the way. The `Cull` is set to off means that both the front and the back of the object is rendered because the portal has 2 faces. The `ColorMask` is set to 0 because this portal has no color so we have no need to set any color channels. 

In the `Stencil` block we want to make sure that we always write 1 to the stencil buffer. The `Comp` is set to always, which means the stencil operation will always be applied, regardless of any existing stencil values. The purpose of `CPROGRAM` block is to define a minimal vertex and fragment shader that render nothing visible to the screen. The frag function determines the color of each pixel. `return fixed4(0.0, 0.0, 0.0, 0.0);` returns a fully transparent color (black with zero opacity). This renders nothing visible on the screen. This is the final portal effect: ![image](https://github.com/user-attachments/assets/ceec75ce-9cb1-4bcf-b5a6-200f440a88e5)


