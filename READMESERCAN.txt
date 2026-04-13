Video link:
https://youtu.be/vLLHRuYk63M

Changelog:
Changed how certain data in the game is saved.

PostButton now has its:

buttonAdd and buttonMod amounts stored in an XML file in the Player_Data directory

Any other game data is placed in a GameData class that is converted to Json and stored in a Json file in the Player_Data directory


- Post Button does not use the ISaveable interface, and is now referenced in the Data Manager to make it easier to retrieve and overwrite it's values in xml file