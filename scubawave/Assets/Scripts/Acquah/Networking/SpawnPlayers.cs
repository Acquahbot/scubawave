using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayers : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), 2, Random.Range(minZ, maxZ));
        GameObject playerToSpawn = playerPrefabs[((int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"])];
        PhotonNetwork.Instantiate(playerToSpawn.name, randomPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
