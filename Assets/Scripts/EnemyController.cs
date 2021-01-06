using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private Transform enemyHolder;
    public GameObject shot;
    
    public float fireRate = 0.997f;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveEnemy", 0.1f, 0.2f);
        enemyHolder = GetComponent<Transform>();
    }

    void MoveEnemy() {
        enemyHolder.position += Vector3.right * speed;

        foreach(Transform enemy in enemyHolder) {
            if (enemy.position.x < -10.5 || enemy.position.x > 10.5){
                speed = -speed;
                enemyHolder.position += Vector3.down * 0.5f;
                return;
            }
            
            //enemy bullet controller called
            if(Random.value > fireRate){
                Instantiate(shot, enemy.position, enemy.rotation);
            }

            if(enemy.position.y <= -2.5) {
                GameManager.isPlayerDead = true;
                Time.timeScale = 0;
            }
        }

        if(enemyHolder.childCount == 1){
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f, 0.25f);
        }

        if(enemyHolder.childCount == 0){
            Time.timeScale = 0;
            GameManager.isEnemyDead = true;
        }
    }
}
