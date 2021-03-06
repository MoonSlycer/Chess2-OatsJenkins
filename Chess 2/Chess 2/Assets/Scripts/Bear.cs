using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    public GameObject controller;
    public GameObject movePlate;
    public GameObject gameObject;
    public void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
    }
    private void OnMouseUp()
    {
        if (!controller.GetComponent<Game>().IsGameOver())
        {
            GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
            for (int i = 0; i < movePlates.Length; i++)
            {
                Destroy(movePlates[i]);
            }
            PointMovePlate(3, 3);
            PointMovePlate(3, 4);
            PointMovePlate(4, 3);
            PointMovePlate(4, 4);
        }
    }

    public void PointMovePlate(int x, int y)
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
}
