# uCUPG

uCUPG (unity CUstom Physics & Gravity) is an open-source custom gravity script for Unity.

# Modes
uCUPG has 3 different modes:

1) Standard gravity
Standard mode is the exact same as the Unity-s default gravity. 
It just accelerates the object down (or in any direction) at any speed. Just like IRL.

2) Faux gravity
Faux gravity can be used for planets, moons and other objects that orbit one point but use their own rotation.

3) Faux gravity with rotation
Same as the previous one, but with added rotation. 
Perfect for player character and other objects that walk on a planet.

# Scripts

- cupgManager
CupgManager is a script that has all the information for the cupgBodies.
Add this script to your Game Manager object and set up your gravity!

- cupgBody
This script sits on the objects that you want to have gravity on.
They use CupgManagers variables for gravity.

- cupgAttractor
CUpgAttractor pulls CupgBodies towards it.
This can be used to make entire solar systems, 2 walkable planets with a portal on each, gravity trap projectiles and much much more.
