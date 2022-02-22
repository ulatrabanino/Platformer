using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBreak : MonoBehaviour
{
    public GameObject brickPrefab;
    public GameObject questionBoxPrefab;
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
                    Debug.Log("question");
                    Destroy(boxCollider.gameObject);
                }

                if (boxCollider.tag == "Brick")
                {
                    Debug.Log("brick");
                    Destroy(boxCollider.gameObject);
                }

            }
        }
    }
}
