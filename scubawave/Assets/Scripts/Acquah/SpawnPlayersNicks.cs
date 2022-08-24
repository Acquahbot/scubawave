using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayersNicks : MonoBehaviour
{
    public GameObject playerNickPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = new Vector3(0f, 0f, 0f);
        PhotonNetwork.Instantiate(playerNickPrefab.name,position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
