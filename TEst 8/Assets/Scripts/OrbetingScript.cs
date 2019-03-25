using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbetingScript : MonoBehaviour
{
    public GameObject ball;
    public GameObject sphere;
    private int speedRight;
    private int speedForward;
    public float minValue;
    public float maxValue;
    private Vector3 randomAngle;
    private int randomDirection;
    public int maxForwardSpeed;
    public int minForwardSpeed;
    public int maxRightSpeed;
    public int minRightSpeed;


    private void Awake()
    {
        //ball.transform.Rotate(0, 0, Random.Range(minValue, maxValue), Space.World);
        randomAngle = new Vector3(0, 1, 0);
        randomDirection = (Random.Range(0, 2) * 2 - 1);
        Debug.Log(randomDirection.ToString());
        speedForward = Random.Range(minForwardSpeed, maxForwardSpeed + 1);
        speedRight = Random.Range(minRightSpeed, maxRightSpeed + 1);
    }
    // Update is called once per frame
        void Update()
    {
        //transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);

        Vector3 relativePos = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;

        // the second argument, upwards, defaults to Vector3.up
        if (sphere.activeSelf) {
            Quaternion rotation = Quaternion.LookRotation(relativePos, randomAngle);
            transform.rotation = rotation;
        }

        float dist = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position);
        ball.GetComponent<Rigidbody>().velocity = (ball.transform.right * (speedRight*dist/100) * randomDirection);
        //ball.GetComponent<Rigidbody>().velocity = ball.transform.forward * speed;
    }
}
