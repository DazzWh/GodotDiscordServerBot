# Godot Discord Bot

Discord bot that handles some specific "needs" of the [Godot Discord Server](https://discord.gg/4JBkykG).

Originally by [Calinou](https://github.com/Calinou/datcord_bot), moved to a more compartmentalized structure to start adding more complex features in the future.

### Todo: 

#### For V1:
+ [ ] Complete parity with previous version (minus role management)
+ [ ] Class names bikeshedded into making sense
+ [ ] Modules content split into readable structure
+ [ ] Memes implementation discussed 
    - [ ] Do we need memes?
    - [ ] Do we need to store images in the repo?
+ [ ] Discord token optionally read from a file in the executed folder, not from environment variable
+ [ ] Publish instructions written, or cross platform build settings saved in repo

---

#### Features until parity with previous:

##### Simple return texts 
+ [x] !code
+ [x] !ask
+ [x] !consoles
+ [x] !lang
+ [x] !tut
+ [x] !step
+ [x] !pronounce
+ [x] !patterns
+ [x] !nightly
+ [x] !mirror
+ [x] !bcg
+ [x] !heart
+ [x] !kcc
+ [x] !gdquest
+ [x] !game
+ [x] !csharp
+ [x] !api

###### BotCommandChannelOnly
+ [ ] bobross ross br
+ [x] meme

###### Slightly more complicated return texts
+ [x] class

###### Will do differently
+ [ ] !commands

Shows a list of commands, will use annotations to generate this instead of a static string
    
###### ~~Role management~~
 Not handling Role Management, will be done by YAGPDB.
+ [ ] ~~set~~
+ [ ] ~~role~~
+ [ ] ~~remove~~
+ [ ] ~~assign~~
+ [ ] ~~unassign~~