using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            player_movement player = collision.gameObject.GetComponent<player_movement>();
            player.score += 5;
            gameObject.SetActive(false);
        }
    }
}
