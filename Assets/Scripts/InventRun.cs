using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventRun : Singleton<InventRun>
{
    public GameObject slot_1;
    public GameObject slot_Active;
    public Sprite slot_S1;
    public Sprite slot_SA;  
    public bool isSlot1Occupied = false;
    public bool isSlotAOccupied = false;
    public SpriteRenderer slot1Renderer;
    public SpriteRenderer slotARenderer;

    public Sprite BAFF1;
    public Sprite BAFF2;
    public Sprite BAFF3;
    public Sprite BAFFDefault;
    public void OnClickSlot1()
    {
        slot_S1 = slot1Renderer.sprite;
        slot_SA = slotARenderer.sprite;
        slot1Renderer.sprite = slot_SA;
        slotARenderer.sprite = slot_S1;
    }
    public void OnClickSlotActive()
    {

        slot_S1 = slot1Renderer.sprite;
        slot_SA = slotARenderer.sprite;
        slot1Renderer.sprite = slot_SA;
        slotARenderer.sprite = slot_S1;
    }
    private void Start()
    {
        slot1Renderer = slot_1.GetComponent<SpriteRenderer>();
        slotARenderer = slot_Active.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {



        if (slotARenderer.sprite == BAFF1)
        {
            Character.speed = 4f + Character.txtInfoOfRun;
        }   
        if (slotARenderer.sprite == BAFF2)
        {
            Character.speed = 5f + Character.txtInfoOfRun;
        }    
        if (slotARenderer.sprite == BAFF3)
        {
            Character.speed = 7f + Character.txtInfoOfRun;
        }
        if (slotARenderer.sprite == BAFFDefault)
        {
            Character.speed = 3f + Character.txtInfoOfRun;
        }
        if (slot1Renderer.sprite == BAFF1 || slot1Renderer.sprite == BAFF2 || slot1Renderer.sprite == BAFF3)
        {
            isSlot1Occupied = true;
        }
        else { 
            isSlot1Occupied = false;
        }
        if (slotARenderer.sprite == BAFF1 || slotARenderer.sprite == BAFF2 || slotARenderer.sprite == BAFF3)
        {
            isSlotAOccupied = true;
        }
        else
        {
            isSlotAOccupied = false;
        }
    }
}
