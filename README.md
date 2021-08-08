# InventorySample
This is a game-ready inventory system for Unity 2D project.

How to use:
To create a new item, choose an item -> kind of item you want to add in assets create menu.
To create a new item kind, write a class inhertited from Item class and choose an asset menu for it.
To change the cell capacity, rewrite static field MaxCount in Cell class.

How to test with TestScene:
Add items you want to test to Player / RandomInventoryTest component "Items" list. 
Start the game. 
Press "Add item" button. 
Press "Reload UI" button to see the changes in inventory window.
