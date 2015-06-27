using UnityEngine;
using System.Collections;

public class TrapScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D col) {
        if (col.collider.tag == "Player") {
            col.collider.GetComponent<Stats>().decHp();
            col.collider.GetComponent<Stats>().NewBackGround();
            col.collider.transform.position = GameObject.FindGameObjectWithTag("SpawnPoint").gameObject.transform.position;
        }
    }
}
