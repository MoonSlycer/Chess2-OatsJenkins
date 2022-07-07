using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlate : MonoBehaviour
{
    public GameObject controller;
    public Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        if(transform.position == new Vector3(-5.06f, 0.5f, transform.position.z))
        {
            Destroy(GameObject.Find("black_king"));
            controller.GetComponent<Game>().blackSaveAllowed = false;
            controller.GetComponent<Game>().Create("bananaless_black_king", 1, 4);
            controller.GetComponent<Game>().majorBlackPiecesTaken--;
        }
        if(transform.position == new Vector3(5.09f, -0.5f, transform.position.z))
        {
            Destroy(GameObject.Find("white_king"));
            controller.GetComponent<Game>().whiteSaveAllowed = false;
            controller.GetComponent<Game>().Create("bananaless_white_king", 6, 3);
            controller.GetComponent<Game>().majorWhitePiecesTaken--;
        }

        controller.GetComponent<Game>().NextTurn();
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for (int i = 0; i < movePlates.Length; i++)
        {
            Destroy(movePlates[i]);
        }
    }
}
