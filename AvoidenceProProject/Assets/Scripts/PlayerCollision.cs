using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCollision : MonoBehaviour
{
    public GameObject player;
    public PlayerController playerNum;
    public GameManager gm;
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "baby")
        {
            Destroy(collisionInfo.gameObject);
            playerNum.score += 10;
            player.transform.localScale = new Vector3(player.transform.localScale.x + 1f, player.transform.localScale.y + 1f, player.transform.localScale.z + 1f);
        } else if(collisionInfo.collider.tag == "badGuy" && playerNum.score < 100)
        {
            gm.EndGame();
        } else if (collisionInfo.collider.tag == "wand")
        {
            Destroy(collisionInfo.gameObject);
            playerNum.score += 5;
            playerNum.moveSpeed += 1;
            player.transform.localScale = new Vector3(player.transform.localScale.x + .5f, player.transform.localScale.y + .5f, player.transform.localScale.z + .5f);
        } else if (collisionInfo.collider.tag == "badGuy" && playerNum.score >= 100)
        {
            Destroy(collisionInfo.gameObject);
            playerNum.score += 100;
            player.transform.localScale = new Vector3(player.transform.localScale.x + 10f, player.transform.localScale.y + 10f, player.transform.localScale.z + 10f);
            gm.Win();
        } else if (collisionInfo.collider.tag == "Snitch")
        {
            Destroy(collisionInfo.gameObject);
            playerNum.score += 50;
            playerNum.moveSpeed += 2;
            player.transform.localScale = new Vector3(player.transform.localScale.x + 5f, player.transform.localScale.y + 5f, player.transform.localScale.z + 5f);
        }
    }
}
