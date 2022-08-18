using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public static bool egyptMode = false;
    public GameObject secretButton;
    public GameObject indicator;

    public void Start()
    {
        secretButton.GetComponent<Toggle>().isOn = egyptMode;
        if (secretButton.GetComponent<Toggle>().isOn)
        {
            indicator.GetComponent<TMP_Text>().text = "Activated.";
        }
        if (!secretButton.GetComponent<Toggle>().isOn)
        {
            indicator.GetComponent<TMP_Text>().text = " ";
        }
    }
    public void SinglePlayer()
    {
        SceneManager.LoadScene("Singleplayer");
    }
    public void MultiPlayer()
    {
        SceneManager.LoadScene("WORK IN PROGRESS");
    }
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
    public void EgyptActivate()
    {
        egyptMode = secretButton.GetComponent<Toggle>().isOn;
        if (secretButton.GetComponent<Toggle>().isOn)
        {
            indicator.GetComponent<TMP_Text>().text = "Bird from Egypt activated.";
        }
        if (!secretButton.GetComponent<Toggle>().isOn)
        {
            indicator.GetComponent<TMP_Text>().text = " ";
        }
    }
}
