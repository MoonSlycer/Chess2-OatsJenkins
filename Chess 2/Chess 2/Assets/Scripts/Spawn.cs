using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawn : MonoBehaviour
{
    void Start()
    {
        if (PhotonNetwork.IsMasterClient == true)
        {
            PhotonNetwork.InstantiateRoomObject("Controller", new Vector3(0, 0, -1), Quaternion.identity);
        }
    }
}
