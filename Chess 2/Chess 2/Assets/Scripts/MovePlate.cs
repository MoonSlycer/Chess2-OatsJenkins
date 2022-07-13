using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
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
            GameObject chessPiece = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);

            if (chessPiece.name == "white_king(Clone)" || chessPiece.name == "white_queen(Clone)" || chessPiece.name == "bananaless_white_king(Clone)") controller.GetComponent<Game>().majorWhitePiecesTaken++;

            if (chessPiece.GetComponent<Chessman>().player == "white")
            {
                controller.GetComponent<Game>().whitePieceTakenLastTurn = true;
            }

            if (chessPiece.name == "black_king(Clone)" || chessPiece.name == "black_queen(Clone)" || chessPiece.name == "bananaless_black_king(Clone)") controller.GetComponent<Game>().majorBlackPiecesTaken++;

                if (chessPiece.GetComponent<Chessman>().player == "black")
                {
                    controller.GetComponent<Game>().blackPieceTakenLastTurn = true;
                }
            if (chessPiece.name == "white_king(Clone)")
            {
                CreateMarker("white_king", 5f, -.5f);
                controller.GetComponent<Game>().whiteSaveAllowed = true;
            }
            if (chessPiece.name == "black_king(Clone)")
            {
                CreateMarker("black_king", -5f, .5f);
                controller.GetComponent<Game>().blackSaveAllowed = true;
            }
            if (chessPiece.name == "white_queen(Clone)")
            {
                CreateMarker("white_queen", 5f, .5f);
            }
            if (chessPiece.name == "black_queen(Clone)")
            {
                CreateMarker("black_queen", -5f, -.5f);
            }
            if (chessPiece.name == "bananaless_white_king(Clone)")
            {
                CreateMarker("bananaless_white_king", 5f, -.5f);
                controller.GetComponent<Game>().whiteSaveAllowed = false;
            }
            if (chessPiece.name == "bananaless_black_king(Clone)")
            {
                CreateMarker("bananaless_black_king", -5f, .5f);
                controller.GetComponent<Game>().blackSaveAllowed = false;
            }
            PhotonNetwork.Destroy(chessPiece);
        }
        if (refrence.name == "StarterBear(Clone)")
        {
            controller.GetComponent<Game>().Create("gray_bear", matrixX, matrixY);
            PhotonNetwork.Destroy(refrence);
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

            if (matrixY == 7 && refrence.name == "white_fishie(Clone)")
            {
                controller.GetComponent<Game>().Create("white_queenfishie", refrence.GetComponent<Chessman>().GetXBoard(), refrence.GetComponent<Chessman>().GetYBoard());
                PhotonNetwork.Destroy(refrence);
            }
            if (matrixY == 0 && refrence.name == "black_fishie(Clone)")
            {
                controller.GetComponent<Game>().Create("black_queenfishie", refrence.GetComponent<Chessman>().GetXBoard(), refrence.GetComponent<Chessman>().GetYBoard());
                PhotonNetwork.Destroy(refrence);
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
