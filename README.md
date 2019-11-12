# AzerTexPok
Azerion Texas Poker

# Assignment
Create a Texas Hold’em poker hands validation rule engine in c# using unity3D 2018.4 LTS or
higher (No beta or alpha)

You will be creating a rule engine that can determine the rank of a poker hand. This rule engine
needs to be able to accept an input of multiple hands and output a list that ranks the hands.
The user needs to be able to select the hands he wants to compare with each other and visually
show the outcome of how they would end up against each other.

Attached to this document is a zip file that contains all the cards required to play Texas Hold’em
poker. The cards are required to be used but the rest of the UI will only be reviewed on some
usability.

The application’s target audience is going to use this on a mobile android phone, you will
deliver a unity project git repository with a final APK build in this. The project should be easy to
review, build, run and validate for another developer. You need to take into consideration that
this project needs to be maintained for the next 5 years and will be updated every 4 weeks.

Resources:
Texas Hold’em rules: https://www.cardplayer.com/rules-of-poker/how-to-play-poker/games/texas-holdem
Poker card graphics: https://cdn-files-live.gop3.nl/resources_unitytest/poker_cards.rar

You are free to give your interpretation of any of the aspects that are not explicitly detailed
above. These assumptions shall be detailed together with the implementation.



# Documentation


Usage:

- Button Draw Board will draw 3 cards and then 2 more consecutive
- Button Draw Player Cards will draw 2 cards for each 4 players and will show a button to check any combination
- Button check will present the combination possible with the cards on the board and the ones in the hand selected and it will give a 	strentgh based on the power of the pokerhand.


Code Structure:


- Scriptable Objects
	- Created SO for each card (Based on ScriptableObjectFactory.cs using Editor option created with ScriptableObjectWindow)

	- Created system to build a SO inside Unity Editor (it can be done automatically if the assets are tagged/named with a normalized format)
	- In this case I received the assets as card_suit0_value00, etc... 

	- One can always create a script to read these files and based on its name, parse it and create automatically each Scriptable Object for each card on the set.
	- In this case I made it manually since the amount of cards is not going to change( as opposed to a Collectible Card Game for example). If the art would change, it's just a matter of rewriting such script to allow updating the sprite on each SO.

- There are several lists of Gameobjects and Cards to mantain the state of each player and the board of the game
- There're several placeholders objects used as positional  places


Things to improve:

- Add Unit Tests
- Add automatic way of creating Scriptable Objects for the cards
- Add Asset Bundles for example, in order to update content
- Add better UI art
- Iterate over UI layout to improve it



