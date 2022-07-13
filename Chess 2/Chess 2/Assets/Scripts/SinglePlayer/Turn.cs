using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn : MonoBehaviour
{
    public GameObject controller;

    public Sprite white, black;

    public Image image;

    public void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
    }
    public void Update()
    {
        if (controller.GetComponent<Game>().GetCurrentPlayer() == "black")
        {
            image.sprite = black;
        }
        if (controller.GetComponent<Game>().GetCurrentPlayer() == "white")
        {
            image.sprite = white;
        }
    }
}
