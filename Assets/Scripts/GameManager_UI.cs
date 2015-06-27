using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GameManager_UI : MonoBehaviour {
    private Text hpText;
    private Text portalText;

    void InitializeVariables() {
        hpText = GameObject.Find("").GetComponent<Text>();
        portalText = GameObject.Find("").GetComponent<Text>();

    }
    void Start() {

    }
    void Update() {

    }
}
