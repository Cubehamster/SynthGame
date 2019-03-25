using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameObject destructablesphere;
    public GameObject normalSphere;
    public Rigidbody rigidbody;
    public Rigidbody spinSphere;
    public GameObject trail;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.tag.Equals("bullet") || collision.gameObject.tag.Equals("ground"))
        {
            destructablesphere.SetActive(true);
            spinSphere.angularVelocity = new Vector3 (1,0,0);
            normalSphere.SetActive(false);
            rigidbody.isKinematic = true;
            trail.SetActive(false);
        }
    }
}
