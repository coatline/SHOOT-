using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    Rigidbody2D rb2d;

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        
	}

    void LookForTarget()
    {
        Ray2D ray;
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, transform.forward);

        var player = GameObject.FindGameObjectWithTag("Player");

        if (Physics2D.Raycast(transform.position, player.transform.position))
        {
            Debug.DrawRay(transform.position, transform.forward, Color.blue, 1000);

            print(hit2D.collider.name);

            if (hit2D.collider.gameObject.CompareTag("Player"))
            {
                print("I C YOU");
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            var sr = GetComponent<SpriteRenderer>();

            sr.color += new Color(200, -5, -5);

            Destroy(gameObject, .07f);
        }
    }
}
