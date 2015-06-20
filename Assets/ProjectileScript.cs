using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {
    private float created;
	// Use this for initialization
	void Start () {
        created = Time.time;
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(800*Mathf.Sign(gameObject.transform.localScale.x)*-1, 0));
	}
	
	// Update is called once per frame
	void Update () {
        if (created + 3 < Time.time) {
            GameObject.Destroy(gameObject);
        }
       
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
        {
            col.collider.GetComponent<Stats>().decHp();
            col.collider.GetComponent<Stats>().NewBackGround();
            col.collider.GetComponent<Stats>().respawn();
            GameObject.Destroy(gameObject);
        }
    }
}
