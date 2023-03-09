using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int ammoType;
    public Transform startPosition;
 
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * 20 * Time.deltaTime;

        
    }

    void OnCollisionEnter(Collision other)
    {
        this.gameObject.SetActive(false);

    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Bala"))
        {
            this.gameObject.SetActive(false);
            GameObject nave = PoolNves.Instance.GetPooledObjects(ammoType, startPosition.position, startPosition.rotation);
            nave.SetActive(true);

            

        }
    }
}
