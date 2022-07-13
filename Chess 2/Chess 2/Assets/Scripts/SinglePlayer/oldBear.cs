using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oldBear : MonoBehaviour
{
    public GameObject controller;
    public GameObject movePlate;
    public GameObject camera;
    public Transform transform;
    private void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        if (!controller.GetComponent<oldGame>().IsGameOver())
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
        oldGame sc = controller.GetComponent<oldGame>();
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

        oldMovePlate mpScript = mp.GetComponent<oldMovePlate>();
        mpScript.SetRefrence(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }
    public void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        transform = GetComponent<Transform>();
    }
    public void Update()
    {
        transform.localRotation = camera.transform.localRotation;
    }
}
