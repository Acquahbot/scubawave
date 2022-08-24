using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class NickNameAssign : MonoBehaviour
{
    PhotonView PV;
    TMP_Text textInput;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponentInParent<PhotonView>();
        textInput = GetComponent<TMP_Text>();

        if (PV.IsMine)
        {
            textInput.text = PhotonNetwork.NickName;
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
}
