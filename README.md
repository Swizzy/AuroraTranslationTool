Aurora Translation Tool
-----------------------

=================
= What is this? =
=================

- This is a tool that will make it easier for you to translate the Aurora dashboard for Xbox 360
  - It makes it easier for you to translate Aurora by giving you a nice/easy to use interface which shows you only the parts you need to translate
  - It also allows you to compile the translation so that you can test it with Aurora to see that everything looks alright and that your translation is accurate

===================================
= What's needed to use this tool? =
===================================

- You'll need Microsoft .NET Framework 2.0 or later installed on your computer (most computers have this already)
- If you want to compile the skin/translation you'll need to have the XDK installed or you need these 3 files in the bin folder (taken from the XDK):
  * xuipkg.exe
  * resxloc.exe
  * resx2bin.exe
- In order to compile the skin/translation you also need the current skin for Aurora, when you press compile it'll ask you for it, if you press cancel it'll use "Skins\Default.xzp"
- You'll also of course need the translation files (en-US.xml from the aurora translation helper or whatever updated release Phoenix has made since)

===========
= Credits =
===========

- Swizzy - i'm the guy that made this for ya ;)
- Phoenix - These are the guys that made the Aurora Dashboard, without them this tool would never have existed ;)
- SpkLeader - Thanks for making "Aurora Translation Helper" which basically is the whole Compilitation part ;)
- Anyone else i failed to mention above for some reason, thanks!

=============
= Changelog =
=============
v1.1.8
- Fixed: The set all similar as finished function so it does what it's supposed to and doesn't just use the currently loaded translation
- Fixed: Pressing enter when in the search form now behaves the same as if you had pressed the OK button

v1.1.7
- Fixed: Sections are now listed properly and it shows you what section is currently active properly...
- Added: Search, you can now press Ctrl + F to search between the currently shown items in various ways...
- Added: You can now set all similar as finished

v1.0.6 (Update 5)
- Added: You can now save the path for the translation, this means that when you press the button to save the translation it'll automatically overwrite the file and not ask you where to save it...
- Added: With the above i also added so that when you compile it'll automatically use this file by default (if it exists and you've ticked the same box)
- Added: Section Filters, you can now filter out certain sections of the translations, by default it'll filter on "All", meaning all will be displayed... these filters are dynamically generated based on the names...

v1.0.5 (Update 4)
- Fixed encoding issue, i always thought it would be required to use Unicode, but UTF-8 works just as fine also... w00t? anyways, output is now saved in utf-8 directly... not unicode! :D

v1.0.4 (Update 3)
- Fixed: NewLine (\n) are now properly dealt with in all cases
- Added: When you are about to close it'll now check if there's some unsaved changes, if that's the case, it'll ask you if you are sure you want to exit without saving them...

v1.0.3 (Update 2)
- Added: Stats, you can now see how many lines you have loaded, translated and so on :)
- Fixed: Loading will no longer increase the entries (it now checks if it already exists at all times)
- Fixed: The save button is now enabled when you load entries that already contain something...
- Fixed: When doubleclicking the listview it'll no longer ask if you want to keep old data before loading new one when you accidently filled the translation line with something...
- Fixed: The save button is no longer enabled if you type in something in the translation box and there's no translation object loaded...

v1.0.2 (Update 1)
- Added: Hotkey/Keyboard shortcut: Ctrl + Shift + A -> This will let you translate ALL entries with the same original text with whatever you currently have in the translation box
- Added: Context Menu (Right click menu) for the Listview, it allows you to set an item as Finished and reset it
- Fixed: Loading a translation object no longer causes the save translation button to be disabled
- Fixed: When you save an item it'll now be set as finished no matter what it contains...
- Fixed: When you save a translation the button will be disabled, there's no changes to save again right now anyways!

v1.0.1 (Hotfix #1)
- Fixed crash while saving due to some strings not beeing translated before saving, my bad!

v1.0
- Initial release