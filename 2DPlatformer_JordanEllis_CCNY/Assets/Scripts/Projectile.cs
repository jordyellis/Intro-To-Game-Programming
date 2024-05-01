using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D ProjectileRb;
    public float speed = 5;
    public float ProjectileLife = 2;
    public float ProjectileCount;
    public bool facingLeft;
    public PlayerController PlayerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        ProjectileCount = ProjectileLife;
        PlayerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        facingLeft = PlayerControllerScript.facingLeft;

        if (!facingLeft)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ProjectileCount -= Time.deltaTime;

        if(ProjectileCount <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        ProjectileRb.velocity = new Vector3(speed, ProjectileRb.velocity.y, 0);

        if (!facingLeft)
        {
            ProjectileRb.velocity = new Vector3(speed, ProjectileRb.velocity.y, 0);
        }

        else 
        {
            ProjectileRb.velocity = new Vector3(-speed, ProjectileRb.velocity.y, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.tag == "Enemy")
      {
        Destroy(collision.gameObject);
      }

      Destroy(gameObject);
    }
    
}
