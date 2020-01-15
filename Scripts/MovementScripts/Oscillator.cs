using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    private float timePassed; //constant

    //seriously if you can't work these out...
    [Header("Handling Modifiers")]
    public float speed = 0;
    public float radiusX = 0;

    /* 
     * These move the object in the scene
     * Use these to set the desired position
     */
    [Header("X,Y,Z Position Modifiers")]
    public float xMod = 0f;
    public float yMod = 0f;
    public float zMod = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //has to initialise to 0 or it breaks
        timePassed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += (Time.deltaTime * speed);

        /*
         * Movement decided by:
         * (time passed * radius) + modifier (per axis)
         * 
         * This math always moves the object in circles
         * 
         * Math is done in radians
         */
        float x, y, z;
        x = Mathf.Cos(timePassed) * radiusX + xMod;
        y = yMod;
        z = Mathf.Sin(timePassed) * radiusX + zMod;

        transform.position = new Vector3(x, y, z);
    }
}
