/* Game Ideas
 * mutliple gamemodes
 * "shooter" esc game
 * super smash bros related
 * guns do knockback
 * basic movement
 * crouching??
 * sliding??
 * mantling??
 * climbing??
 * gliders??
 * multiplayer?? (probably not but a man can dream)
 * background music


Menu screen stuff
    Play
        Gamemode Selection
        Map Selection

    Settings
        FOV Slider
        Camera Sensitivity
        Crossplay bool (if we ever get around to multiplayer)
        Rebind keys??
        Toggle Music
            (if checked yes) - Volume Slider
        Global Volume

    Credits
        
        @reallyz1ncx on YouTube

        Michael - Project Director
        Michael - Lead Developer
        z1ncx - Lead Developer
        z1ncx - 3D Modeler
        z1ncx - Music Developer
        z1ncx - Map Designer
        z1ncx - Menu Designer
        


To do
    * [ ] Add nerf blasters
    * [ ] Add enemies
    *   [ ] Add enemy movement
    * [ ] Add player
    * [d] Add movement
    * [d] Add camera moving
    * [ ] Add crouching
    * [ ] Add ammo/reloading
    * [ ] Weapon switching
    * [ ] Add character models (smth to do on my time)
    * [p] Add separate menus
    * [x] Change movement to addForce
            (ended up ditching this and doing transform.translate)
    * [ ] Connect the pause buttons to scene switching, and connect the main buttons to game playing
    * [p] Connect weapon to the player + rotation

Key: 
D = Done 
P = In progress
X = Decided against it

 Notes:
    1. Naming variables well is good, avoid making it too perfect to avoid confusion between your variable, and unity/wtv engine you use
    2. data types must be named EXACTLY with CORRECT capitalization. ex: GameObject =/ gameobject
    3. ! is the NOT operator, also can be used for toggle  ex: cameraIsLockedOn = !cameraIsLockedOn;
    4. any data type that has an undeclared value is ALWAYS null (boneworks reference??)
    5. you dont need to say public or private when declaring a data type UNLESS, you are outside of a method but inside the class.
    6. variables are lowercase, functions are capitalized
        -primative datatypes are lowercase such as: int, float, string, float, bool, double, byte, char, uint, etc.
    7. class names are capitals such as: GameObject, Vector3, Quaternian, Rigidbody
    8. Instatiate has multiple ways to utilize/call/invoke it - Object(what is being instantiated) Vector3(position), Quaternion(rotation) Transform(parent of the object)
    9. (nameof does not work if the method you are calling isnt in the same script, it has to be "(methodname)"
    10. in order to SET a rotation, it would be:
            transform.eulerAngles = new Vector3(the rotation)
        but to add it would be:
            transform.Rotate(the rotation)
    11. When affecting the transform of another object without making a new script, make a public GameObject, then put the name of that GameObject before transform
            public GameObject exGameObj
            exGameObject.transform.rotate(#, #, #)
                (you can ALSO use this to change the details of any component, not just transform by using GetComponent)
 
 
 
 
 */