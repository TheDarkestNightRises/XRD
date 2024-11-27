# Blogpost 4 #

## Description ##

In this update, we've made some improvements to the placement marker and fixed some clipping issues while transitioning from the real world to the inside of a portal. To make the experience more pleasant, we have added an interface before entering the app and we have properly built the portal environments to create an immersive experience.

## Marker ##

![image](https://github.com/user-attachments/assets/d5d93ac1-4764-48c7-9aff-8dc19b8b6bdf)

# Marker Component Overview

The marker component enhances the immersive experience and user interaction by providing a clear visual guide. By using raycasting to detect flat surfaces, the script helps users easily identify the ideal spots for their portals.

## UpdateMarkerPosition Method

The `UpdateMarkerPosition` method plays a crucial role in keeping the marker accurately positioned. It calculates the center of the screen and performs a raycast to check for valid surfaces below. When it finds a suitable surface, the method updates the marker’s position and rotation to match, ensuring it remains clear and visible for users. If no valid surface is detected, the marker is turned off, giving users straightforward feedback about where they can and cannot place a portal.

## OnPress Method

Meanwhile, the `OnPress` method manages the user's interactions when they tap the screen to place a portal. It first checks whether the marker is active and ensures that the user isn’t touching any UI elements that could interfere with the action. The method allows the portal to be placed right at the marker’s last detected position.

This design highlights the user experience and allows users to engage with the virtual environment fluently.

![image](https://github.com/user-attachments/assets/c4831b6a-2da1-421b-ac01-d931a9af28cf)

## App UI ##  

The UI of the application consists of 3 buttons that resemble 3 different historic places: Leonardo da Vinci's pieces of art, the Vikings era, and the Mesozoic era.

<br>![image](https://github.com/user-attachments/assets/a3565123-922b-4476-b8d3-ffc3f0af11b8)<br><br>

Upon pressing one of these 3 buttons, the specific era portal will appear. Only one portal can be placed at a time. Upon placing another portal, the old one will disappear.

## History locations environments ##

### Mesozoic era ###

The Mesozoic era is known as the "Age of Reptiles" marking the existence of different types of dinosaurs. Especially for children, this topic is always an interesting one, and since it is hard to resemble how they exactly look or the color of their skin, the existence of them can not be denied. In this environment 3 dinosaur species were covered: Stegasaurus, Velociraptor, and Pachycephalasaurus, each of them having a description of the species that they belong to, upton tapping on them.

<br>![image](https://github.com/user-attachments/assets/0e3c576d-9e90-4285-85fd-7eda6e5443fb)<br><br>

### Vikings era ###
![image](https://github.com/user-attachments/assets/19c2d45c-2c7a-49fc-a615-cfba118fa18e)
In the heart of the Viking era, nestled between rolling hills and dense forests, a small village stands as a testament to the ingenuity and resilience of its people. The architecture of the village, crafted in the traditional Viking style, is both simple and functional. Despite their fierce reputation as seafarers and warriors, the Vikings are portrayed here in their more peaceful moments.

### Crafting a Portal Space that Reflects Leonardo’s Vision

![image](https://github.com/user-attachments/assets/ebe704c6-1ec8-49e0-aff2-8f7ab367b4d2)

The portal is designed to evoke the feeling of stepping into Leonardo da Vinci's world. Using a clean, minimalist room layout, I assembled an environment inspired by the essence of his workshop. While I didn’t create the 3D models of his inventions, I added custom pedestals that highlight each piece. This arrangement invites visitors to fully engage with Leonardo’s mechanical concepts, from early prototypes of helicopters to innovative bicycle designs, all within a cohesive and focused space. Leonardo da Vinci was not just a famous artist; he was also a brilliant engineer. His collection of engineering designs showcases his fascination with flight and mechanics, making them perfect for educational purposes in a portal. A bust of Leonardo da Vinci is placed in the middle of the display to introduce the subject. The text pops up whenever you look at any object in the room, providing a good user experience and quick insights about the items.

Wings <br>
Leonardo's wing designs reflect his dream of human flight. He studied birds and imagined wings that could flap like theirs, showing his understanding of how to soar through the skies.

Flying Airplane <br>
One of his most daring ideas was a flying machine, similar to an airplane. This concept combined glider and helicopter elements, illustrating his creative vision of what flying could be long before it became reality.

Odometer <br>
The odometer is a clever invention that measured how far a vehicle traveled. It demonstrates Leonardo's practical side and his interest in helping people navigate better.

Bicycle <br>
Leonardo also sketched a bicycle, showing his forward-thinking approach to personal transportation. His design had two wheels and a frame that resembles modern bicycles, highlighting his innovative spirit.

![image](https://github.com/user-attachments/assets/aa507be3-119c-42af-8ec3-c0cca58b05bb)

Catapult <br>
His designs for catapults reveal his understanding of physics and mechanics. Leonardo created different types, each with unique ways to launch projectiles, showcasing his talent for improving existing technology.

Drum <br>
Leonardo da Vinci's sketches of drums show his appreciation for music. By exploring how instruments work, he combined art and engineering in a way that was truly inspiring.

### Assets sources

"VR Gallery" [link](https://skfb.ly/ooRLp) by Maxim Mavrichev is licensed under [Creative Commons Attribution](http://creativecommons.org/licenses/by/4.0/).

Music by [Mikhail Smusev](https://pixabay.com/users/sigmamusicart-36860929/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=256262) from [Pixabay](https://pixabay.com/music//?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=256262).

"Wings" [link](https://skfb.ly/6XRDM) by GmedranoTIC is licensed under [Creative Commons Attribution](http://creativecommons.org/licenses/by/4.0/).

"Leonardo Da Vinci - 3407 (Arte Italiano)" [link](https://skfb.ly/6vvpL) by Ministerio de Cultura Perú is licensed under [Creative Commons Attribution](http://creativecommons.org/licenses/by/4.0/).

"Da Vinci Flying Airplane" [link](https://skfb.ly/oJxp8) by Rukh3D is licensed under [Creative Commons Attribution](http://creativecommons.org/licenses/by/4.0/).

"Odometer" [link](https://skfb.ly/o7OX7) by GmedranoTIC is licensed under [Creative Commons Attribution](http://creativecommons.org/licenses/by/4.0/).

"Bicicle without turning" [link](https://skfb.ly/6YsMv) by GmedranoTIC is licensed under [Creative Commons Attribution](http://creativecommons.org/licenses/by/4.0/).

"Catapult" [link](https://skfb.ly/6YPCs) by GmedranoTIC is licensed under [Creative Commons Attribution](http://creativecommons.org/licenses/by/4.0/).

"Drum" [link](https://skfb.ly/6WWIJ) by GmedranoTIC is licensed under [Creative Commons Attribution](http://creativecommons.org/licenses/by/4.0/).
"Dinosaurs" https://assetstore.unity.com/publishers/37734
"Magic portals" https://assetstore.unity.com/packages/vfx/particles/spells/magic-effects-free-247933




