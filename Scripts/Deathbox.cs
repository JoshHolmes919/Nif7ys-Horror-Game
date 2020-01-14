using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathbox : MonoBehaviour
{
    public PlayerManager playerScript;

    private void OnTriggerEnter(Collider collider)//when something walks into box
    {
        if (collider.tag == "Player")//if its player
        {
            playerScript = collider.gameObject.GetComponent<PlayerManager>();//find player manager script

            playerScript.Instakill();//do 10 damage and kill player instantly
        }
    }
}
