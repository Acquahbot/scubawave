using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{

    public static CreateAndJoinRooms Instance;
    // Start is called before the first frame update
    public TMP_InputField createInput;
    public TMP_InputField joinInput;
    public TMP_InputField nameInput;
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void ChangeName()
    {
        PhotonNetwork.NickName = nameInput.text;
    }
    void Update()
    {
        
    }
    public void JoinRoom2(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
    }

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        roomOptions.BroadcastPropsChangeToAll = true;
        PhotonNetwork.CreateRoom(createInput.text, roomOptions);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }


    public override void OnJoinedRoom()
    {
        
        PhotonNetwork.LoadLevel("GameLobby");
    }
    public void OnJoinClick()
    {
        SceneManager.LoadScene("ServerBrowser");
    }
}
