using System.Collections;
using UnityEngine;

public enum PieceType
{
    None,
    Pawn, 
    Rook, 
    Knight, 
    Bishop,
    Queen,
    King
}

public class ChessPiece : MonoBehaviour
{
    //stores type of chess piece. ie: (pawn, rook, etc..)
    [SerializeField]
    private PieceType pieceType;

    //stores player which piece belongs to. ie:(player1 or player2)
    [SerializeField]
    private PlayerType playerType;

    //stores the type of movement possible by piece
    [SerializeField]
    private MovementType movementType;
    

    //TODO CREATE AN OBJECT TO STORE CURRENT LOCATION OF CHESS PIECE
    private int Column{set;get;}
    private int Row{set;get;}


    //getter and setters for attributes *incomplete*
    public PieceType PieceType
    {
        get { return pieceType; }
    }

    public PlayerType PlayerType
    {
        get { return playerType; }
        set { playerType = value; }
    }
}
