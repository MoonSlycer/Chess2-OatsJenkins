using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    public GameObject controller;

    GameObject refrence = null;

    int matrixX;
    int matrixY;

    //false: movement, true: attacking
    public bool attack = false;

    public void Start()
    {
        if(attack)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0.1f);
        }
    }

    public void OnMouseDown()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        if (attack)
        {
            GameObject chessPiece = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);

            Destroy(chessPiece);
        }

        controller.GetComponent<Game>().SetPositionEmpty(refrence.GetComponent<Chessman>().GetXBoard(), refrence.GetComponent<Chessman>().GetYBoard());

        refrence.GetComponent<Chessman>().SetXBoard(matrixX);
        refrence.GetComponent<Chessman>().SetYBoard(matrixY);
        refrence.GetComponent<Chessman>().SetCoords();

        controller.GetComponent<Game>().SetPosition(refrence);

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
