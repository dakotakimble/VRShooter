using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    AudioSource audioSource;
    public float fireRate;
    public Animator _animator;
    
    public Transform firePoint;
    public int damage;
    public GameObject bulletHoleFlesh;
    public GameObject bulletHoleWood;

    private float nextFire;

    public string animClip;
    public string reloadClip;
    public float reloadTime = 2f;

    public int ammo;
    public int maxAmmo;
    public int curAmmo;
    public bool canFire = true;
    public bool isReloading = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (curAmmo == -1)
            curAmmo = maxAmmo;
    }

    public void Update()
    {
        if(curAmmo <= 0)
        {
            Debug.Log("out of ammo");
            canFire = false;
            // isReloading = true;
            StartCoroutine(Reload());
        }

        //if (isReloading)
        //{
        //    //_animator.Play(reloadClip, 0, 0);
        //    //ammo = maxAmmo;
        //    //isReloading = false;

        //    StartCoroutine(Reload());
        //}


    }

    IEnumerator Reload()
    {
        isReloading = true;

        Debug.Log("Reloading...");
        _animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - 0.25f);

        _animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(0.25f);
        curAmmo = maxAmmo;
        canFire = true;
        isReloading = false;
    }





    public void Fire()
    {
        if (!canFire)
        {
            return;
        }
        if (Time.time > nextFire && canFire)
        {
            nextFire = Time.time + fireRate;
            _animator.Play(animClip, 0, 0);
            curAmmo--;
            print("Pew!");

            RaycastHit hit;

            var forward = firePoint.transform.TransformDirection(Vector3.forward);
            Debug.DrawRay(firePoint.transform.position, forward * 30, Color.red);
            audioSource.Play();

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

    



}
