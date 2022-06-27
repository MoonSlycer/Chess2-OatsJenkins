using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessman : MonoBehaviour
{
    public GameObject controller;
    public GameObject movePlate;

    private int xBoard = -1;
    private int yBoard = -1;

    private string player;

    public Sprite black_queen, black_monkey, black_elephant, black_king, bananaless_black_king, black_rook, black_fishie, black_queenfishie;
    public Sprite white_queen, white_monkey, white_elephant, white_king, bananaless_white_king, white_rook, white_fishie, white_queenfishie;

    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        SetCoords();

        switch (this.name)
        {
            case "black_queen": this.GetComponent <SpriteRenderer>().sprite = black_queen; break;
            case "black_monkey": this.GetComponent<SpriteRenderer>().sprite = black_monkey; break;
            case "black_elephant": this.GetComponent<SpriteRenderer>().sprite = black_elephant; break;
            case "black_king": this.GetComponent<SpriteRenderer>().sprite = black_king; break;
            case "bananaless_black_king": this.GetComponent<SpriteRenderer>().sprite = bananaless_black_king; break;
            case "black_rook": this.GetComponent<SpriteRenderer>().sprite = black_rook; break;
            case "black_fishie": this.GetComponent<SpriteRenderer>().sprite = black_fishie; break;
            case "black_queenfishie": this.GetComponent<SpriteRenderer>().sprite = black_queenfishie; break;

            case "white_queen": this.GetComponent<SpriteRenderer>().sprite = white_queen; break;
            case "white_monkey": this.GetComponent<SpriteRenderer>().sprite = white_monkey; break;
            case "white_elephant": this.GetComponent<SpriteRenderer>().sprite = white_elephant; break;
            case "white_king": this.GetComponent<SpriteRenderer>().sprite = white_king; break;
            case "bananaless_white_king": this.GetComponent<SpriteRenderer>().sprite = bananaless_white_king; break;
            case "white_rook": this.GetComponent<SpriteRenderer>().sprite = white_rook; break;
            case "white_fishie": this.GetComponent<SpriteRenderer>().sprite = white_fishie; break;
            case "white_queenfishie": this.GetComponent<SpriteRenderer>().sprite = white_queenfishie; break;
        }
    }

    public void SetCoords()
    {
        float x = xBoard;
        float y = yBoard;

        x *= 1f;
        y *= 1f;

        x += -3.5f;
        y += -3.5f;

        this.transform.position = new Vector3(x, y, 0f);
    }
    public int GetXBoard()
    {
        return xBoard;
    }
    public int GetYBoard()
    {
        return yBoard;
    }
    public void SetXBoard(int x)
    {
        xBoard = x;
    }

    public void SetYBoard(int y)
    {
        yBoard = y;
    }
}
