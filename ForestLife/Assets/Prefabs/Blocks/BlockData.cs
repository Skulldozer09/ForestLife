using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]

public class BlockData : MonoBehaviour
{
    [SerializeField] protected string BlockName = "GenericBlock";
    [SerializeField] protected float MaxHP = 100;
    protected float CurrentHP = 100;
    [SerializeField] protected float Defense = 0;
    [Tooltip("Reference to the block this block should spawn in when it dies. If left blank, will not spawn a block")] [SerializeField] protected GameObject NewBlockRef;
    [SerializeField] protected bool ShowHealthBar = false;
    [Tooltip("Refs of all the pickups to spawn when the block dies.")] [SerializeField] protected GameObject[] LootRefs;
    [Tooltip("IDs of all the pickups to spawn when the block dies. This is the amount.")] [SerializeField] protected int[] LootAmounts;
    [SerializeField] protected Sprite MainSprite;
    [Tooltip("Whether this block can get old or not, for persisting between runs")] [SerializeField] protected bool CanAge = false;
    [Tooltip("The sprite to use when the block gets old")] [SerializeField] protected Sprite OldSprite;
    [SerializeField] protected TextMeshPro TextRendererRef;

    public Sprite GetBlockSpriteForEditor()
    {
        return MainSprite;
    }
    public void DamageMe(float IncomingDamage, GameObject Source) //Whenever the block receives damage
    {
        OnDamage(IncomingDamage, Source);
    }
        protected void OnDamage(float IncomingDamage, GameObject Source) //Whenever the block receives damage
    {
        CurrentHP -= IncomingDamage;
        if (CurrentHP <= 0)
        {
            if (Source.tag == "Player")
            {
                Destroy();
            }
            else
            {
                Delete(); //Just delete it, nothing drops
            }
        }
        Debug.Log(BlockName + " took " + IncomingDamage + " Damage");
    }
    protected void Delete() //Destroys object without dropping anything
    {
        Destroy(gameObject); //Destroys self
    }
    protected void OnTouch()
    {
        //TextRendererRef.text = BlockName;
    }
    protected void OnInteractedWith(GameObject Source)
    { //Could heal, if they interact with the correct material
        
    }
    protected void Destroy() //Drops stuff, then deletes itself
    {
        if (NewBlockRef)
        {
            Instantiate(NewBlockRef, gameObject.transform.position, Quaternion.identity);
        }
        if (LootRefs.Length > 0) //If at least 1 loot entry
        {
            for (int i = 0; i < LootRefs.Length; i++) //Loop through each item id to spawn
            {
                //LootIds[i]
                for (int x = 0; x < LootAmounts[i]; x++) //Loop for each amount needed to spawn nearby
                {
                    //GameObject variableForPrefab = (GameObject)Resources.Load("Prefabs/Pickups/", typeof(GameObject));
                    Vector3 ItemSpawnPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1, gameObject.transform.position.z);
                    Instantiate(LootRefs[i], ItemSpawnPos, Quaternion.identity);
                }
            }
        }
        Delete();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            OnTouch();
        }
        else if (collision.collider.tag == "Enemy")
        {
            OnTouch();
        }
    }
}
