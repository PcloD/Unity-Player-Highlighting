# Unity-Player-Highlighting
A player interaction system for Unity, done in the style of Thief/Thief 2.

# How it works
The system is trigger based. When the player enter the trigger area, the direction they are looking in is tracked.
If they happen to be looking at the object of interest, this is highlighted to indicate that it can be used.
Each class should be derived from PlayerInteraction; the actual functionality is defined inside the Interact method
of the subclass.

# How to use it
Using the ReadItem class as an example, create a trigger collider in the scene. Attach the ReadItem class to your sign/book in the world, 
and make it a child of the trigger. Then select the GameObject that holds the UI for your book or sign.

# Known Issues
Unity doesn't include the "EMISSION" shader in a build, unless an object in the scene is explicitly referencing that shader.
So, add a cube whose material includes emission to the scene, and it should be all right.

This was developed using Unity 5.3.2. There is absolutely no reason why it shouldn't work with anything earlier, but I am assuming
that you are using Unity 4.6 or later.

# Licence
Released under the MIT Licence.
