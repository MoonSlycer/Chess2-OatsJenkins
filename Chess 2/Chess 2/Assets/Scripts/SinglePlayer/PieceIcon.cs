using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceIcon : MonoBehaviour
{
    public GameObject camera;
    public Transform transform;

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
