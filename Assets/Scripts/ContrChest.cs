using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrChest : MonoBehaviour
{
    public GameObject chest;
    public GameObject energy;
    public GameObject effect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(energy, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(chest);
        }
    }
}
