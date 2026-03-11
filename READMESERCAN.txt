Video link:
https://youtu.be/kVUiTfW0E8E

If you are curious about the BigDouble variable here is the repository that I got the files for this type from:
https://github.com/Razenpok/BreakInfinity.cs

Changelog:
- Game can save and load data from previous play session
- Content Shop with appropriate UI:
	- Cats - Adds 1 view per second
	- Food - Adds 15 views per second
	- Memes - Adds 50 views per second
	- Video Games - 75 views per second
- Post Button that adds 1 view per click at the start of the game
- View counter at the top of the screen

Managers:

ResourceManager - Manages all resources in the game
DataManager - Reads and Writes to Player Prefs, parses out and receives data from all classes with ISaveable that subcribe to its saveableList
ShopManager - Holds ItemData for all content options: title, description, cost, amount, cost mult, amount they add to passive income, and a currently unused itemId
