// ************************************************************************ //
//  __                    __                        __                      //
// /\ \__  __            /\ \__                    /\ \__                   //
// \ \ ,_\/\_\    ___    \ \ ,_\    __      ___    \ \ ,_\   ___      __    //
//  \ \ \/\/\ \  /'___\   \ \ \/  /'__`\   /'___\   \ \ \/  / __`\  /'__`\  //
//   \ \ \_\ \ \/\ \__/    \ \ \_/\ \L\.\_/\ \__/    \ \ \_/\ \L\ \/\  __/  //
//    \ \__\\ \_\ \____\    \ \__\ \__/.\_\ \____\    \ \__\ \____/\ \____\ //
//     \/__/ \/_/\/____/     \/__/\/__/\/_/\/____/     \/__/\/___/  \/____/ //
// ************************************************************************ //
// Description : A small, console based tic tac toe game written in f#      //
// Author      : Joachim Tilsted Kristensen                                 //
// At          : Copenhagen University                                      //
// ************************************************************************ //

// we represent the board as an array of characters
type board = char[,]
type point = int * int

// returns a new 3x3 array, filled with '-' (reprecenting an unused field)
let newBoard() = Array2D.init 3 3 (fun _ _ -> '-')

// sets b[i,j] := c, where c is a characer
let set c (i, j) (b : board) = b.[i, j] <- c

// these functions returns lists, containing lines from the board
let row  (b : board) i = List.init 3 (fun j -> b.[i, j])
let col  (b : board) j = List.init 3 (fun i -> b.[i, j])
let dia1 (b : board)   = List.init 3 (fun i -> b.[i  , i])
let dia2 (b : board)   = List.init 3 (fun i -> b.[2-i, i])

// usefull functions for reasoning about the playing board
let all x = List.forall (fun y -> x = y)
let exi x = List.exists (fun y -> x = y)

// This function returns all relevent lines from the playing board.
let getLists (b : board) =
  List.map (row b) [0..2] @ List.map (col b) [0..2] @ [dia1 b; dia2 b]

// If all of the characters in a line are exactly "c",
// the player reprecented this paticular character has won the game
let gameover (b : board) c = List.exists (fun l -> all c l) (getLists b)

// The board is blocked, if there are no empty field available
let blocked  (b : board) = not (List.exists (fun l -> exi '-' l) (getLists b))

// A player is reprecented by a name, and a symbol ('x' or 'o').
// Futhermore, a player has a playturn method, which can be applied to the board
type player(name : string, symbol : char) =
  member this.name           = name
  member this.symbol         = symbol
  member this.playturn board =
    // TODO : handle all sorts of bad input
    // ALSO : handle if the user tries to set a vacated field.
    let s    = (System.Console.ReadLine()).Split [|','|]
    let pInt = System.Int32.Parse
    let p    = (pInt s.[0], pInt s.[1]) : point
    set this.symbol p board

// A game, consists of two players and a board.
// When the "run" method is called, the players take turns playing tic tac toe
type game (p0 : string, p1 : string, b : board) =
  do printf "New game started {%s ('x')} vs. {%s ('o')}\n" p0 p1
  member this.player0     = player(p0, 'x')
  member this.player1     = player(p1, 'o')
  member this.board       = b
  member this.getPlayer i = (if i = 0 then this.player0 else this.player1)
  member this.run () =
    let mutable turn       = 0
    let mutable game_ended = false
    while not (blocked this.board) && (not (game_ended)) do
      let player = this.getPlayer (turn)
      printf "It's %s's turn ! - select a field :\n" player.name
      player.playturn this.board
      printf "%A\n" this.board
      if gameover this.board player.symbol
      then printf "%s won the game -" player.name; game_ended <- true
      else ()
      turn <- 1 - turn
    printf "The game has ended !\n"

// this is what happens when the ".exe" file is run
[<EntryPoint>]
let main args =
  if Array.length args = 2
  then ()
  else
    printfn "The number of arguments you provided, were diffrent than 2"
    printfn "Here are your passed arguments : %A" args
    exit -1
  try
    game(args.[0], args.[1], newBoard()).run()
  with
    | _ -> printfn "The game crashed [-_-]!"; exit -2
  0 // return 0 on success

// _______________________________________________________________________
// Here are some Excercise that you could do:
// _______________________________________________________________________
// Excercise 0.0 : Read Through the code carefully !
// Excercise 0.1 : what kind of types are "player" and "game" ?
// _______________________________________________________________________
// Excercise 1.0 : handle all sorts of bad input in the player.playturn method
// Excercise 1.1 : write multiple tests,
//                 showing which cornercases you covered in Excercise 1.
// _______________________________________________________________________
// Excercise 2.0 : write a new player class ai_player,
//                 (where the playturn method is handled automatically).
// Excercise 2.1 : rewrite the game class, so that it can use the ai_player.
// _______________________________________________________________________
// Bonus         : write a function which prints the board more nicely.
// _______________________________________________________________________
// Extra Bonus   : play the game with a friend. Can you break it ?
//                 also, see if they can beat the ai {^o^}
// _______________________________________________________________________
