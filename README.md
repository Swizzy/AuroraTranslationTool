Aurora Translation Tool
-----------------------

** NOTE: Using the compiler within this tool isn't working anylonger, for the new compiler see this project: https://github.com/XboxUnity/AuroraLanguagePackCompiler **

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

======================
= Keyboard shortcuts =
======================

Ctrl + S -> Saves the current line
Ctrl + F -> Brings up the search form (basically a custom filter really)
Ctrl + Shift + A -> It'll ask you if you want to set all similar items (same original string) to whatever you have in the translation box right now
Ctrl + Shift + S -> Save current translation
Ctrl + Shift + C -> Trigger compilation
Ctrl + Mousewheel -> Change the text size of the textboxes and listview

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
v2.0.17
 - Fixed: Previous fix only worked while in compiling mode... turns out, my tool is just as bad as microsofts tools! it missed out on anything that isn't 100% accurate >_< it now also corrects every other aspect of the tags aswell meaning: any case of <data name="..."><value>...</value></data> will now be lowercased properly... but this only occurs if you etheir load and save the translation or compile your translation...

v2.0.16
 - Fixed: If you for any reason decided to manually edit the data and you ended up with <data Name="..."><value>...</value></data> this will now be corrected for you during compilation to be the correct format: <data name="..."><value>...</value></data>
   It's a critical thing because microsoft's tools are case-sensitive, why? because they didn't think anyone would actually do manual edits to resx files...

v2.0.15
 - Updated: The tool now requires .NET Framework 3.5 due to using the built-in JSON serialization
 - Removed: The ability to compile Skins is no longer a part of this tool, instead it's now compiling "Language Packs"
 - Added: When you press Compile, it'll now open up a new form which have the details needed for a language pack

v1.1.14
- Fixed: Crash while searching with the search form if no original was loaded
- Fixed: You can now always search, if you have nothing listed you're automatically limited to only searching ALL items
- Fixed: You can now search with the "Equals" type aswell with when searching all items

v1.1.13
- Added: Filters for when you're asked for translation/skin, previously it caused confusion for some, now you don't even see the other type of file(s)
- Added: The app will no longer crash on error while compiling the translation, instead you'll be shown what the error was and it'll continue from there...
- Added: You can now do a full search or use the search function as previously (a custom filter on the currently visuable items) full search however ignores other types of filters atm... to tired to fix that...

v1.1.12
- Fixed: I forgot to add the Yes, No and Cancel buttons to the messagebox asking for Locale changing... my bad!

v1.1.11
- Added: It'll now ask you if you want to update the locale version upon save if they don't match
- Added: You can now select multipile items for reset/set finished/set similar finished, only the first one will be used to let you edit the translation tho...
- Added: You can now sort the listview items (first ascending, second descending) just click the column you want to sort on =)
- Added: You can now copy the name of the first selected item in the listview when you right click it...
- Added: Holding Ctrl while scrolling your mousewheel will now increase the textsize of both the textboxes and the listview...
- Added: Pressing Ctrl + Shift + S will now save the current translation
- Added: Pressing Ctrl + Shift + C will now trigger a compilation

v1.1.10
- Fixed: When you save a translation and have the "Hide Finished" filter disabled the entry will no longer be removed from the view
- Fixed: When you have the "Keep filename for last saved translation" checked and compile, it'll now save the path used during the compilation
- Fixed: When you uncheck the above checkbox it'll now clear the saved path, so you can select another file without reloading entirely

v1.1.9
- Fixed: When you reset/save/set finished any translation object it'll now remove it from the listview leaving you where you were in the lists...
- Fixed: Pressing "Clear All" now properly clears the sections aswell
- Fixed: When loading a original/translation the stats will now be updated properly

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
