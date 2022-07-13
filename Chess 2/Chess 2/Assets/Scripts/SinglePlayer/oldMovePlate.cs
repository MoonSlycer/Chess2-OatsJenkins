using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class oldMovePlate : MonoBehaviour
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
        controller = GameObject.FindGameObjectWithTag("GameController");
        board = GameObject.FindGameObjectWithTag("Board");
        if (attack)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
            gameObject.GetComponent<SpriteRenderer>().sprite = attackSprite;
        }
    }

    public void OnMouseUp()
    {
        noiseValue = Random.Range(1, 4);

        if (noiseValue == 1) { board.GetComponent<AudioSource>().PlayOneShot(dunk, 1); }
        if (noiseValue == 2) { board.GetComponent<AudioSource>().PlayOneShot(donk, 1); }
        if (noiseValue == 3) { board.GetComponent<AudioSource>().PlayOneShot(dink, 1); }

        if (attack)
        {
            GameObject chessPiece = controller.GetComponent<oldGame>().GetPosition(matrixX, matrixY);

            if (chessPiece.name == "white_king" || chessPiece.name == "white_queen" || chessPiece.name == "bananaless_white_king") controller.GetComponent<oldGame>().majorWhitePiecesTaken++;

            if (chessPiece.GetComponent<oldChessman>().player == "white")
            {
                controller.GetComponent<oldGame>().whitePieceTakenLastTurn = true;
            }

            if (chessPiece.name == "black_king" || chessPiece.name == "black_queen" || chessPiece.name == "bananaless_black_king") controller.GetComponent<oldGame>().majorBlackPiecesTaken++;

            if (chessPiece.GetComponent<oldChessman>().player == "black")
            {
                controller.GetComponent<oldGame>().blackPieceTakenLastTurn = true;
            }
            if (chessPiece.name == "white_king")
            {
                CreateMarker("white_king", 5f, -.5f);
                controller.GetComponent<oldGame>().whiteSaveAllowed = true;
            }
            if (chessPiece.name == "black_king")
            {
                CreateMarker("black_king", -5f, .5f);
                controller.GetComponent<oldGame>().blackSaveAllowed = true;
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
                controller.GetComponent<oldGame>().whiteSaveAllowed = false;
            }
            if (chessPiece.name == "bananaless_black_king")
            {
                CreateMarker("bananaless_black_king", -5f, .5f);
                controller.GetComponent<oldGame>().blackSaveAllowed = false;
            }
             Destroy(chessPiece);
        }
        if (refrence.name == "oldStarterBear(Clone)")
        {
            controller.GetComponent<oldGame>().Create("gray_bear", matrixX, matrixY);
             Destroy(refrence);
            controller.GetComponent<oldGame>().NextTurn();
            GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
            for (int i = 0; i < movePlates.Length; i++)
            {
                Destroy(movePlates[i]);
            }
        }
        else
        {
            controller.GetComponent<oldGame>().SetPositionEmpty(refrence.GetComponent<oldChessman>().GetXBoard(), refrence.GetComponent<oldChessman>().GetYBoard());

            refrence.GetComponent<oldChessman>().SetXBoard(matrixX);
            refrence.GetComponent<oldChessman>().SetYBoard(matrixY);

            if (matrixY == 7 && refrence.name == "white_fishie")
            {
                controller.GetComponent<oldGame>().Create("white_queenfishie", refrence.GetComponent<oldChessman>().GetXBoard(), refrence.GetComponent<oldChessman>().GetYBoard());
                 Destroy(refrence);
            }
            if (matrixY == 0 && refrence.name == "black_fishie")
            {
                controller.GetComponent<oldGame>().Create("black_queenfishie", refrence.GetComponent<oldChessman>().GetXBoard(), refrence.GetComponent<oldChessman>().GetYBoard());
                 Destroy(refrence);
            }

            refrence.GetComponent<oldChessman>().SetCoords();

            controller.GetComponent<oldGame>().SetPosition(refrence);

            controller.GetComponent<oldGame>().NextTurn();

            refrence.GetComponent<oldChessman>().DestroyMovePlates();
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
