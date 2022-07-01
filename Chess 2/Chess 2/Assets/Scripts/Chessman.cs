using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessman : MonoBehaviour
{
    public GameObject controller;
    public GameObject movePlate;

    private int xBoard = -1;
    private int yBoard = -1;

    public string player;

    public Sprite black_queen, black_monkey, black_elephant, black_king, bananaless_black_king, black_rook, black_fishie, black_queenfishie;
    public Sprite white_queen, white_monkey, white_elephant, white_king, bananaless_white_king, white_rook, white_fishie, white_queenfishie;
    public Sprite gray_bear;

    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        SetCoords();

        switch (this.name)
        {
            case "black_queen": this.GetComponent <SpriteRenderer>().sprite = black_queen; player = "black"; break;
            case "black_monkey": this.GetComponent<SpriteRenderer>().sprite = black_monkey; player = "black"; break;
            case "black_elephant": this.GetComponent<SpriteRenderer>().sprite = black_elephant; player = "black"; break;
            case "black_king": this.GetComponent<SpriteRenderer>().sprite = black_king; player = "black"; break;
            case "bananaless_black_king": this.GetComponent<SpriteRenderer>().sprite = bananaless_black_king; player = "black"; break;
            case "black_rook": this.GetComponent<SpriteRenderer>().sprite = black_rook; player = "black"; break;
            case "black_fishie": this.GetComponent<SpriteRenderer>().sprite = black_fishie; player = "black"; break;
            case "black_queenfishie": this.GetComponent<SpriteRenderer>().sprite = black_queenfishie; player = "black"; break;

            case "gray_bear": this.GetComponent<SpriteRenderer>().sprite = gray_bear; player = "gray"; break;

            case "white_queen": this.GetComponent<SpriteRenderer>().sprite = white_queen; player = "white"; break;
            case "white_monkey": this.GetComponent<SpriteRenderer>().sprite = white_monkey; player = "white"; break;
            case "white_elephant": this.GetComponent<SpriteRenderer>().sprite = white_elephant; player = "white"; break;
            case "white_king": this.GetComponent<SpriteRenderer>().sprite = white_king; player = "white"; break;
            case "bananaless_white_king": this.GetComponent<SpriteRenderer>().sprite = bananaless_white_king; player = "white"; break;
            case "white_rook": this.GetComponent<SpriteRenderer>().sprite = white_rook; player = "white"; break;
            case "white_fishie": this.GetComponent<SpriteRenderer>().sprite = white_fishie; player = "white"; break;
            case "white_queenfishie": this.GetComponent<SpriteRenderer>().sprite = white_queenfishie; player = "white"; break;
        }
    }

    public void SetCoords()
    {
        float x = xBoard;
        float y = yBoard;

        x *= 1f;
        y *= 1f;

        x += -3.5f;
        y += -3.5f;

        this.transform.position = new Vector3(x, y, 0f);
    }
    public int GetXBoard()
    {
        return xBoard;
    }
    public int GetYBoard()
    {
        return yBoard;
    }
    public void SetXBoard(int x)
    {
        xBoard = x;
    }

    public void SetYBoard(int y)
    {
        yBoard = y;
    }

    private void OnMouseDown()
    {
        if (!controller.GetComponent<Game>().IsGameOver() && controller.GetComponent<Game>().GetCurrentPlayer() == player)
        {
            DestroyMovePlates();

            InitiateMovePlates();
        }
        if (player == "gray")
        {
            DestroyMovePlates();

            InitiateMovePlates();
        }
    }

    public void DestroyMovePlates()
    {
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for (int i = 0; i < movePlates.Length; i++)
        {
            Destroy(movePlates[i]);
        }
    }

    public void InitiateMovePlates()
    {
        switch (this.name)
        {
            case "black_queen":
            case "white_queen":
            case "black_queenfishie":
            case "white_queenfishie":
                LineMovePlate(1, 0);
                LineMovePlate(0, 1);
                LineMovePlate(1, 1);
                LineMovePlate(-1, 0);
                LineMovePlate(0, -1);
                LineMovePlate(-1, -1);
                LineMovePlate(-1, 1);
                LineMovePlate(1, -1);
                break;

            case "black_elephant":
            case "white_elephant":
                PointMovePlate(xBoard + 2, yBoard + 2);
                PointMovePlate(xBoard - 2, yBoard - 2);
                PointMovePlate(xBoard + 2, yBoard - 2);
                PointMovePlate(xBoard - 2, yBoard + 2);
                break;
            case "white_rook":
                for (int i = 0; i < 8; i++)
                {
                    RookMovePlate(xBoard - i, yBoard + 0);
                    RookMovePlate(xBoard - i, yBoard + 1);
                    RookMovePlate(xBoard - i, yBoard + 2);
                    RookMovePlate(xBoard - i, yBoard + 3);
                    RookMovePlate(xBoard - i, yBoard + 4);
                    RookMovePlate(xBoard - i, yBoard + 5);
                    RookMovePlate(xBoard - i, yBoard + 6);
                    RookMovePlate(xBoard - i, yBoard + 7);
                }
                for (int i = 0; i < 8; i++)
                {
                    RookMovePlate(xBoard - i, yBoard - 1);
                    RookMovePlate(xBoard - i, yBoard - 2);
                    RookMovePlate(xBoard - i, yBoard - 3);
                    RookMovePlate(xBoard - i, yBoard - 4);
                    RookMovePlate(xBoard - i, yBoard - 5);
                    RookMovePlate(xBoard - i, yBoard - 6);
                    RookMovePlate(xBoard - i, yBoard - 7);
                }
                for (int i = 0; i < 8; i++)
                {
                    RookMovePlate(xBoard + i, yBoard + 0);
                    RookMovePlate(xBoard + i, yBoard + 1);
                    RookMovePlate(xBoard + i, yBoard + 2);
                    RookMovePlate(xBoard + i, yBoard + 3);
                    RookMovePlate(xBoard + i, yBoard + 4);
                    RookMovePlate(xBoard + i, yBoard + 5);
                    RookMovePlate(xBoard + i, yBoard + 6);
                    RookMovePlate(xBoard + i, yBoard + 7);
                }
                for (int i = 0; i < 8; i++)
                {
                    RookMovePlate(xBoard + i, yBoard - 1);
                    RookMovePlate(xBoard + i, yBoard - 2);
                    RookMovePlate(xBoard + i, yBoard - 3);
                    RookMovePlate(xBoard + i, yBoard - 4);
                    RookMovePlate(xBoard + i, yBoard - 5);
                    RookMovePlate(xBoard + i, yBoard - 6);
                    RookMovePlate(xBoard + i, yBoard - 7);
                }
                if (controller.GetComponent<Game>().whitePieceTakenLastTurn == true)
                {
                    RookAttackPlate(xBoard, yBoard + 1);
                    RookAttackPlate(xBoard, yBoard - 1);
                    RookAttackPlate(xBoard + 1, yBoard);
                    RookAttackPlate(xBoard - 1, yBoard);
                    RookAttackPlate(xBoard, yBoard + 1);
                    RookAttackPlate(xBoard, yBoard - 1);
                    RookAttackPlate(xBoard + 1, yBoard);
                    RookAttackPlate(xBoard - 1, yBoard);
                }
                break;
            case "black_rook":
                for (int i = 0; i < 8; i++)
                {
                    RookMovePlate(xBoard - i, yBoard + 0);
                    RookMovePlate(xBoard - i, yBoard + 1);
                    RookMovePlate(xBoard - i, yBoard + 2);
                    RookMovePlate(xBoard - i, yBoard + 3);
                    RookMovePlate(xBoard - i, yBoard + 4);
                    RookMovePlate(xBoard - i, yBoard + 5);
                    RookMovePlate(xBoard - i, yBoard + 6);
                    RookMovePlate(xBoard - i, yBoard + 7);
                }
                for (int i = 0; i < 8; i++)
                {
                    RookMovePlate(xBoard - i, yBoard - 1);
                    RookMovePlate(xBoard - i, yBoard - 2);
                    RookMovePlate(xBoard - i, yBoard - 3);
                    RookMovePlate(xBoard - i, yBoard - 4);
                    RookMovePlate(xBoard - i, yBoard - 5);
                    RookMovePlate(xBoard - i, yBoard - 6);
                    RookMovePlate(xBoard - i, yBoard - 7);
                }
                for (int i = 0; i < 8; i++)
                {
                    RookMovePlate(xBoard + i, yBoard + 0);
                    RookMovePlate(xBoard + i, yBoard + 1);
                    RookMovePlate(xBoard + i, yBoard + 2);
                    RookMovePlate(xBoard + i, yBoard + 3);
                    RookMovePlate(xBoard + i, yBoard + 4);
                    RookMovePlate(xBoard + i, yBoard + 5);
                    RookMovePlate(xBoard + i, yBoard + 6);
                    RookMovePlate(xBoard + i, yBoard + 7);
                }
                for (int i = 0; i < 8; i++)
                {
                    RookMovePlate(xBoard + i, yBoard - 1);
                    RookMovePlate(xBoard + i, yBoard - 2);
                    RookMovePlate(xBoard + i, yBoard - 3);
                    RookMovePlate(xBoard + i, yBoard - 4);
                    RookMovePlate(xBoard + i, yBoard - 5);
                    RookMovePlate(xBoard + i, yBoard - 6);
                    RookMovePlate(xBoard + i, yBoard - 7);
                }
                if (controller.GetComponent<Game>().blackPieceTakenLastTurn == true)
                {
                    RookAttackPlate(xBoard, yBoard + 1);
                    RookAttackPlate(xBoard, yBoard - 1);
                    RookAttackPlate(xBoard + 1, yBoard);
                    RookAttackPlate(xBoard - 1, yBoard);
                    RookAttackPlate(xBoard, yBoard + 1);
                    RookAttackPlate(xBoard, yBoard - 1);
                    RookAttackPlate(xBoard + 1, yBoard);
                    RookAttackPlate(xBoard - 1, yBoard);

                }
                break;

            case "black_king":
            case "white_king":
            case "bananaless_black_king":
            case "bananaless_white_king":
                SurrondMovePlate();
                break;

            case "white_fishie":
                FishieMovePlate(xBoard, yBoard + 1);
                FishieMovePlate(xBoard + 1, yBoard + 1);
                FishieMovePlate(xBoard - 1, yBoard + 1);
                FishieMovePlate(xBoard + 1, yBoard);
                FishieMovePlate(xBoard - 1, yBoard);
                break;
            case "black_fishie":
                FishieMovePlate(xBoard, yBoard - 1);
                FishieMovePlate(xBoard + 1, yBoard - 1);
                FishieMovePlate(xBoard - 1, yBoard - 1);
                FishieMovePlate(xBoard + 1, yBoard);
                FishieMovePlate(xBoard - 1, yBoard);
                break;

            case "black_monkey":
            case  "white_monkey":
                MonkeyMovePlate(xBoard, yBoard);
                OnlyMovePlate(xBoard, yBoard + 1);
                OnlyMovePlate(xBoard, yBoard - 1);
                OnlyMovePlate(xBoard + 1, yBoard);
                OnlyMovePlate(xBoard - 1, yBoard);
                OnlyMovePlate(xBoard - 1, yBoard + 1);
                OnlyMovePlate(xBoard - 1, yBoard - 1);
                OnlyMovePlate(xBoard + 1, yBoard - 1);
                OnlyMovePlate(xBoard + 1, yBoard + 1);
                break;

            case "gray_bear":
                OnlyMovePlate(xBoard, yBoard + 1);
                OnlyMovePlate(xBoard, yBoard - 1);
                OnlyMovePlate(xBoard + 1, yBoard);
                OnlyMovePlate(xBoard - 1, yBoard);
                OnlyMovePlate(xBoard - 1, yBoard + 1);
                OnlyMovePlate(xBoard - 1, yBoard - 1);
                OnlyMovePlate(xBoard + 1, yBoard - 1);
                OnlyMovePlate(xBoard + 1, yBoard + 1);
                break;
        }
    }

    public void LineMovePlate(int xIncrement, int yIncrement)
    {
        Game sc = controller.GetComponent<Game>();

        int x = xBoard + xIncrement;
        int y = yBoard + yIncrement;
        while(sc.PositionOnBoard(x,y) && sc.GetPosition(x,y) == null)
        {
            MovePlateSpawn(x, y);
            x += xIncrement;
            y += yIncrement;
        }

        if(sc.PositionOnBoard(x, y) && sc.GetPosition(x,y).GetComponent<Chessman>().player != player)
        {
            MovePlateAttackSpawn(x, y);
            MovePlateAttackSpawn(x, y);
        }
    }
    public void RookMovePlate(int x, int y)
    {
        Game sc = controller.GetComponent<Game>();
        if (sc.PositionOnBoard(x, y))
        {
            GameObject chessPiece = sc.GetPosition(x, y);

            if (chessPiece == null)
            {
                MovePlateSpawn(x, y);
            }
        }
    }
    public void RookAttackPlate(int x, int y)
    {
        Game sc = controller.GetComponent<Game>();
        if (sc.PositionOnBoard(x, y))
        {
            GameObject chessPiece = sc.GetPosition(x, y);

            if (chessPiece.GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x, y);
            }
        }
    }
    public void SurrondMovePlate()
    {
        PointMovePlate(xBoard, yBoard + 1);
        PointMovePlate(xBoard, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard);
        PointMovePlate(xBoard - 1, yBoard);
        PointMovePlate(xBoard - 1, yBoard + 1);
        PointMovePlate(xBoard - 1, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard + 1);
    }

    public void PointMovePlate(int x, int y)
    {
        Game sc = controller.GetComponent<Game>();
        if (sc.PositionOnBoard(x, y))
        {
            GameObject chessPiece = sc.GetPosition(x, y);

            if(chessPiece == null)
            {
                MovePlateSpawn(x, y);
            }
            else if (chessPiece.GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x, y);
            }
        }
    }

    public void FishieMovePlate(int x, int y)
    {
        Game sc = controller.GetComponent<Game>();
        if (sc.PositionOnBoard(x, y))
        {
            if (sc.GetPosition(x, y) == null)
            {
                MovePlateSpawn(x, y);
            }
            if (player == "white")
            {
                if (sc.PositionOnBoard(xBoard + 1, yBoard + 1) && sc.GetPosition(xBoard + 1, yBoard + 1) != null && sc.GetPosition(xBoard + 1, yBoard + 1).GetComponent<Chessman>().player != player)
                {
                    MovePlateAttackSpawn(xBoard + 1, yBoard + 1);
                }
                if (sc.PositionOnBoard(xBoard - 1, yBoard + 1) && sc.GetPosition(xBoard - 1, yBoard + 1) != null && sc.GetPosition(xBoard - 1, yBoard + 1).GetComponent<Chessman>().player != player)
                {
                    MovePlateAttackSpawn(xBoard - 1, yBoard + 1);
                }
            }
            if (player == "black")
            {
                if (sc.PositionOnBoard(xBoard + 1, yBoard - 1) && sc.GetPosition(xBoard + 1, yBoard - 1) != null && sc.GetPosition(xBoard + 1, yBoard - 1).GetComponent<Chessman>().player != player)
                {
                    MovePlateAttackSpawn(xBoard + 1, yBoard - 1);
                }
                if (sc.PositionOnBoard(xBoard - 1, yBoard - 1) && sc.GetPosition(xBoard - 1, yBoard - 1) != null && sc.GetPosition(xBoard - 1, yBoard - 1).GetComponent<Chessman>().player != player)
                {
                    MovePlateAttackSpawn(xBoard - 1, yBoard - 1);
                }
            }
        }
    }
    public void OnlyMovePlate(int x, int y)
    {
        Game sc = controller.GetComponent<Game>();
        if (sc.PositionOnBoard(x, y))
        {
            GameObject chessPiece = sc.GetPosition(x, y);

            if (chessPiece == null)
            {
                MovePlateSpawn(x, y);
            }
        }
    }
    public void MonkeyMovePlate(int x, int y)
    {
        Game sc = controller.GetComponent<Game>();
        if (sc.PositionOnBoard(x, y))
        {
            if (sc.PositionOnBoard(x + 1, y))
            {
                if (sc.GetPosition(x + 1, y) != null && sc.PositionOnBoard(x + 2, y))
                {
                    PointMovePlate(x + 2, y);
                }
            }
            if (sc.PositionOnBoard(x - 1, y))
            {
                if (sc.GetPosition(x - 1, y) != null && sc.PositionOnBoard(x - 2, y))
                {
                    PointMovePlate(x - 2, y);
                }
            }
            if (sc.PositionOnBoard(x, y + 1))
            {
                if (sc.GetPosition(x, y + 1) != null && sc.PositionOnBoard(x, y + 2))
                {
                    PointMovePlate(x, y + 2);
                }
            }
            if (sc.PositionOnBoard(x, y - 1))
            {
                if (sc.GetPosition(x, y - 1) != null && sc.PositionOnBoard(x, y - 2))
                {
                    PointMovePlate(x, y - 2);
                }
            }
            if (sc.PositionOnBoard(x + 1, y + 1))
            {
                if (sc.GetPosition(x + 1, y + 1) != null && sc.PositionOnBoard(x + 2, y + 2))
                {
                    PointMovePlate(x + 2, y + 2);
                }
            }
            if (sc.PositionOnBoard(x - 1, y + 1))
            {
                if (sc.GetPosition(x - 1, y + 1) != null && sc.PositionOnBoard(x - 2, y + 2))
                {
                    PointMovePlate(x - 2, y + 2);
                }
            }
            if (sc.PositionOnBoard(x - 1, y - 1))
            {
                if (sc.GetPosition(x - 1, y - 1) != null && sc.PositionOnBoard(x - 2, y - 2))
                {
                    PointMovePlate(x - 2, y - 2);
                }
            }
            if (sc.PositionOnBoard(x + 1, y - 1))
            {
                if (sc.GetPosition(x + 1, y - 1) != null && sc.PositionOnBoard(x + 2, y - 2))
                {
                    PointMovePlate(x + 2, y - 2);
                }
            }
        }
    }
    public void MovePlateSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 1f;
        y *= 1f;

        x += -3.5f;
        y += -3.5f;

        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -1f), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.SetRefrence(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }
    public void MovePlateAttackSpawn(int matrixX, int matrixY)
    {
        float x = matrixX;
        float y = matrixY;

        x *= 1f;
        y *= 1f;

        x += -3.5f;
        y += -3.5f;

        GameObject mp = Instantiate(movePlate, new Vector3(x, y, -1f), Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.attack = true;
        mpScript.SetRefrence(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }
}
