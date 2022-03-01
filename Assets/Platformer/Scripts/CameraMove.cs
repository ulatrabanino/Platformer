using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform character;

    void Update()
    {
        Vector3 pos = new Vector3(character.position.x, transform.position.y, transform.position.z);

        transform.position = pos;
    }
}
