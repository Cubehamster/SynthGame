using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{

    public GameObject GunFloor;
    public GameObject GunInHand;
    public GameObject FirstPersonController;
    public GameObject BallSpawner;

    // Start is called before the first frame update
    void Start()
    {

    }
        
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Pickup Triggered");
            GunFloor.SetActive(false);
            GunInHand.SetActive(true);
            FirstPersonController.GetComponent<Shoot>().enabled = true;
            FirstPersonController.GetComponent<AudioSource>().enabled = true;
            BallSpawner.SetActive(true);
        }
        
    }
}
