using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Stats : MonoBehaviour
{
    private static int maxportal = 5;
    private const int maxhp = 10;
    private int myhp = 10;
    private int myportal = 0;
    public string pname;
    public string cname;
    public GameObject hptext;
    public GameObject portaltext;
    public GameObject spawnpoint;
    public GameObject backgnd;
    public GameObject platformboss;
    public GameObject Win;

    public void decHp()
    {
        if (myhp > 1)
        {
            myhp--;
            drawStats();
        }
        else
        {
            Win.SetActive(true);
            Win.GetComponentInChildren<Text>().text = cname + " wins";
        }

    }
    public void respawn()
    {
        Debug.Log("Hol");
        gameObject.transform.position = spawnpoint.transform.position;
    }
    public void incHp()
    {
        if (myhp < maxhp)
        {
            myhp++;
        }
        drawStats();
    }
    public bool decPortal()
    {
        if (myportal > 0)
        {
            myportal--;
            drawStats();
            return true;
        }
        else
        {
            return false;
        }

    }
    public void incPortal()
    {
        if (myportal < maxportal)
        {
            myportal++;
        }
        else
        {
            Win.SetActive(true);
            Win.GetComponentInChildren<Text>().text=pname + " wins";

        }
        drawStats();
    }
    void drawStats()
    {
        hptext.GetComponent<Text>().text = ("" + myhp);
        portaltext.GetComponent<Text>().text = ("" + myportal);

    }
    public void NewBackGround()
    {
        backgnd.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("background0" + Random.Range(1, 8));
        platformboss.GetComponent<Platformscript>().randomize();
    }
    void KillCharacter()
    {

    }
    // Use this for initialization
    void Start()
    {
        drawStats();
        NewBackGround();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
