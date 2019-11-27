--------------------------
HOW TO CREATE A GAME EASY!
--------------------------

This packages comes with all ready to use prefabs, so you can just drag and drop and only have to 
worry about creating the levels with the obstacles. All you have to do once you finish setting up 
which will be in a few minutes is just worry where you are going to place the obstacles, that is it.


Step 1: Create a new scene, delete the main camera and go to the folder where everything is located, 
the prefab folder. Go in the Prefabs > Settings and drag and drop the Main Camera (Auto Movement) 
into the scene. 

Step 2: In the same folder Prefabs > Settings drag and drop the Background Music and Directional Light. 
These are not really important, but needed for the scene.The background music is mostly always needed 
in the scene and be sure it’s tagged with BackgroundMusic tag.


Step 3: Now the Main Camera is already set with the ‘top down view’ and everything that you need with all 
features ready. Go in the Prefabs > Main Grounds folder and drag and drop one of your choice. Place it in 
the scene. Now this will be your ground that your player and obstacles will be able to move on.

Step 4: Go to the Prefabs > Players folder and drag and drop the player ball into your scene. If you play 
your scene, you can see it’s already almost done. You can edit some settings for both the Main Camera and 
Player Ball in the inspector. If you followed everything correctly, then you should have something like this.

Step 5: Go to the Prefabs > Obstacles folder and you can now drag and drop any obstacles you want into the scene. 
Place some obstacles of your choice you have both normal and kill player ready-to-use obstacles, if not then you 
can also create your own easy.

Step 6: I am sure you are already done by now, all is needed to to just add a win game trigger so you can win the 
game when you are done. Once you put all the obstacles and such then you want to win the game after the player finished 
all the obstacles and so on. Go in the Prefabs > Settings folder and drag and drop the ‘Finish Line (Win Game Trigger)’ 
into the scene when you want the game to be one when the player reaches it. Everything should be done, test out your scene 
and just add some miscs such as the ‘starting line’ or not, it just makes it look cooler.


REQUIRED PREFABS THAT YOU SHOULD HAVE IN YOUR GAME:

- Main Camera (Auto Movement)
- Player Ball Controller (Main Player & Game Settings) 
- Background Music 
- Directional Light 
- Main Ground 1 (Platform)
- Finish Line (Win Game Trigger)
- Obstacles and such (can be different)


--------------------------
HOW TO CREATE A OBSTACLE!
--------------------------

Creating an obstacle is very easy and nothing is really required.

NORMAL OBSTACLE:

If you wish to create a new normal obstacle then all you need to do is create a new obstacle – 
add a Rigidbody 3D and a Collider 3D and place it into the scene.

KILL PLAYER OBSTACLE:

If you wish to create a new kill player obstacle then all you need to do is create a new obstacle – 
add a Rigidbody 3D and a Collider 3D and tag it with the ‘KillPlayer’ tag and that’s it. Place it 
into the scene.

Be sure to color the obstacles that will Kill the Player and the ones that won’t. 