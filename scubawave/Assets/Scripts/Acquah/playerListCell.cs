using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerListCell : MonoBehaviour
{
    public GameObject playerPanel;
    // Start is called before the first frame update
    void Start()
    {
        playerPanel = GameObject.FindWithTag("PlayerPanel");
        this.transform.SetParent(playerPanel.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
