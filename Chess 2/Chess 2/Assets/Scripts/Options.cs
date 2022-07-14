using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public static bool staticToggleBoardAnim = true;
    public static float staticVolume = 0.5f;

    public GameObject toggleBoardAnim;
    public GameObject volume;
    public void Start()
    {
        toggleBoardAnim.GetComponent<Toggle>().isOn = staticToggleBoardAnim;
        volume.GetComponent<Slider>().value = staticVolume * 10;
    }
    public void SetBoardAnim()
    {
        staticToggleBoardAnim = toggleBoardAnim.GetComponent<Toggle>().isOn;
    }
    public void SetVolume()
    {
        staticVolume = volume.GetComponent<Slider>().value / 10;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
