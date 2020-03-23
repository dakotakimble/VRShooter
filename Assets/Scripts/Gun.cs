using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    AudioSource audioSource;
    public float fireRate;
    private float nextTimeToFire = 0f;
    bool didFire;
    public Transform firePoint;
    public int damage;
    public GameObject bulletHoleFlesh;
    public GameObject bulletHoleWood;

    private int counter = 0;

    private PlayerWeapon currentWeapon;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        
       
         
    }
    

    public void Fire()
    {
        print("Pew!");
       // audioSource.PlayOneShot(audioSource.clip);
        RaycastHit hit;

        var forward = firePoint.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(firePoint.transform.position, forward * 30, Color.red);

        // //working 12/28
        // //RAYCAST METHOD
        if (Physics.Raycast(firePoint.transform.position, forward * 30, hitInfo: out hit, maxDistance: 100f))
        {
            GameObject fleshBulletHoleHandler;
            GameObject woodBulletHoleHandler;
            var hitRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject.CompareTag("Monster"))
            {
                Debug.Log(hitObject.transform.name);
                fleshBulletHoleHandler = Instantiate(bulletHoleFlesh, hit.point, hitRotation);
                Destroy(fleshBulletHoleHandler, 5f);


                Monster monsterScript = hitObject.GetComponent<Monster>();
                monsterScript.Hurt(damage);
            }
            if (hitObject.CompareTag("Wood"))
            {
                woodBulletHoleHandler = Instantiate(bulletHoleWood, hit.point, hitRotation);
                Destroy(woodBulletHoleHandler, 5f);
            }
            
        }
    }
    


}
