using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlmightyPushController : MonoBehaviour
{
    // Start is called before the first frame update
    public float power = 1000;
    public float radius = 1000;
    Vector3 explosionPos;
    void Start()
    {

        Vector3 explosionPos = transform.position;
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void explode()
    {
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {if (hit.gameObject.tag == "Explodabale")
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
            }
        }

    }
}
