using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(UnityStandardAssets.Characters.FirstPerson.FirstPersonController))]

public class PlayerManager : MonoBehaviour
{
    [Header("Player Status")]
    public float health = 10f;//health
    public int respawns = 1;//respawns available
    private bool slowed = false;//slow character over time
    private bool bleeding = false;//damage health over time
    private bool detected = false;//for game audio

    
    public RopeBehaviour rope;

    public float armLength = 2f;//kill me if you don't get it
    [SerializeField] private Camera Camera;//camera to be used
    [SerializeField] private Vector3 respawnPos;//position to respawn in
    [SerializeField] private GameObject spawnPoint;//checkpoint gameobject

    private void Start()
    {
        //get the initial respawn position
        //set the players transform to there
        //to handle respawns
        UpdateCheckpoint();
        transform.position = spawnPoint.transform.position;
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20, Color.red);
        
        RaycastHit hit; //make a raycast called hit
        Ray ray = Camera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2) );//make a ray that casts from screen center

        if (Input.GetKeyDown(KeyCode.E))//if e pressed
        {
            if (Physics.Raycast(ray, out hit, armLength))
            {
                if (hit.collider.tag == "Rope")
                {
                    print("Yeet, I found a rope  tag papi");
                    rope = hit.collider.gameObject.GetComponent<RopeBehaviour>();
                    BurnRope();
                }
            }
        }

        CheckDeath();
    }

    private void UpdateCheckpoint()//change the respawn position
    {
        respawnPos = spawnPoint.transform.position;
    }

    private void TakeDamage(int damage)//hurt player
    {
        health -= damage;//needs a damage integer
    }

    private void CheckDeath()
    {
        if (health<=0)
        {
            Died();
        }
    }

    private void Died()//death proceedings
    {
        if (respawns>=1)
        {
            Respawn();
        }
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Checkpoint")
        {
            spawnPoint = target.gameObject;
            UpdateCheckpoint();
        }
        if (target.tag == "Fire")
        {
            health -= 20;
            CheckDeath();
        }
    }

    private void Respawn()//instantiate object back at spawn location
    {
        transform.position = respawnPos;
        Debug.Log("You Died :(");
        health += 20;
    }

    /*private void Slowed()
    {

    }*/

    private void BurnRope()
    {
        print("Attempting to burn papi");
        rope.burn = true;
    }

/*
 * damage types used to torture player
 */
    //used the most
    public void SmallDamage() {health -= 1f;}
    //less common
    public void MediumDamage() {health -= 5f;}   
    //rarest damage type
    public void Instakill() {health -= 10f;}
    //randoms/math types
    public void RandomDamage()
    {
        float damage = Random.Range(1f, 3f);
        health -= damage;
    }
    public void Bleed()
    {

    }
}
