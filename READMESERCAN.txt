Video link:


Changelog:
- NEW STORE:
- The Upgrade store lets players increase various stats that affect income:


Post Button Upgrades - Add a float to a modifier that is multiplied by the base rate of the post button
i.e. 
Base Rate - 1; Post Button Modifier - 1; generate 1 view per click
Base Rate - 1; Post Button Modifier - 2; generate 2 views per click


View Rate Modifier - Add a float to the view rate modifier in ResourceManager to adjust how many views are received
i.e.
View Rate - 16; ViewModifier - 1.5; 24 views per second


Ad Rev Modifier code also exists but the rest of the ad rev system is not in place


All Upgrades use an UpgradeState to determine Locked, Available, and Purchased


- Upgrade Store data is saved in PlayerPrefs through DataManager
- Added UI elements to item shop to show cost of items
- New Buttons for upgrade shop (Basically the ItemButtons but without itemamount)