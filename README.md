<h1><img width="42" height="42" alt="Sims 3 Modboard Logo" align="top" src="https://github.com/user-attachments/assets/945c92a4-2a98-420b-8966-8109b701fd96" /> Sims 3 Modboard <i>(s3mb)</i></h1>

Based on <em>Sims 3 Mod Organiser</em> and inspired by <em>CC Magic</em>, this app brings you a brand new *(-ish)* way to manage all of your Sims 3 mods, custom content and the game itself, safely and ultra-smoothly!

* By automatically merging your content from many small files into one file, and optionally decompressing it, <em>s3mb</em> can not only organise but also optimise your content so your game can run more smoothly.  
* Tags (like `Young Adult`, `Hairstyles` or `Script Mods`) and groups provide a simple way to both automatically and manually sort all your content.  
* You also conveniently get to view the thumbnails for all of your CC items, so you can easily get rid of that pesky CAS item you don't like anymore.
* An action centre is also available to give you some tips on how to optimise your game, quickly and simply.

# Features
## Implemented
* Windows, macOS and Linux support
* Support for the EA App, Steam and retail version
* Translatability into any language possible
* Avalonia UI
* Dark mode
* Menu shells
* Automatic game path detection on Windows and macOS (kinda)

## Not implemented
<sup>(Includes features that likely won't be implemented, but they may be one day)</sup>
* Functionality for implemented menus
* Viewing mods in a tree view
* Reimplement merging of packages
* Reimplement in-depth conflict detection
* Reimplement `Resource.cfg` writing (in a smarter way? so users don't lose existing configs?)
* Profile management
* Better group management
* Logging
* Optimise conflict detection so the builder doesn't have to fully re-run every time
* Automatically detecting changes to settings and packages
* Decompressing or compressing packages
* Thumbnail viewing
* `.sims3pack` and `.package` file associations
* Package installing into a group
* S3PE, S3OC connections
* Thumbnail viewing
* CAS part and object metadata viewing
  * Metadata tweaking (e.g. disabling for random)
  * Polycount analysis and tagging
* Automatic game path detection on Linux and better detection on macOS
* Detect game version
  * Recommend updates for non-latest versions (inc. `1.67.43` → `1.67.47`)
    * Auto-link all necessary Super-Patchers based on version code
* Detect and recommend ASM mods
  * Recommend switching from Smooth Patch to S3SS
    * Allow using Smooth Patch only for FPS-limiting or Borderless
  * UI configuration for known ASM mods
  * Detect lack of an ASI loader
* Shareable modpacks?
* Mod version detection
  * Core mod game version detection
    * Auto-fix core mod versions (any mods from `1.66-1.70` should automatically have their `GameVersion` changed)
* Mod (& CC) dependency checks
* Default replacement detection
* Auto-tagging of mods & CC
* EP/SP detection
* EP/SP enabling/disabling
* Bypassing launcher
  * Recommend LD's Origin launcher when possible (potentially possible to do without?)
  * Natively bypass pre-`1.69`
* Disable `objectCache` or strip it of mismatched/overridden resources
  * Must be restorable 
* Delete resources that match what the game will already load
* DRM detection
* Multiple instances (e.g. for Steam and EA App)
* Detect user folders in other languages
* Randomise loading screens from a folder
* Sync mods with cloud and/or another device/system/drive
* Crash log analysis
* Game runner shortcut to build mods, apply fixes, randomise screens and open game/launcher
* Sims 3 launcher-like theme
* Hour tracking, synced with Steam/EA/Playnite/GOG or a combination

# Credits
### Libraries used
[s3pi by pljones](https://sourceforge.net/u/pljones/profile)
### Originally developed by
[g0kur - Copyright © 2022](https://modthesims.info/m/10304845)
### Now developed by
[swiffy - Copyright © 2026](https://modthesims.info/m/10346421)
<details> <summary><b>Additional credits from g0kur for the original Sims 3 Mod Organizer</b></summary>

### Inspired by
[Mod Organizer by Tannin42](https://www.nexusmods.com/skyrim/mods/1334)  
[Mod Organizer 2 by the Mod Organizer Team](https://www.nexusmods.com/skyrimspecialedition/mods/6194)  
### Icons from
[icons8](https://icons8.com)
&ensp;
[RRZE](https://rrze-pp.github.io/rrze-icon-set/introduction.html)
### Libraries used
Numeric Comparer by Vasian Cepa  
[DDSImage from kprojects](https://code.google.com/archive/p/kprojects/)
</details>
