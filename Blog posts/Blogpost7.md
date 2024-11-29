# Blogpost 7 #
## Description ##
## Level design ##
### Warehouse level ###
![image](https://github.com/user-attachments/assets/eb008d05-9377-4cf8-970b-7551c45668b8)
![image](https://github.com/user-attachments/assets/f704cafa-e326-4e3b-b65e-8be262b9c7d8)
The warehouse levels are inspired from the stark and gritty aesthetics of SuperHot. The sound of pipes in the background makes the player feel uneasy and confused.
The white material attached on each object represents a great contrast to the blood, enemy and shotting guns. Each level is intricately connected, forming a seamless progression through an abstract, minimalist maze. In the first level, glimpses of the second are visible, providing a sense of continuity and foreshadowing the challenges ahead 
### Science Laboratory ###

**Science Laboratory** - This is a room that I created by importing some assets. There is a **dark blue floor** where the humanoid models were placed to attract the attention of the users while engaging them in gaming. 

The **bold orange tones** of the enemies starkly contrast with the cool hues of the floor, providing high contrast and making them easy to spot during navigation and interaction. The **white camera icon** is strategically positioned to mark observation points, while the **sci-fi-looking machinery** in the background adds realism and purpose to this environment. The entire space has a **clean, futuristic vibe**, perfectly aligned with the immersive experience I’m crafting for my laboratory scene in *Super Not*.

The **table** is positioned in the background, serving as the central point for weapon selection. **Three weapons** are laid out clearly in front, each featuring bold designs and vibrant highlights that draw attention. The table feels like a pivotal spot, where the right weapon can be chosen to prepare for fight ahead. 

The scifi scene doesn't distract from the weapons; instead, it contrasts perfectly, making them impossible to miss. The weapons are arranged for **quick access**, allowing for seamless transitions into the action of battle. It's the perfect setup for making tactical decisions before facing the incoming enemies.

![image](https://github.com/user-attachments/assets/5ab56873-557c-4b22-9b67-02aca4e08949)

![image](https://github.com/user-attachments/assets/9c33b8c2-3054-4be7-9c44-1d52940891c3)


## Science Laboratory 2

The room has a strongly **high-tech, science-fiction feel**—a blend of research and danger. Along the **left wall** stand three **cameras**, tall and pulsing with light. Around the room, various tools and objects enhance the atmosphere, emphasizing advanced experimentation.

On the **right side**, three tables are arranged with weapons, such as shuriken pistol and knives. They can be grasped and used against oncoming enemies. Some experimental glass capsule with grey and green accents surround the area. 

**Mystery emanates** from various **raised platforms** that surround the room. **Glowing lights** and **complicated panels** adorning these platforms suggest they might be devices for generating enemies—or, at the very least, something bad is about to unfold for the player. While some of the platforms are purely cosmetic, others give the entire space a fight atmosphere.

The room combines the **silence of scientific research** with the **anticipation of battle**, drawing attention to its clean-cut design and the shooting action.

![image](https://github.com/user-attachments/assets/181a8127-7c21-4f35-b129-0502b5b050c5)

![image](https://github.com/user-attachments/assets/85031a29-02a1-4ea9-9d3c-aa26ca721b92)


## Science Laboratory 3

In the Laboratory 3 I wanted to make the player perceive to be immersed in a state of **controlled chaos**, where everything has its place. The space is lined with **cabinets**, with a sharp design cutting through the flow of the room. These cabinets disrupt the rhythm in a way that suggests **tension**, as though something is hidden just out of sight, adding to the mystery.

In addittion to that, there are three enemies scattered across the room—one armed with pistols or trying to punch the player. Their movements are calculated. The entire scene feels like a **set-up**. It's a place where **precision and strategy** mean everything, where every decision may determine either life or death for the player.

Near the center are three tables, each with weapons ready to be grasped. **Knives**, lie beside shuriken and there is also a pistol to shoot the enemies. Each item seems capable of delivering a deadly strike.

Opposite these tables, **screens flicker** with constantly refreshed data, giving the impression that the entire environment is being watched by unseen eyes. On the far side of the room, a **door stands ajar**, revealing a row of cameras that appear to control the space, giving the feeling that **full control** over the environment is being exerted by someone—or something.

![image](https://github.com/user-attachments/assets/e0719583-892f-4d5d-b643-dffb29ddca7a)

![image](https://github.com/user-attachments/assets/e7f04f24-bfa6-4428-b5d7-c22635d07e4b)


## Main menu ##

The main menu in *Super Not* is very **minimalistic**. At the top, the title of the game, *Super Not*, is written in a **neat, round white font** that is both easy to read and eye-catching. The smooth, modern curves of the letters give it a **futuristic feel**, standing out clearly against the darker background.

Below the title, there are two buttons: **Start** and **Quit**.

- The **Start** button is white. On hover, it brightens, glowing blue to indicate that it’s ready to be clicked.  
- The **Quit** button, in contrast, has a more **urgent appearance**, and when hovered it draws attention immediately with its red color.

The contrast between the buttons creates a smooth, **intuitive experience**. It’s easy to see which button is selected, and the entire menu feels **responsive**, guiding players through the options without being distracting. 

This simple yet effective design makes navigating the menu feel seamless and engaging.

![image](https://github.com/user-attachments/assets/a0b5d334-8352-470c-8dd0-0a99bcfc2aaf)

![image](https://github.com/user-attachments/assets/183dcb5e-c25d-48a0-993b-6d7faee74d1a)



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





