using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject cannonRotator;
    public GameObject cannonBarrel;
    public GameObject cannonBallPrefab;
    public Transform ballSpawnPoint;

    public float speed = 5f;
    public float shootForce = 20f;
    
    float sideRotation = 0.0f;
    float verticalRotation = 0.0f;

    void Update()
    {
        RotateCannon();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Spawns a cannon ball and adds an impulse force to the ball for each space bar press
            GameObject cannonBall = Instantiate(cannonBallPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation);
            cannonBall.GetComponent<Rigidbody>().
            AddForce(ballSpawnPoint.transform.forward * shootForce, ForceMode.Impulse);
        }
    }

    void RotateCannon()
    {
        sideRotation += speed * Input.GetAxis("Horizontal") * Time.deltaTime;
        verticalRotation += speed * -Input.GetAxis("Vertical") * Time.deltaTime;

        // Limits the radius of the horizontal and vertical rotations
        sideRotation = Mathf.Clamp(sideRotation, -90f, 90f);
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 0f);

        Vector3 cannonRotation = cannonRotator.transform.eulerAngles;
        cannonRotator.transform.eulerAngles = new Vector3(cannonRotation.x, sideRotation, cannonRotation.z);
        
        Vector3 cannonBarrelRotation = cannonBarrel.transform.eulerAngles;
        cannonBarrel.transform.eulerAngles = new Vector3(verticalRotation, cannonBarrelRotation.y, cannonBarrelRotation.z);
    }
}