using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Zinko_NetworkManager : NetworkManager {
        public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId) {
            GameObject player = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            player.GetComponent<SpriteRenderer>().color = new Color(Random.value,Random.value,Random.value,1);
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
}
