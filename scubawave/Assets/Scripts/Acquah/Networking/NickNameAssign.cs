using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
using Photon.Realtime;

public class NickNameAssign : MonoBehaviourPunCallbacks
{

    ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
    PhotonView PV;
    TMP_Text textInput;
    public GameObject leftArrow;
    public GameObject rightArrow;
    public GameObject playerAvatar;
    public Texture[] avatars;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponentInParent<PhotonView>();
        textInput = GetComponentInChildren<TMP_Text>();
        player = PhotonNetwork.LocalPlayer;
        UpdatePlayerItem(player);

        if (PV.IsMine)
        {
            textInput.text = PhotonNetwork.NickName;
            leftArrow.SetActive(true);
            rightArrow.SetActive(true);
        }
        else
        {
            textInput.text = PV.Owner.NickName;
        }

        
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickLeftArrow()
    {
        if((int)playerProperties["playerAvatar"] == 0)
        {
            playerProperties["playerAvatar"] = avatars.Length - 1;
        }
        else
        {
            playerProperties["playerAvatar"] = (int)playerProperties["playerAvatar"] - 1;
        }
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }

    public void OnClickRightArrow()
    {
        if ((int)playerProperties["playerAvatar"] == avatars.Length -1)
        {
            playerProperties["playerAvatar"] = 0;
        }
        else
        {
            playerProperties["playerAvatar"] = (int)playerProperties["playerAvatar"] + 1;
        }
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if(PV.IsMine && PhotonNetwork.LocalPlayer == targetPlayer)
        {
            UpdatePlayerItem(targetPlayer);
        }
        else if (!PV.IsMine && PhotonNetwork.LocalPlayer != targetPlayer)
        {
            UpdatePlayerItem(targetPlayer);
        }
    }

    void UpdatePlayerItem(Player player)
    {
        if (player.CustomProperties.ContainsKey("playerAvatar"))
        {
            playerAvatar.GetComponent<Renderer>().material.SetTexture("_MainTex", avatars[(int)player.CustomProperties["playerAvatar"]]);
            playerProperties["playerAvatar"] = (int)player.CustomProperties["playerAvatar"];
        }
        else
        {
            playerProperties["playerAvatar"] = 0;
        }
    }

    [PunRPC]
    public void SyncSkinPun()
    {

    }
}
