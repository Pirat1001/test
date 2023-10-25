using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gunPoint1;
    public Transform gunPoint2;
    public float fireRate = 0.5f;
    public float divider = 1;

    public float ammo = 99;

    float timer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

		if (Input.GetMouseButton(0) && timer > fireRate && ammo > 0)
		{
            divider += 1;
            if(2 % divider != 0)
            {
                Instantiate(bulletPrefab, gunPoint2.position, gunPoint2.rotation);
                divider = 1;
            }
            else
            {
                Instantiate(bulletPrefab, gunPoint1.position, gunPoint1.rotation);
            }

            ammo--;

            //TODO: Create a seccond gunPoint and fire every other bullet from that location instead.

            timer = 0;
		}
    }
}
