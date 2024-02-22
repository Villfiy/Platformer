using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ContrBaffs : MonoBehaviour
{
    public Sprite baff_4;
    public Sprite baff_0;
    public GameObject effect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!InventRun.Instance.isSlotAOccupied || !InventRun.Instance.isSlot1Occupied)
            {
                Instantiate(effect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            if (!InventRun.Instance.isSlot1Occupied)
            {
                InventRun.Instance.slot1Renderer.sprite = baff_4;
                InventRun.Instance.isSlot1Occupied = true;
            }
            else if (!InventRun.Instance.isSlotAOccupied)
            {
                InventRun.Instance.slotARenderer.sprite = baff_4;
                InventRun.Instance.isSlotAOccupied = true;
            }
            else
            {
                return;

            }
        }
    }
}
 