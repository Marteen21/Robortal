using UnityEngine;
using System.Collections;
public class shhot2 : MonoBehaviour
{
    private bool m_isAxisInUse = false;
    private float lastshoot;
    private int cooldown = 2;
    public GameObject projeprefab;
    // Use this for initialization
    void Start()
    {
        lastshoot = Time.time;
    }
    void shootshit()
    {
        Debug.Log("Fire");
        if (lastshoot + cooldown < Time.time)
        {
            lastshoot = Time.time;
            GameObject Projectile = GameObject.Instantiate(projeprefab);
            Projectile.transform.position = new Vector3(gameObject.transform.position.x + 1 * Mathf.Sign(gameObject.transform.localScale.x), gameObject.transform.position.y+0.5f, gameObject.transform.position.z);
            Projectile.transform.localScale = new Vector3(Mathf.Sign(gameObject.transform.localScale.x) * Projectile.transform.localScale.x, Projectile.transform.localScale.y, Projectile.transform.localScale.z);
            Projectile.GetComponent<Rigidbody2D>().AddForce(Vector2.right);
            Projectile.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Fire2") != 0)
        {
            if (m_isAxisInUse == false)
            {
                // Call your event function here.
                shootshit();
                m_isAxisInUse = true;
            }
        }
        if (Input.GetAxisRaw("Fire2") == 0)
        {
            m_isAxisInUse = false;
        }
    }

}
