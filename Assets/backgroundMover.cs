using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMover : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    float offset;
    Material mat;

    Vector2 screenBounds;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset += Time.deltaTime * scrollSpeed / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
