using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    public GameObject controller;
    public GameObject board;
    GameObject refrence = null;
    public GameObject majorPieceMarker;

    int matrixX;
    int matrixY;

    public bool attack = false;
    int noiseValue;

    public Sprite attackSprite;
    public Sprite white_king, black_king, white_queen, black_queen, bananaless_white_king, bananaless_black_king;

    public AudioClip dunk;
    public AudioClip donk;
    public AudioClip dink;
    public void Start()
    {
        if (attack)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
            gameObject.GetComponent<SpriteRenderer>().sprite = attackSprite;
        }
    }

    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        board = GameObject.FindGameObjectWithTag("Board");

        noiseValue = Random.Range(1, 4);

        if (noiseValue == 1) { board.GetComponent<AudioSource>().PlayOneShot(dunk, 1); }
        if (noiseValue == 2) { board.GetComponent<AudioSource>().PlayOneShot(donk, 1); }
        if (noiseValue == 3) { board.GetComponent<AudioSource>().PlayOneShot(dink, 1); }

        if (attack)
        {
            GameObject chessPiece = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);

            if (chessPiece.name == "white_king" || chessPiece.name == "white_queen" || chessPiece.name == "bananaless_white_king") controller.GetComponent<Game>().majorWhitePiecesTaken++;

            if (chessPiece.GetComponent<Chessman>().player == "white")
            {
                controller.GetComponent<Game>().whitePieceTakenLastTurn = true;
            }

            if (chessPiece.name == "black_king" || chessPiece.name == "black_queen" || chessPiece.name == "bananaless_black_king") controller.GetComponent<Game>().majorBlackPiecesTaken++;

                if (chessPiece.GetComponent<Chessman>().player == "black")
                {
                    controller.GetComponent<Game>().blackPieceTakenLastTurn = true;
                }
            if (chessPiece.name == "white_king")
            {
                CreateMarker("white_king", 5f, -.5f);
                controller.GetComponent<Game>().whiteSaveAllowed = true;
            }
            if (chessPiece.name == "black_king")
            {
                CreateMarker("black_king", -5f, .5f);
                controller.GetComponent<Game>().blackSaveAllowed = true;
            }
            if (chessPiece.name == "white_queen")
            {
                CreateMarker("white_queen", 5f, .5f);
            }
            if (chessPiece.name == "black_queen")
            {
                CreateMarker("black_queen", -5f, -.5f);
            }
            if (chessPiece.name == "bananaless_white_king")
            {
                CreateMarker("bananaless_white_king", 5f, -.5f);
                controller.GetComponent<Game>().whiteSaveAllowed = false;
            }
            if (chessPiece.name == "bananaless_black_king")
            {
                CreateMarker("bananaless_black_king", -5f, .5f);
                controller.GetComponent<Game>().blackSaveAllowed = false;
            }
            Destroy(chessPiece);
        }
        if (refrence.name == "StarterBear")
        {
            controller.GetComponent<Game>().Create("gray_bear", matrixX, matrixY);
            Destroy(refrence);
            controller.GetComponent<Game>().NextTurn();
            GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
            for (int i = 0; i < movePlates.Length; i++)
            {
                Destroy(movePlates[i]);
            }
        }
        else
        {
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
    public GameObject CreateMarker(string name, float x, float y)
    {
        GameObject obj = Instantiate(majorPieceMarker, new Vector3(x, y, -1), Quaternion.identity);
        obj.name = name;
            if (name == "white_king") obj.GetComponent<SpriteRenderer>().sprite = white_king;
            if (name == "black_king") obj.GetComponent<SpriteRenderer>().sprite = black_king;
            if (name == "white_queen") obj.GetComponent<SpriteRenderer>().sprite = white_queen;
            if (name == "black_queen") obj.GetComponent<SpriteRenderer>().sprite = black_queen;
            if (name == "bananaless_white_king") obj.GetComponent<SpriteRenderer>().sprite = bananaless_white_king;
            if (name == "bananaless_black_king") obj.GetComponent<SpriteRenderer>().sprite = bananaless_black_king;
        return obj;
    }
}
