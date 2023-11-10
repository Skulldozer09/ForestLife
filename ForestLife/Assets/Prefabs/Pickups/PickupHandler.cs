using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHandler : MonoBehaviour
{
    [SerializeField] protected string PickupName = "GenericPickup";
    [SerializeField] protected float value = 1;
    [SerializeField] protected int pickupID = 0;
    public void SetInitialStats(string newpickupname, float newvalue, int newpickupID, Sprite newSprite)
    {
        PickupName = newpickupname;
        value = newvalue;
        pickupID = newpickupID;
        GetComponent<SpriteRenderer>().sprite = newSprite;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.GetComponent<InventoryHandler>().ReceivePickupInfo(pickupID, value, gameObject);
        }
    }
    public void CanDestroy()
    {
        Kill();
    }
    protected void Kill()
    {
        Destroy(gameObject);
    }
}
