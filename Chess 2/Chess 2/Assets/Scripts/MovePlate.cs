using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    public GameObject controller;

    GameObject refrence = null;

    int matrixX;
    int matrixY;

    public bool attack = false;

    public Sprite attackSprite;
    public void Start()
    {
        if (attack)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
            gameObject.GetComponent<SpriteRenderer>().sprite = attackSprite;
        }
    }

    public void OnMouseDown()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        if (attack)
        {
            GameObject chessPiece = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);

            if (chessPiece.name == "white_king" || chessPiece.name == "white_queen" || chessPiece.name == "bananaless_white_king") controller.GetComponent<Game>().majorWhitePiecesTaken++;

                if(chessPiece.GetComponent<Chessman>().player == "white")
                {
                    controller.GetComponent<Game>().whitePieceTakenLastTurn = true;
                }

            if (chessPiece.name == "black_king" || chessPiece.name == "black_queen" || chessPiece.name == "bananaless_black_king") controller.GetComponent<Game>().majorBlackPiecesTaken++;

                if (chessPiece.GetComponent<Chessman>().player == "black")
                {
                    controller.GetComponent<Game>().blackPieceTakenLastTurn = true;
                }
            Destroy(chessPiece);
        }

        controller.GetComponent<Game>().SetPositionEmpty(refrence.GetComponent<Chessman>().GetXBoard(), refrence.GetComponent<Chessman>().GetYBoard());

        refrence.GetComponent<Chessman>().SetXBoard(matrixX);
        refrence.GetComponent<Chessman>().SetYBoard(matrixY);

        if (matrixY == 7 && refrence.name == "white_fishie")
        {
            controller.GetComponent<Game>().Create("white_queenfishie", refrence.GetComponent<Chessman>().GetXBoard(), refrence.GetComponent<Chessman>().GetYBoard());
            Destroy(refrence);
        }
        if (matrixY == 0 && refrence.name == "black_fishie")
        {
            controller.GetComponent<Game>().Create("black_queenfishie", refrence.GetComponent<Chessman>().GetXBoard(), refrence.GetComponent<Chessman>().GetYBoard());
            Destroy(refrence);
        }

        refrence.GetComponent<Chessman>().SetCoords();

        controller.GetComponent<Game>().SetPosition(refrence);

        controller.GetComponent<Game>().NextTurn();

        refrence.GetComponent<Chessman>().DestroyMovePlates();
    }

    public void SetCoords(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }

    public void SetRefrence(GameObject obj)
    {
        refrence = obj;
    }

    public GameObject GetRefrence()
    {
        return refrence;
    }
}
