using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player_UI : NetworkBehaviour {
    private Text hpText;
    private Text portalText;

    void InitializeVariables() {
        hpText = GameObject.Find("").GetComponent<Text>();
        portalText = GameObject.Find("").GetComponent<Text>();

    }
    void Start () {
	
	}
	void Update () {
	
	}
}
