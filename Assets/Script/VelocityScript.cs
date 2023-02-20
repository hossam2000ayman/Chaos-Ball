using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityScript : MonoBehaviour
{
    public float startSpeed = 50f;
    private void Start()
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = new Vector3(startSpeed, 0, startSpeed);
    }
}
