using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class BlockDataEditorUpdate1 : MonoBehaviour
{
    Sprite MainSpriteLocal;
    void Awake()
    {
        MainSpriteLocal = gameObject.GetComponent<BlockData>().GetBlockSpriteForEditor();
        gameObject.GetComponent<SpriteRenderer>().sprite = MainSpriteLocal;
    }

    void Update()
    {
        if (MainSpriteLocal)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = MainSpriteLocal;
        }
    } 
}
