using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    private int currHealth;
    public static GameManager gameManger;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currHealth == 0)
        {
            gameManger.Restart();
        }
    }

    public void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Monster"))
        {
            Debug.Log("enemy attacking");
            currHealth -= 5;
        }
    }
}
