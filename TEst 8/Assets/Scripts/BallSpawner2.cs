using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner2 : MonoBehaviour
{
    public GameObject ShooterBall;
    public GameObject BallBullet;
    public Transform ShooterSpawner;

    public int speed;
    public float despawnTime = 10.0f;

    public bool shootAble = true;
    public bool isBallSpawningAllowed = true;
    public float waitBeforeNextShot = 6.0f;
    public bool ballCanSpawn = true;

    void Update()
    {
        Vector3 relativePos = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;

        if (ShooterBall.activeSelf)
        {
            Quaternion rotation = Quaternion.LookRotation(relativePos + new Vector3(0, 0.5f, 0));
            transform.rotation = rotation;
        }
        if (isBallSpawningAllowed)
        {
            if (shootAble)
            {
                shootAble = false;
                Shooting();
                StartCoroutine(ShootingYield());
            }
        }
    }

    IEnumerator ShootingYield()
    {
        yield return new WaitForSeconds(waitBeforeNextShot);
        shootAble = true;
    }

    private void Shooting()
    {
        var bullet = Instantiate(BallBullet, ShooterSpawner.position, ShooterSpawner.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * speed;
        Destroy(bullet, despawnTime);
    }
}
