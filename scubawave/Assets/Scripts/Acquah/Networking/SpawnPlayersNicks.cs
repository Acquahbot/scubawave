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
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = PhotonNetwork.LocalPlayer;

        Vector3 position = new Vector3(0f, 0f, 0f);
        
        if(PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            PhotonNetwork.Instantiate(playerNickPrefab.name, player1.transform.position, player1.transform.rotation);
        }
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            PhotonNetwork.Instantiate(playerNickPrefab.name, player2.transform.position, player2.transform.rotation);
        }
        if (PhotonNetwork.CurrentRoom.PlayerCount == 3)
        {
            PhotonNetwork.Instantiate(playerNickPrefab.name, player3.transform.position, player3.transform.rotation);
        }
        if (PhotonNetwork.CurrentRoom.PlayerCount == 4)
        {
            PhotonNetwork.Instantiate(playerNickPrefab.name, player4.transform.position, player4.transform.rotation);
        }

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

    public void StartGame()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
