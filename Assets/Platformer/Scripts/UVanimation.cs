using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVanimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Material mat = GetComponent<MeshRenderer>().material;
        mat.mainTextureOffset = mat.mainTextureOffset + new Vector2(0f, Time.deltaTime);
        mat.mainTextureScale = new Vector2(-0.999f, -0.2f);
    }
}
