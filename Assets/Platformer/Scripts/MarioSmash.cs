using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MarioSmash : MonoBehaviour
{
    public TMP_Text Coins;
    public TMP_Text Score;
    public TMP_Text msg;

    private int pCoins = 00;
    private int pScore = 000000;

    Vector3 startPoint;

    void Start()
    {
        startPoint = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    void Update()
    {
        if (transform.position != null)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.up);
            Debug.DrawRay(ray.origin, ray.direction);
            if (Physics.Raycast(ray, out hit, 1.2f))
            {
                Debug.Log("almost");
                BoxCollider boxCollider = hit.collider as BoxCollider;

                if (boxCollider.tag == "Question")
                {
                    pCoins++;
                    pScore = pScore + 100;
                    this.Coins.text = pCoins.ToString();
                    this.Score.text = pScore.ToString();
                    Debug.Log("question");
                    Destroy(boxCollider.gameObject);
                }

                if (boxCollider.tag == "Brick")
                {
                    pScore = pScore + 100;
                    this.Score.text = pScore.ToString();
                    Debug.Log("brick");
                    Destroy(boxCollider.gameObject);
                }

            }
        }

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Goomba")
        {
            if (pScore > 0)
            {
                pScore = pScore - 100;
            }
            this.Score.text = pScore.ToString();
            this.msg.text = "You died!";
            StartCoroutine(Timed());
            Debug.Log("goomba");
            gameObject.transform.position = startPoint;
        }

        if(col.gameObject.tag == "Winner")
        {
            Debug.Log("win");
            this.msg.text = "You won!";
        }
    }

    IEnumerator Timed()
    {
        yield return new WaitForSeconds(3f);
        this.msg.text = "";
    }


    /*   void OnCollisionEnter(Collision col)
       {
           if (col.transform.position.y > transform.position.y || col.transform.position.y < transform.position.y)
           {

               if (col.gameObject.tag == "Question")
               {
                   pCoins++;
                   pScore = pScore + 100;
                   this.Coins.text = pCoins.ToString();
                   Debug.Log("question");
                   Destroy(this.gameObject);
               }

               if (col.gameObject.tag == "Brick")
               {
                   pScore = pScore + 100;
                   this.Score.text = pScore.ToString();
                   Debug.Log("brick");
                   Destroy(this.gameObject);
               }
           }
       }*/
}
