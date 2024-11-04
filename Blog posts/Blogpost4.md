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

## App UI (Andrei) ##  

The UI of the application consists of 3 buttons that resemble 3 different historic places: Leonardo da Vinci's pieces of art, the Vikings era, and the Mesozoic era.

<br>![image](https://github.com/user-attachments/assets/a3565123-922b-4476-b8d3-ffc3f0af11b8)<br><br>

Upon pressing one of these 3 buttons, the specific era portal will appear. Only one portal can be placed at a time. Upon placing another portal, the old one will disappear.

## History locations environments (Andrei / Emanuel / Oriana) ##

### Mesozoic era (Andrei) ###

The Mesozoic era is known as the "Age of Reptiles" marking the existence of different types of dinosaurs. Especially for children, this topic is always an interesting one, and since it is hard to resemble how they exactly look or the color of their skin, the existence of them can not be denied. In this environment 3 dinosaur species were covered: Stegasaurus, Velociraptor, and Pachycephalasaurus, each of them having a description of the species that they belong to, upton tapping on them.

<br>![image](https://github.com/user-attachments/assets/0e3c576d-9e90-4285-85fd-7eda6e5443fb)<br><br>

### Vikings era (Emanuel) ###

### Leonardo da Vinci's pieces of art (Oriana) ###

## Clipping Issue ##    
