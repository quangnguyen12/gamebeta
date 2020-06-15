using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinpickup : MonoBehaviour
{
    [SerializeField] int coin1 = 100;
    [SerializeField] int coin2 = 200;
    [SerializeField] int coin3 = 500;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<gamesession>().AddToScore(coin1);
        FindObjectOfType<gamesession>().AddToScore(coin2);
        FindObjectOfType<gamesession>().AddToScore(coin3);
        Destroy(gameObject);
    }
}

