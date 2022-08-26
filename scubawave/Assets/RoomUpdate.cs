using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomUpdate : MonoBehaviour
{
    public float Timer = 0f;
    public float TimeBetweenUpdates = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        PhotonNetwork.CurrentRoom.IsVisible = true;
        if (Timer > TimeBetweenUpdates)
        {
            PhotonNetwork.CurrentRoom.IsVisible = false;
            Timer = 0;
        }
        
        
    }
}
