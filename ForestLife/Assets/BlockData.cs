using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class BlockData : MonoBehaviour
{
    [SerializeField] protected float MaxHP = 100;
    protected float CurrentHP = 100;
    [SerializeField] protected float Defense = 0;
    [Tooltip("Reference to the block this block should spawn in when it dies. If left blank, will not spawn a block")] [SerializeField] protected GameObject NewBlockRef;
    [SerializeField] protected bool ShowHealthBar = false;
    [Tooltip("IDs of all the pickups to spawn when the block dies")] [SerializeField] protected float[] LootIds;
    [SerializeField] protected Sprite MainSprite;
    [Tooltip("Whether this block can get old or not, for persisting between runs")] [SerializeField] protected bool CanAge = false;
    [Tooltip("The sprite to use when the block gets old")] [SerializeField] protected Sprite OldSprite;
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
    } //
}
