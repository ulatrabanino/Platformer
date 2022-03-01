using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlockBreak : MonoBehaviour
{
    public TMP_Text Coins;
    public TMP_Text Score;

    private int pCoins = 00;
    private int pScore = 000000;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("click");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("almost");
                BoxCollider boxCollider = hit.collider as BoxCollider;

                if (boxCollider.tag == "Question")
                {
                    pCoins++;
                    pScore = pScore + 100;
                    this.Coins.text = pCoins.ToString();
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


}
