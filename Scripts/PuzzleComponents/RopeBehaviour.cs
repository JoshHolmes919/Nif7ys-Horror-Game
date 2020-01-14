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
        //burn the object
        
        //print success
        print("In Position, Papi");

        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / length;

        // Set our position as a fraction of the distance between the markers.
        firePrefab.transform.position = Vector3.Lerp(fireStartPos.position, fireEndPos.position, fractionOfJourney);

        //print movement
        print("I moved Papi");

        if (distCovered == length)
        {
            print("finished moving papi");
            Destroy(gameObject);
        }
    }
}
