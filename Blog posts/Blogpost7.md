# Blogpost 7 #
## Description ##
## Level design ##
## Science Laboratory

**Science Laboratory** - This is a room that I created by importing some assets. There is a **dark blue floor** where the humanoid models were placed to attract the attention of the users while engaging them in gaming. 

The **bold orange tones** of the enemies starkly contrast with the cool hues of the floor, providing high contrast and making them easy to spot during navigation and interaction. The **white camera icon** is strategically positioned to mark observation points, while the **sci-fi-looking machinery** in the background adds realism and purpose to this environment. The entire space has a **clean, futuristic vibe**, perfectly aligned with the immersive experience I’m crafting for my laboratory scene in *Super Not*.

The **table** is positioned in the background, serving as the central point for weapon selection. **Three weapons** are laid out clearly in front, each featuring bold designs and vibrant highlights that draw attention. The table feels like a pivotal spot, where the right weapon can be chosen to prepare for fight ahead. 

The scifi scene doesn't distract from the weapons; instead, it contrasts perfectly, making them impossible to miss. The weapons are arranged for **quick access**, allowing for seamless transitions into the action of battle. It's the perfect setup for making tactical decisions before facing the incoming enemies.

![image](https://github.com/user-attachments/assets/5ab56873-557c-4b22-9b67-02aca4e08949)

![image](https://github.com/user-attachments/assets/9c33b8c2-3054-4be7-9c44-1d52940891c3)


## Main menu ##
## Gameplay loop ##
## Reset ##
## Performance ##
Performance is really important for VR experiences. Any lag or input delay could massively impact the experience and shatter the illusion. VR headsets also have hardware limitations, which means that we need to take a few things into consideration. To improve performance we did the following:
#### Lighting ####
For the lighting we used subtractive shadows because they pre-calculate shadow details and apply them as a static layer to the scene, reducing the need for complex real-time calculations. In the scene all the light are set to baked. The environment was set to static to improve performance and the models were set to receive UV lightmaps. By clicking on the generate lighing we can generate lights for the scene and then we can store them in a map in the scene folder.
![image](https://github.com/user-attachments/assets/62357399-49e4-4e2c-abc6-9fa639f92690)
#### Quality ####
Unfortunately VR headsets don't have a lot of hardware power when it comes to rendering. We disabled the VCount sync as well as setting the build quality to balanced. At first we used the built in render pipeline but then we switched to URP for the perfomance gains it uses. In older versions of the game we had also postprocessing but we disabled it because it was too slow for the VR experience. 
![image](https://github.com/user-attachments/assets/06269a40-50fe-4705-be06-eff6333efb62)
#### Oclusion ####
Using oclusion is a powerful performance tool, because it renders only the objects that are visible to the screen. If any objects hide behind something, then that object will not be rendered. All levels contain clusion set on the main camera of the player.
#### Level design ####
Initially, we created large levels for players to explore and fight enemies, but this proved too demanding for the VR headset. To optimize performance, we significantly reduced the size of the levels, creating a more confined and claustrophobic experience. Additionally, we selected assets with fewer vertices to further improve performance.
#### Physics ####
Our game uses a lot of physics. Setting the time to be slower is unfortunately a huge performance problem. We also encountered a very annoying bug where the process responsible for setting the fixed delta time to normal would get stuck, making the game very slow on every scene load. Because this process takes a lot of time , the game would run slower and slower progressively. We didn't find a fix for this, but we hope Unity will fix this at some point with later releases since there is no issue with any code written.





