using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Transform player;
    public float speed;
    public float maxBound, minBound;
    public Joystick joystick;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //float h = Input.GetAxis("Horizontal");
        float h = joystick.Horizontal;

        if (player.position.x < minBound && h < 0) {
            h = 0;
        } else if (player.position.x > maxBound && h > 0) {
            h = 0;
        }

        player.position += Vector3.right * h * speed * Time.deltaTime;
    }

    //void Update() {
    //    if(Input.GetButton("Fire1") && Time.time > nextFire){
    //        nextFire = Time.time + fireRate;
    //        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
    //    }
    //}

    public void fire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
}
