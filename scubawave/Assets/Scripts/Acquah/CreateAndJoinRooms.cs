using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public TMP_InputField createInput;
    public TMP_InputField joinInput;
    public TMP_InputField nameInput;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ChangeName()
    {
        PhotonNetwork.NickName = nameInput.text;
    }
    void Update()
    {
        
    }

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(createInput.text);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }


    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("GameLobby");
    }
}
