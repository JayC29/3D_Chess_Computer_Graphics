using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType
{
    None,
    Player1,
    Player2
}

public class Player
{
    //holds type of player (Player 1, Player 2, or None)
    public PlayerType playerType { get; private set; }

    //contains a list of chess piece objects that are still in play
    private List<GameObject> activeChessPieces = new List<GameObject>();

    //contains a list of chess piece objects that have been destroyed in game
    private List<GameObject> destroyedChessPieces = new List<GameObject>();

    //constructor
    public Player(PlayerType inputPlayerType)
    {
        playerType = inputPlayerType;
    }


    //getter and setters for attributes *incomplete*
    public List<GameObject> ActiveChessPieces 
    {
        get { return activeChessPieces; }
    }
}
