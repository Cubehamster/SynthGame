using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public Transform target;
    public GameObject theBall;

    public int speed;
    public float despawnTime = 10.0f;

    public bool shootAble = true;
    public bool isBallSpawningAllowed = true;
    public float waitBeforeNextShot = 6.0f;
    public bool ballCanSpawn = true;

    void Update()
    {
        transform.LookAt(target);
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
        var ball = Instantiate(theBall, transform.position, transform.rotation);
        Destroy(ball, despawnTime);
    }
}
