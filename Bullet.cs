using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosion;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        //Use our rigidbody to move our bullet
        GetComponent<Rigidbody2D>().velocity = transform.up * 8;

        //Destroy bullet after 3s
        Destroy(gameObject, 3);
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<TankController>().DamageTaken(damage);
        }
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent <RandomWalkerTank>().DamageTaken(damage);
        }

        Destroy(gameObject);
        var newExplosion = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(newExplosion, 1f);
	}
}
