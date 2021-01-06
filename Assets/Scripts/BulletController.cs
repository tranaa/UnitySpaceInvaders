using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Transform bullet;

    public float speed;

    private float direction;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform> ();
        if(bullet.tag == "Bullet")
        {
            direction = 1;
        } else if (bullet.tag == "Enemy")
        {
            direction = -1;
        }
    }

    private void FixedUpdate() {
        bullet.position += Vector3.up * speed * Time.deltaTime * direction;
        if (bullet.position.y >= 10 && bullet.tag == "Bullet")
        {
            Destroy(bullet.gameObject);
        }
        else if (bullet.position.y <= -10 && bullet.tag == "Enemy")
        {
            Destroy(bullet.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (bullet.tag == "Bullet")
        {
            if (other.tag == "Enemy")
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
                GameManager.playerScore += 10;
            }
            else if (other.tag == "Base")
            {
                Destroy(gameObject);
            }
        }
        else if (bullet.tag == "Enemy")
        {
            if (other.tag == "Player")
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
                GameManager.isPlayerDead = true;
            }
            else if (other.tag == "Base")
            {
                GameObject playerBase = other.gameObject;
                BaseHealth baseHealth = playerBase.GetComponent<BaseHealth>();
                baseHealth.health -= 1;
                Destroy(gameObject);
            }
        }

    }

}
