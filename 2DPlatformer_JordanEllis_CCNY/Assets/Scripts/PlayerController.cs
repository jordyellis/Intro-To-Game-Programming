using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public float playerSpeed = 0.05f;
    public float jumpForce = 300;
    public bool isJumping = false;

    public int maxHealth = 20;
    public int currentHealth;
    public HealthBar HealthBarScript;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        HealthBarScript.SetMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Jump();
    }

    private void MovePlayer()
    {
        Vector3 newPos = transform.position;
        if (Input.GetKey(KeyCode.A))
        {
            newPos.x -= playerSpeed;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            newPos.x += playerSpeed;
        }

        transform.position = newPos;
    }

    private void Jump()
    {
      if(!isJumping && Input.GetKeyDown(KeyCode.Space))
      {
        playerBody.AddForce(new Vector3 (playerBody.velocity.x, jumpForce, 0));
        isJumping = true;
      }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Surface")
        isJumping = false;

        if (collision.gameObject.tag == "Lava")
        {
            TakeDamage(2);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HealthBarScript.SetHealth(currentHealth);
    }
}