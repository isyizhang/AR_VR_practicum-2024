# AR_VR_practicum
An AR interface that can recognize and track the 3D structure of the OptiDot system and subsequently overlay important information onto the system that will aid learning and understanding of the basic dot product concepts.

## Requirements
Unity 2021.1.16f1

Put [Vuforia Engine package](https://rochester.box.com/s/3nlf5zjp0new8tiamf9sz2dsetijvg0x) (10.18.4) under the "Packages/" folder

## Game logic and AR features
- Narrative introduction 
    
    - A welcome message shows up as the player opens the app.
    - The player can tap on the start button to start the game 
  
    ![Narrative introduction](/Images/intro1.png)

- Game interface
  - A dialog box at the top-left corner guides the player through the game
  - A contine button at the bottom-right corner
  - An AR representation of OptiDot will show up as the player points the camera towards the physical model
    - Three flash lights, with buttons on them to turn on/off the lights
    - Two sets of polarizing films, each representing a 3-dimentinoal vector, with numbers on them indicating the values of the three components. 
    - A convex lens to converge the light beams and perform dot product

  ![Game interface](/Images/game_interface1.png)

- User interaction
   - **Changing the value of each vector**: After pushing the button shown above each polarizing film, a slider will show up at the top-right corner. The player can change its value by dragging the knob. The number on the polarizing film will change accordingly.
    
        ![sliders](/Images/sliders.gif)
        ![sliders](/Images/sliders2.gif)

    - **Turning on/off the flashlights**: The player can turn on/off the flashlights by pushing the buttons attached to them. The light beams will be shown/hidden accordingly. The number on the screen, which represents the intensity of the light, will also change in real time.
    
        ![lights](/Images/lightbeams.gif)

    - **Changing the viewing angle**: As the player moves the camera around the physical model, the AR interface will still be properly aligned with the model. The buttons will always face the camera, making it easier for the player to interact with them.
    
        ![rotation](/Images/sideview.gif)