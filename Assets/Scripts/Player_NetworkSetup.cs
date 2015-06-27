using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
public class Player_NetworkSetup : NetworkBehaviour {
    // Use this for initialization
    public override void OnStartLocalPlayer() {
        GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().enabled = true;
    }
}
