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
    [Tooltip("IDs of all the pickups to spawn when the block dies")] [SerializeField] protected float[] LootIds;
    [SerializeField] protected Sprite MainSprite;
    [Tooltip("Whether this block can get old or not, for persisting between runs")] [SerializeField] protected bool CanAge = false;
    [Tooltip("The sprite to use when the block gets old")] [SerializeField] protected Sprite OldSprite;
    [SerializeField] protected TextMeshPro TextRendererRef;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

    }
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
            Kill();
        }
        Debug.Log("I took " + IncomingDamage + " Damage");
    }
    protected void Kill()
    {
        Destroy(gameObject); //Destroys self
    }
    protected void OnTouch()
    {
        
    }
    protected void OnInteractedWith(GameObject Source)
    { //Could heal, if they interact with the correct material
        
    }
    protected void Destroy()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            //TextRendererRef.text = BlockName;
        }
        else if (collision.collider.tag == "Player")
        {
            
        }
    }
}
