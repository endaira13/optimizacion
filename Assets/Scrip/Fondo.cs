using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour
{
   public float speed;
   
   [SerializeField]
   private MeshRenderer mesh;

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(0, Time.time * speed);
        mesh.material.mainTextureOffset = offset;
    }
}
