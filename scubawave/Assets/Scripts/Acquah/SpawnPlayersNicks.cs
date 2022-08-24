using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class SpawnPlayersNicks : MonoBehaviourPunCallbacks
{
    public GameObject playerNickPrefab;
    public GameObject startButton;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = PhotonNetwork.LocalPlayer;


        Vector3 position = new Vector3(0f, 0f, 0f);
        PhotonNetwork.Instantiate(playerNickPrefab.name,position, Quaternion.identity);

        if (PhotonNetwork.IsMasterClient)
        {
            startButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Main");
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if(player == otherPlayer)
        {
            Destroy(gameObject);
        }
        if (PhotonNetwork.IsMasterClient)
        {
            startButton.SetActive(true);
        }
    }
}
