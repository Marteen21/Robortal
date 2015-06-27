using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Platformscript : MonoBehaviour {
    public GameObject myplatform;
    static int n = 12;
    static List<Vector2> matrix = new List<Vector2>();
    static int maxplatform = 6;
    static int platforms = 0;
    /*   function RandomSign() : int {
       return Random.value< .5? 1 : -1;
   }*/
    int RandomSign() {
        return Random.value < .5 ? 1 : -1;
    }
    void Start() {
        randomize();

    }

    // Update is called once per frame
    void Update() {

    }
    // Use this for initialization
    public void randomize() {
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
            GameObject pfrom = GameObject.Instantiate(myplatform);
            pfrom.tag = "Platform";
            pfrom.transform.position = new Vector2(pfrom.transform.position.x + feri.x * 3, pfrom.transform.position.y + feri.y * 3);

        }

    }

}
