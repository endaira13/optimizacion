using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Limites
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerMove : MonoBehaviour
{
    public float speed = 15f;
    public Limites limites;
    private Rigidbody rig;


    public GameObject bulletPrefab;
    public Transform gunPosition;
    public int ammoType;

    public GameObject navePrefab;
    public Transform startPosition;

    // Start is called before the first frame update
    void Awake()
    {
       rig = GetComponent<Rigidbody>(); 
       
       
       
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = PoolManager.Instance.GetPooledObjects(ammoType, gunPosition.position, gunPosition.rotation);
            bullet.SetActive(true);
        }

        GameObject nave = PoolNves.Instance.GetPooledObjects(ammoType, startPosition.position, startPosition.rotation);
        nave.SetActive(true);
    }

    

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rig.velocity = movement * speed;
        rig.position = new Vector3(Mathf.Clamp(rig.position.x,limites.xMin, limites.xMax), 0f, Mathf.Clamp(rig.position.z,limites.zMin, limites.zMax));

        
    }
}
