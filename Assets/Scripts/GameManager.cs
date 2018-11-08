using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager instance;

    //chessPiecePrefabs
    //[0] = Pawn
    //[1] = Rook
    //[2] = Knight
    //[3] = Bishop
    //[4] = Queen
    //[5] = King

    [SerializeField]
    private GameObject[] chessPiecePrefabs;
    [SerializeField]
    private Material[] player1Mat;
    [SerializeField]
    private Material[] player2Mat;

    //construct player 1 and player 2 objects
    private Player player1 = new Player(PlayerType.Player1);
    private Player player2 = new Player(PlayerType.Player2);

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        SpawnChessPieces();
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void SpawnChessPieces()
    {
        //keeps track of number of each piece for naming purposes. ie: "white pawn1", "black pawn1", etc...
        int whitePieceNumber = 0, darkPieceNumber = 0;

        //spawn Pawns for both players
        for (int i = 0; i < 8; i++)
        {
            SpawnChessPiece(chessPiecePrefabs[0], coordinatesTo3D(i,1), player1, ++whitePieceNumber);
            SpawnChessPiece(chessPiecePrefabs[0], coordinatesTo3D(i, 6), player2, ++darkPieceNumber);   
        }

        //spawn Rooks for both players
        whitePieceNumber = 0; darkPieceNumber = 0;
        SpawnChessPiece(chessPiecePrefabs[1], coordinatesTo3D(0, 0), player1, ++whitePieceNumber);
        SpawnChessPiece(chessPiecePrefabs[1], coordinatesTo3D(7, 0), player1, ++whitePieceNumber);

        SpawnChessPiece(chessPiecePrefabs[1], coordinatesTo3D(0, 7), player2, ++darkPieceNumber);
        SpawnChessPiece(chessPiecePrefabs[1], coordinatesTo3D(7, 7), player2, ++darkPieceNumber);

        //spawn Knights for both players
        whitePieceNumber = 0; darkPieceNumber = 0;
        SpawnChessPiece(chessPiecePrefabs[2], coordinatesTo3D(1, 0), player1, ++whitePieceNumber);
        SpawnChessPiece(chessPiecePrefabs[2], coordinatesTo3D(6, 0), player1, ++whitePieceNumber);

        SpawnChessPiece(chessPiecePrefabs[2], coordinatesTo3D(1, 7), player2, ++darkPieceNumber);
        SpawnChessPiece(chessPiecePrefabs[2], coordinatesTo3D(6, 7), player2, ++darkPieceNumber);

        //spawn Bishop for both players
        whitePieceNumber = 0; darkPieceNumber = 0;
        SpawnChessPiece(chessPiecePrefabs[3], coordinatesTo3D(2, 0), player1, ++whitePieceNumber);
        SpawnChessPiece(chessPiecePrefabs[3], coordinatesTo3D(5, 0), player1, ++whitePieceNumber);

        SpawnChessPiece(chessPiecePrefabs[3], coordinatesTo3D(2, 7), player2, ++darkPieceNumber);
        SpawnChessPiece(chessPiecePrefabs[3], coordinatesTo3D(5, 7), player2, ++darkPieceNumber);

        //spawn Queen for both players
        whitePieceNumber = 0; darkPieceNumber = 0;
        SpawnChessPiece(chessPiecePrefabs[4], coordinatesTo3D(3, 0), player1, ++whitePieceNumber);

        SpawnChessPiece(chessPiecePrefabs[4], coordinatesTo3D(3, 7), player2, ++darkPieceNumber);

        //spawn King for both players
        whitePieceNumber = 0; darkPieceNumber = 0;
        SpawnChessPiece(chessPiecePrefabs[5], coordinatesTo3D(4, 0), player1, ++whitePieceNumber);

        SpawnChessPiece(chessPiecePrefabs[5], coordinatesTo3D(4, 7), player2, ++darkPieceNumber);
    }


    //spawns individual chess piece
    private void SpawnChessPiece(GameObject piece, Vector3 coordinate, Player player, int pieceNumber)
    {
        GameObject newPiece = Instantiate(piece, coordinate, Quaternion.identity);
        //transform.rotation* Quaternion.Euler(0f, 180f, 0f)
        //if player 1 create a chess piece for them else do it for player 2
        if ((int)player.playerType == 1)
        {
            newPiece.name = "White " + piece.name + pieceNumber;
            newPiece.GetComponent<ChessPiece>().PlayerType = player1.playerType;
            addMaterial(newPiece, player.playerType);

        }
        else if((int)player.playerType == 2)
        {
            newPiece.transform.Rotate(0f, 180f, 0f);
            newPiece.name = "Black " + piece.name + pieceNumber;
            newPiece.GetComponent<ChessPiece>().PlayerType = player2.playerType;
            addMaterial(newPiece, player.playerType);
        }
        else
        {
            Debug.Log("Player type contains 'None' as player in SpawnChessPiece function");
        }
        
        player.ActiveChessPieces.Add(newPiece);
    }

    //add the material to the default model piece giving it the white and dark look for each side
    private void addMaterial(GameObject defaultChessPiece, PlayerType colorDecider)
    {
        PieceType typeOfChessPiece = defaultChessPiece.GetComponent<ChessPiece>().PieceType;


        if ((int)colorDecider == (int)player1.playerType)
        {
            switch (typeOfChessPiece)
            {
                case PieceType.Pawn:
                    defaultChessPiece.GetComponent<Renderer>().material = player1Mat[0];
                    break;
                case PieceType.Rook:
                    defaultChessPiece.GetComponent<Renderer>().material = player1Mat[1];
                    break;
                case PieceType.Knight:
                    defaultChessPiece.GetComponent<Renderer>().material = player1Mat[2];
                    break;
                case PieceType.Bishop:
                    defaultChessPiece.GetComponent<Renderer>().material = player1Mat[3];
                    break;
                case PieceType.Queen:
                    defaultChessPiece.GetComponent<Renderer>().material = player1Mat[4];
                    break;
                case PieceType.King:
                    defaultChessPiece.GetComponent<Renderer>().material = player1Mat[5];
                    break;
                default:
                    Debug.Log("Unable to identify piece type for player1 in addMaterial function");
                    break;
            }
        }
        else
        {
            switch (typeOfChessPiece)
            {
                case PieceType.Pawn:
                    defaultChessPiece.GetComponent<Renderer>().material = player2Mat[0];
                    break;
                case PieceType.Rook:
                    defaultChessPiece.GetComponent<Renderer>().material = player2Mat[1];
                    break;
                case PieceType.Knight:
                    defaultChessPiece.GetComponent<Renderer>().material = player2Mat[2];
                    break;
                case PieceType.Bishop:
                    defaultChessPiece.GetComponent<Renderer>().material = player2Mat[3];
                    break;
                case PieceType.Queen:
                    defaultChessPiece.GetComponent<Renderer>().material = player2Mat[4];
                    break;
                case PieceType.King:
                    defaultChessPiece.GetComponent<Renderer>().material = player2Mat[5];
                    break;
                default:
                    Debug.Log("Unable to identify piece type for player2 in addMaterial function");
                    break;
            }
        }

        
    }


    private Vector3 coordinatesTo3D(int x, int z)
    {
        return new Vector3(x, 0, z);
    }
}
