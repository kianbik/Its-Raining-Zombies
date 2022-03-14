using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    // Start is called before the first frame update
   public Rigidbody rigidBody;
    public bool isFrozen;
    float timer = 0;
    void Start()
    {
        rigidBody.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFrozen)
        {
            timer += Time.deltaTime;
            if(timer >= 10)
            {

                rigidBody.constraints = RigidbodyConstraints.None;
                isFrozen = false;
               
            }
        }
             
    }
    public void FreezeGround()
    {
        rigidBody.constraints = RigidbodyConstraints.FreezeAll;
        isFrozen = true;
      
    }
}
