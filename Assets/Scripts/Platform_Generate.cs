using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;


public class Platform_Generate : NetworkBehaviour {
    public GameObject myplatform;
    static int n = 12;
    static List<Vector2> matrix = new List<Vector2>();
    static int maxplatform = 6;
    static int platforms = 0;
    int RandomSign() {
        return Random.value < .5 ? 1 : -1;
    }
    public override void OnStartServer() {
        if (isServer) {
            Debug.Log("Server Started");
            randomize();
        }
    }
    void randomize() {
        GameObject origi = GameObject.Find("Original Platform");
        platforms = 0;
        foreach (GameObject feri in GameObject.FindGameObjectsWithTag("Platform")) {
            GameObject.Destroy(feri);
        }
        matrix.Clear();
        Debug.Log("START RANDOMIZE");
        for (int i = 0; i < Random.Range(2, 4); i++) {
            matrix.Add(new Vector2(Random.Range(0, n), 0));
            platforms++;
        }
        foreach (Vector2 feri in matrix) {
            Debug.Log(feri);
        }
        for (int j = platforms; j < maxplatform; j++) {
            int myindex = Random.Range(0, matrix.Count);
            matrix.Add(new Vector2(matrix[myindex].x + RandomSign(), matrix[myindex].y + 1));
            Debug.Log(matrix.Count);
        }
        foreach (Vector2 feri in matrix) {
            GameObject pfrom = (GameObject)Instantiate(myplatform, new Vector2(origi.transform.position.x + feri.x * 3, origi.transform.position.y + feri.y * 3), Quaternion.identity);
            pfrom.transform.SetParent(this.transform);
            pfrom.tag = "Platform";
            NetworkServer.Spawn(pfrom);
            pfrom.name = "Platform_" + pfrom.GetComponent<NetworkIdentity>().netId as string;
        }

    }

}
