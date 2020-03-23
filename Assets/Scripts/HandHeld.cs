using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHeld : MonoBehaviour
{
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider coll)
    {

        if (coll.CompareTag("Monster"))
        {
            Debug.Log(coll.transform.name);


            Monster monsterScript = coll.GetComponent<Monster>();
            monsterScript.Hurt(damage);
        }


    }
}
