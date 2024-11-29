# Blogpost 7 #
## Description ##
## Level design ##
## Main menu ##
## Gameplay loop ##
## Reset ##
## Performance ##
Performance is really important for VR experiences. Any lag or input delay could massively impact the experience and shatter the ilusion crafted. VR headsets also have hardware limitations, which means that we need to take a few things into consideration. To improve performance we did the following:
#### Lighting ####
For the lighting we used subtractive shadows because they are the most performant, because they pre-calculate shadow details and apply them as a static layer to the scene, reducing the need for complex real-time calculations. In the scene all the light are set to baked. The environment was set to static to improve performance and the models were set to receive UV lightmaps. By clicking on the generate lighing we can generate lights for the scene and then we can store them in a map in the scene folder.
![image](https://github.com/user-attachments/assets/62357399-49e4-4e2c-abc6-9fa639f92690)
#### Quality ####
Unfortunately VR headsets don't have a lot of hardware power when it comes to rendering. We disabled the VCount sync as well as setting the build quality to balanced. At first we used the built in render pipeline but then we switched to URP for the perfomance gains it uses. In older version of the game we had also postprocessing but we disabled it because it was too resource intensive for the VR experience. 
![image](https://github.com/user-attachments/assets/06269a40-50fe-4705-be06-eff6333efb62)
#### Oclusion ####
Using oclusion is a powerful performance tool, because it renders only the objects that are visible to the screen. If any objects hide behind something, then that object will not be rendered. All levels contain some sort of oclusion.
#### Level design ####
Initially, we created large levels for players to explore and fight enemies, but this proved too demanding for the VR headset. To optimize performance, we significantly reduced the size of the levels, creating a more confined and claustrophobic experience. Additionally, we selected assets with fewer vertices to further improve performance.
#### Physics ####
Our game uses a lot of physics. Setting the time to be slower is unfortunately a huge performance problem. We also encountered a very annoying bug where the process responsible for setting the fixed delta time to normal would get stuck, making the game very slow on every scene load. Because this process takes a lot of time , the game would run slower and slower progressively. We didn't find a fix for this, but we hope Unity will fix this at some point with later releases since there is no issue with any code written.





