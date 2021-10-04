***iths-gruppuppgift-210917***

```
                                            (                                     
                                            (                                     
                                            &&&&&&                                
                                            &.                                    
                                            &                   *               
                                            &                /****                
                                        ,*  &             /*******                
                                      ,   , &.         /***********               
                                   ..  .   *&,      /**************.              
                               *...  *,    .&,  /******/************              
                            /..... ,,,  ** .&#***********************             
                        , ......*,,,, ***. *&*************************            
                      .......,,,,,,,*****  ,&/(****************/*******           
                  .........*,,,,,,*******   &***************************/         
               /........*,,,,,,,*********   &*****************************        
            ........./,,,,,,,,***********   &******************************       
        /..........,,,,,,,,,*************.  &**/****************************      
  .......,(.... ,,,,,,,,,,****************  &********************************.    
            %&&/       ,******************  &**********************************   
                    *&&&&&&&.     ,       , &&@@&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&%/. 
                       &&&&&&&&&&&&&&&&&&&&&&&&&&&&@&&&&#     &&&&&&   &&&&&&&    
                       &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&& &    
                         &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&%%#(//*,..          
```					 

--------------------------------------------------------------------------------
***SUMMARY***
--------------------------------------------------------------------------------
*The Pirate Game* is a top down adventure game set in a tropical setting.

The gameplay loop consists of visiting islands and collecting items in a
set order. Once the player has collected all of the items from the islands,
the game ends.

There are a total of five islands, and the location of the islands on the map 
is randomly generated each play session. 


--------------------------------------------------------------------------------
***FEATURES***
--------------------------------------------------------------------------------

- An epic narrative about a pirate finding the path to righteousness.
- A procedurally generated world to explore.
- State of the art graphics, including high resolution character visuals in RGB
color, a detailed world map, and real time rendered animations. 

--------------------------------------------------------------------------------
***GAMEPLAY***
--------------------------------------------------------------------------------
The game world consists of Ocean tiles, represented by blue, and Island 
tiles, represented by green. The player pirate ship and crew, represented 
by a character on screen, moves around the tile based game world map using
the arrow keys.

Each Island has an item that is accessible once the player character has a 
specific key item in its inventory. 
When the player character enters an island tile, the game checks if the player 
has the necessary item required to access the item on the island. To get all 
of the items the player must visit all of the islands in the correct order.

Once the player has collected all of the items the game ends.

--------------------------------------------------------------------------------
***CONCEPT TO FINAL PRODUCT***
--------------------------------------------------------------------------------

![Concept](https://github.com/RasmusBroborg/iths-gruppuppgift-210917/blob/main/pics/Grupparbete_Concept.PNG)

In the initial concept, all tiles had characters assigned to them. This feature 
was cut in the final build as all of the characters cluttered up the map. Instead
of having characters in different colors, the game simply draws a background in
the color of the world tile.

![Early Build](https://github.com/RasmusBroborg/iths-gruppuppgift-210917/blob/main/pics/Grupparbete_EarlyBuild.PNG)

In an early build the player character was represented by a red 'P'. To
improve visibility the player model was later changed to a higher density pixel 
char and the color was changed to white. In this early build the game world size
had the same width as height.

![Late Game Build](https://github.com/RasmusBroborg/iths-gruppuppgift-210917/blob/main/pics/LateBuild.png)

One of the latest additions to the game was the implementation of island maps.

![Island view](https://github.com/RasmusBroborg/iths-gruppuppgift-210917/blob/main/pics/GameConcept.gif)

And lastly, below is a picture example of our codebase.

![Game Code Base](https://github.com/RasmusBroborg/iths-gruppuppgift-210917/blob/main/pics/PictureOfCodeBase.PNG)

--------------------------------------------------------------------------------
***CHALLENGES***
--------------------------------------------------------------------------------

- Lag
  - **Problem:** When drawing the game each turn, the screen flickers
  - **Solution:** Instead of clearing the screen using Console.Clear()
  we simply redrew over the old world, thus eliminating the flicker
  created by the clearing of the console.
  
- Player movement
  - **Problem:** In the inital build the game world consisted of cell classes
  containing both the underlying world type as well as the player character,
  creating all sorts of issues with the game logic due to unnessecary complexity.
  - **Solution:** In the final build the world and characters are separated,
  and simply share a connection through the use of an interface definining two
  properties: X-axis and Y-axis. 

- How to enter islands
  - **Problem:** When designing the game we had the ambition to have the ability
  to enter islands to get the items, but we were unsure as to how we would 
  implement the feature.
  - **Solution:** Mentioning the feature to Kim and leaving him alone for a 
  couple of hours.


--------------------------------------------------------------------------------
***CUT FEATURES***
--------------------------------------------------------------------------------

- Turn counter (Mutiny if player does not find beer within x amount of turns.)
- Patrolling enemies

--------------------------------------------------------------------------------
***DEVELOPMENT TEAM AND MEMORABLE QUOTES***
--------------------------------------------------------------------------------

- Setrag Godoshian *(QA Engineer)* 
> *"Jag får merge errors."*
- Sandra Eng *(Senior Designer)*
> *"Rasmus, har du raderat mina ändringar i Player.cs? Det var ju mitt område."*
- Kim Almroth *(Environment Architect)*
> *"Jag har redan fixat det."*
- Vincent Ikoro *(Quest & Dialogue Designer)*
> "*Man blir så svettig av pingis.*"
- Rasmus Broborg *(Art Director)*
> "*Är det lunch snart?*"
