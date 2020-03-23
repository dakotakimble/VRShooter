using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerWeapon : MonoBehaviour
{

    //public string name ="";

    public int damage = 10;
    public float range = 100f;

    public float fireRate = 0f;

    public int maxBullets = 20;
    [HideInInspector]
    public int bullets;

    public float reloadTime = 1f;

   // public GameObject graphics;

    public PlayerWeapon()
    {
        bullets = maxBullets;
    }

}