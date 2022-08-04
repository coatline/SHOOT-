using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public GameObject bullet;
    Rigidbody2D rb;
    public float jumpHeight;
    private bool canJump;
    SpriteRenderer sr;
    bool opMode = false;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (Input.GetKeyDown("w") && canJump)
        {
            Vector2 jump = new Vector2(0, jumpHeight);
            rb.AddForceAtPosition(jump, transform.position);
            canJump = false;
        }

        if (Input.GetKey("a"))
        {
            sr.flipX = true;
            var pos = transform.position;
            pos.x -= .05f;
            transform.position = pos;
        }
        else if (Input.GetKey("d"))
        {
            sr.flipX = false;
            var pos = transform.position;
            pos.x += .05f;
            transform.position = pos;
        }
        if (!opMode)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (bullet != null)
                {
                    Vector2 shotVel;

                    if (sr.flipX == true)
                    {
                        bullet.transform.position = transform.position + new Vector3(-.5f, .35f, 0);
                        shotVel = new Vector2(-300, 0);
                    }
                    else
                    {
                        bullet.transform.position = transform.position + new Vector3(.5f, .35f, 0);
                        shotVel = new Vector2(300, 0);
                    }

                    var instantiatedBullet = Instantiate(bullet);

                    instantiatedBullet.GetComponent<Rigidbody2D>().AddForce(shotVel);
                }
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (bullet != null)
                {
                    Vector2 shotVel;

                    if (sr.flipX == true)
                    {
                        bullet.transform.position = transform.position + new Vector3(-.5f, .35f, 0);
                        shotVel = new Vector2(-300, 0);
                    }
                    else
                    {
                        bullet.transform.position = transform.position + new Vector3(.5f, .35f, 0);
                        shotVel = new Vector2(300, 0);
                    }

                    var instantiatedBullet = Instantiate(bullet);

                    instantiatedBullet.GetComponent<Rigidbody2D>().AddForce(shotVel);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            sr.color += new Color(200, -5, -5);

            Destroy(gameObject, .07f);
        }
    }
}
