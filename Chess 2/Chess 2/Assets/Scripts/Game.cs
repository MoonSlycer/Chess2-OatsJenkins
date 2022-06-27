using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject chesspiece;

    private GameObject[,] positions = new GameObject[8, 8];
    private GameObject[] playerBlack = new GameObject[16];
    private GameObject[] playerWhite = new GameObject[16];

    private string currentPlayer = "black";

    private bool gameOver = false;

    void Start()
    {
        playerBlack = new GameObject[]
        {
            Create("black_rook",0,0), Create("black_monkey",1,0),
            Create("black_fishie",2,0), Create("black_queen",3,0),
            Create("black_king",4,0), Create("black_fishie",5,0),
            Create("black_monkey",6,0), Create("black_rook",7,0),

            Create("black_fishie",0,1), Create("black_fishie",1,1),
            Create("black_elephant",2,1), Create("black_fishie",3,1),
            Create("black_fishie",4,1), Create("black_elephant",5,1),
            Create("black_fishie",6,1), Create("black_fishie",7,1),

        };

        playerWhite = new GameObject[]
        {
            Create("white_rook",0,7), Create("white_monkey",1,7),
            Create("white_fishie",2,7), Create("white_queen",3,7),
            Create("white_king",4,7), Create("white_fishie",5,7),
            Create("white_monkey",6,7), Create("white_rook",7,7),

            Create("white_fishie",0,6), Create("white_fishie",1,6),
            Create("white_elephant",2,6), Create("white_fishie",3,6),
            Create("white_fishie",4,6), Create("white_elephant",5,6),
            Create("white_fishie",6,6), Create("white_fishie",7,6),
        };

        for (int i = 0; i < playerBlack.Length; i++)
        {
            SetPosition(playerBlack[i]);
            SetPosition(playerWhite[i]);
        }
    }
    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(chesspiece, new Vector3(0, 0, -1), Quaternion.identity);
        Chessman chessman = obj.GetComponent<Chessman>();
        chessman.name = name;
        chessman.SetXBoard(x);
        chessman.SetYBoard(y);
        chessman.Activate();
        return obj;
    }

    public void SetPosition(GameObject obj)
    {
        Chessman chessman = obj.GetComponent<Chessman>();

        positions[chessman.GetXBoard(), chessman.GetYBoard()] = obj;
    }
    public void SetPositionEmpty(int x, int y)
    {
        positions[x, y] = null;
    }
    public GameObject GetPosition(int x, int y)
    {
        return positions[x, y];
    }

    public bool PositionOnBoard(int x, int y)
    {
        if (x < 0 || y < 0 || x >= positions.GetLength(0) || y >= positions.GetLength(1))
        {
            return false;
        }
        return true;
    }
}
