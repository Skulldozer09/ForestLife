using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    protected int ThatchCount = 0;
    protected int WoodCount = 0;
    protected int StoneCount = 0;
    protected int MetalCount = 0;
    protected int RopeCount = 0;
    protected int LeatherCount = 0;
    protected int RawMeatCount = 0;
    protected int CookedMeatCount = 0;
    protected int RawVegCount = 0;
    protected int CookedVegCount = 0;
    protected int SeedsCount = 0;
    [SerializeField] protected int ThatchLimit = 99;
    [SerializeField] protected int WoodLimit = 99;
    [SerializeField] protected int StoneLimit = 99;
    [SerializeField] protected int MetalLimit = 99;
    [SerializeField] protected int RopeLimit = 99;
    [SerializeField] protected int LeatherLimit = 99;
    [SerializeField] protected int RawMeatLimit = 99;
    [SerializeField] protected int CookedMeatLimit = 99;
    [SerializeField] protected int RawVegLimit = 99;
    [SerializeField] protected int CookedVegLimit = 99;
    [SerializeField] protected int SeedsLimit = 99;
    public void ReceivePickupInfo(int pickupID, float value, GameObject PickupRef) //Function to give the player HP or other pickups
    {
        if (pickupID == 1) //HP Pickup
        {
            //Call heal function in player health script. Should check the player HP. If full, then return false and dont affect the pickup.
            //If not full, send the amount of HP to heal them and destroy the pickup.
            //Right now, it just destroys the pickup without doing anything
            PickupRef.GetComponent<PickupHandler>().CanDestroy();
        }
        else if (pickupID == 2) //Thatch
        {
            if (ThatchCount + value <= ThatchLimit) //If it doesn't go over the cap, will add the amount to inv and then tell the pickup to die
            {
                ThatchCount += (int)value;
                Debug.Log("I have " + ThatchCount + " Thatch");
                PickupRef.GetComponent<PickupHandler>().CanDestroy();
            }
        }
        else if (pickupID == 3) //Wood
        {
            if (WoodCount + value <= WoodLimit)
            {
                WoodCount += (int)value;
                PickupRef.GetComponent<PickupHandler>().CanDestroy();
            }
        }
        else if (pickupID == 4) //Stone
        {
            if (StoneCount + value <= StoneLimit)
            {
                StoneCount += (int)value;
                PickupRef.GetComponent<PickupHandler>().CanDestroy();
            }
        }
        else if (pickupID == 5) //Metal
        {
            if (MetalCount + value <= MetalLimit)
            {
                MetalCount += (int)value;
                PickupRef.GetComponent<PickupHandler>().CanDestroy();
            }
        }
        else if (pickupID == 6) //Rope
        {
            if (RopeCount + value <= RopeLimit)
            {
                RopeCount += (int)value;
                PickupRef.GetComponent<PickupHandler>().CanDestroy();
            }
        }
        else if (pickupID == 7) //Leather
        {
            if (LeatherCount + value <= LeatherLimit)
            {
                LeatherCount += (int)value;
                PickupRef.GetComponent<PickupHandler>().CanDestroy();
            }
        }
        else if (pickupID == 8) //Raw Meat
        {
            if (RawMeatCount + value <= RawMeatLimit)
            {
                RawMeatCount += (int)value;
                PickupRef.GetComponent<PickupHandler>().CanDestroy();
            }
        }
        else if (pickupID == 9) //Cooked Meat
        {
            if (CookedMeatCount + value <= CookedMeatLimit)
            {
                CookedMeatCount += (int)value;
                PickupRef.GetComponent<PickupHandler>().CanDestroy();
            }
        }
        else if (pickupID == 10) //Raw Veg
        {
            if (RawVegCount + value <= RawVegLimit)
            {
                RawVegCount += (int)value;
                PickupRef.GetComponent<PickupHandler>().CanDestroy();
            }
        }
        else if (pickupID == 11) //Cooked Veg
        {
            if (CookedVegCount + value <= CookedVegLimit)
            {
                CookedVegCount += (int)value;
                PickupRef.GetComponent<PickupHandler>().CanDestroy();
            }
        }
        else if (pickupID == 12) //Seeds
        {
            if (SeedsCount + value <= SeedsLimit)
            {
                SeedsCount += (int)value;
                PickupRef.GetComponent<PickupHandler>().CanDestroy();
            }
        }
        InventoryUpdated(); //Function to probably update the UI or something
    }
    public int GetPickupInfo(int pickupID) //Returns how much of each material you have
    {
        if (pickupID == 2) //Thatch
        {
            return ThatchCount;
        }
        else if (pickupID == 3) //Wood
        {
            return WoodCount;
        }
        else if (pickupID == 4) //Stone
        {
            return StoneCount;
        }
        else if (pickupID == 5) //Metal
        {
            return MetalCount;
        }
        else if (pickupID == 6) //Rope
        {
            return RopeCount;
        }
        else if (pickupID == 7) //Leather
        {
            return LeatherCount;
        }
        else if (pickupID == 8) //Raw Meat
        {
            return RawMeatCount;
        }
        else if (pickupID == 9) //Cooked Meat
        {
            return CookedMeatCount;
        }
        else if (pickupID == 10) //Raw Veg
        {
            return RawVegCount;
        }
        else if (pickupID == 11) //Cooked Veg
        {
            return CookedVegCount;
        }
        else if (pickupID == 12) //Seeds
        {
            return SeedsCount;
        }
        else
            return 0;
    }
    void InventoryUpdated()
    {
        //Update the UI here
    }
}
