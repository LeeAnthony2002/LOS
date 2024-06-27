using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
   
    public GameObject Player;
    private Rigidbody2D rb;
    public float force;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
            rb = GetComponent<Rigidbody2D>();
            Player = GameObject.FindGameObjectWithTag("Player");

            UnityEngine.Vector3 direction = Player.transform.position - transform.position;
            rb.velocity = new UnityEngine.Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if( timer > 10) {

             Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().health -= 10;
            Destroy(gameObject);
        }
        
        else if(other.gameObject.CompareTag("Ground")) {
                Destroy(gameObject);
        }

        else{
            
        }
    }
    
}
