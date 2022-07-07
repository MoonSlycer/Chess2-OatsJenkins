using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlate : MonoBehaviour
{
    public GameObject controller;
    public Transform transform;
    public GameObject board;

    public AudioClip dunk;
    public AudioClip donk;
    public AudioClip dink;

    int noiseValue;
    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        board = GameObject.FindGameObjectWithTag("Board");

        noiseValue = Random.Range(1, 4);

        if (noiseValue == 1) { board.GetComponent<AudioSource>().PlayOneShot(dunk, 1); }
        if (noiseValue == 2) { board.GetComponent<AudioSource>().PlayOneShot(donk, 1); }
        if (noiseValue == 3) { board.GetComponent<AudioSource>().PlayOneShot(dink, 1); }

        if (transform.position == new Vector3(-5.06f, 0.5f, transform.position.z))
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
