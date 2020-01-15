using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeBehaviour : MonoBehaviour
{
    [SerializeField] 
    private ParticleSystem firePrefab;
    [SerializeField] 
    private Transform fireStartPos;
    [SerializeField] 
    private Transform fireEndPos;
    [SerializeField] 
    private RopePuzzle ropePuzzle;
    private float length;
    private float startTime;

    public bool burn = false;
    public float speed = 0.1f;

    private void Start()
    {
        startTime = Time.time;

        //calculate length
        length = Vector3.Distance(fireStartPos.position, fireEndPos.position);
    }
    
    private void Update()
    {
        //see if object needs to burn
        if (burn == true)
        {
            Burn();
        }
    }

    public void Burn()
    {
        /* 
         * Instantiate object at certain location
         * enable particle emitter
         * start timer
         * move object from start position to final position
         * delete object
         * update the puzzle manager that time has been completed.
         * check if the puzzle was failed.
         */

        
    }
}
