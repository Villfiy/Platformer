using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrEnegry : MonoBehaviour
{
    public GameObject Coin;
    public GameObject effect;
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, Character.storona, Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(Coin);
            Character.Energy += 1;
        }
    }
}
