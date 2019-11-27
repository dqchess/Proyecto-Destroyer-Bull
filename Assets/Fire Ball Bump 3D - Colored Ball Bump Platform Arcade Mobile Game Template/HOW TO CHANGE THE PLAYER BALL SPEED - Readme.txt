------------------------------------------------------------------------------
HOW TO CHANGE THE SPEED OF THE PLAYER BALL WHEN IDLE (NORMAL MOVEMENT FORWARD)
------------------------------------------------------------------------------

There are two speeds for the player ball. These are the one that you can swipe/mouse click with your finger to slide the 
player ball sideways and up and down and the auto movement speed that the player ball will move when it's idle and the 
player is not touching it.

If you wish to change the speed when the player ball is moving forward normally when the player is not touching it then
you need to set the 'Auto Movement Speed' of both the player ball and the Main Camera.

You can do this by going in the player ball prefab 'Player Ball Controller (Main Player & Game Settings)' and there you 
should see the 'Auto Movement Speed' field which is in the BallControll.cs script. Change that to your needs and the 
higher you make it the faster the player ball will go. Now you need to also change the 'Auto Movement Speed' of the 
Main Camera so it can keep up with the player ball. Go in the Main Camera 'Main Camera (Auto Movement)' and there you
should see the 'Auto Movement Speed' field which is in the CameraMovement.cs script. Remember, if you changed the 
''Auto Movement Speed' of the player ball to 5 for example then you need to change the 'Auto Movement Speed' of the 
Main Camera to 5 too.

-----------------------------------------------------------------------------------------
HOW TO CHANGE THE SPEED OF THE PLAYER BALL WHEN TOUCHING/MOUSE CLICK SIDEWAYS AND UPWARDS.
-----------------------------------------------------------------------------------------

If you wish to change the speed of the player ball when you touch your finger or with mouse button to just move it
forward and sideways then you can change the Player Ball's Thrust Speed and/or the Rigibody of the player ball.

You can do this by going in the player ball prefab 'Player Ball Controller (Main Player & Game Settings)' and there you 
should see the 'Thrust Speed' field which is in the BallControll.cs script. You can change it to your needs there and this
will make the player ball goes faster/slower depending on the amount you made it.

If you are still not satisfied you can play around with the player ball Rigidbody's Mass, Drag And Angular Drag to make it to
your needs. Just remember the lower the Mass on the Rigidbody the faster it will go but don't make the mass too low, otherwise 
you won't be able to move the shapes!