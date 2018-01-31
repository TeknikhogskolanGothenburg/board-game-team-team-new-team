# Architecture
## The Game's Build
>
>The Game starts in the StartPage Controller where a user can select how many players will be in the game,
>
>their choice of color, their name,and as an option their email. 
>
>Once the Enter button is clicked, the player data is saved in a GamePlayer class within the Game model and a player specific cookie is created.
>
>The Index View displays our html and css. The html parses through all the players' data on every refresh and populates the board accordingly (based on the positions of the players pieces). 
>
>The StartGame View is a reference point for a button(Start Game) in out html file, to randomly select a player so thatit is their turn, afterwards it redirects to the Index Controller automatically updating the page.
>
>The RollDice View is also a reference point for a button(Roll Dice!) that assigns a new value to the static Dice variable within the Game Model. Based on the different conditions it will allow a player to move a piece and then update the board, by redirecting to the Index Controller, showing the new dice roll.
>
>We have 4 MovePiece Views that are, once again, reference points for buttons for each individual piece. They check the values of the Players to detemine who's turn it is based on the turn counter, their color, and their cookie's value.
>
>Based on the values present, it will move a players piece, allow for a dice re-roll if a 6 was previously rolled, and allow a player's piece to attack another piece. This Controller looks into 2 different methods from the GamePiece class to determine if those moves are possible, the AttackPiece() and the MovePiece(). 
>
>It also checks the WinCondition() and the NextTurn() from the GamePlayer Class.
>
>The EndTurn View is a reference point for a button to end a players turn (incase they cannot move).
>
>The WinPage View displays a page if there is a winner in the game and displays their name. Otherwise it redirects to the startpage unless their are players existing in the game.
>
>The NewGame View is a reference for a button that exists in Index and in the WinPage. It resets all the static variables to their original values and redirects the players to the StartPage to start anew.

## Which components does your application consist of?
1 Controller
11 Views
* StartPage: Allows for user input and creates GamePlayers accordingly.
* Index: Displays Game Board.
* StartGame: Checks players verses the # of players chosen for the game; if condition is met starts the game.
* RollDice: calls RollDice(). Also turns the respectives Player's CanMove boolean to true if conditions are met.
* MovePiece1: Moves the respective players 1st piece.
* MovePiece2: Moves the respective players 2nd piece.
* MovePiece3: Moves the respective players 3rd piece.
* MovePiece4: Moves the respective players 4th piece.
* EndTurn: Ends user turn.
* WinPage: displays winner, can redirect to StartPage on button press
* NewGame: resets all static values and redirects to StartPage
>
>
3 Classes
* GamePlayer:holds all player information, checks if can roll,move, or if has turn, 4 different GamePieces, 3 methods: one for turn, one for win condition, and one for sending emails.
* GamePiece:a boolean to see if piece is in play, an int for position on gameboard, and 2 methods for moving and attacking a piece.
* GameDice: holds a random value from 1-6 and reassigns that value everytime the RollDice() is called
>
>
1 Model
* List Gameplayer: A list of all players in the current game.
* GameDice: holds the values of the dice class as a model for html use.
* buttonPressed bool: a boolean for html use to hide or display the start game button(onced pressed it is hidden)





