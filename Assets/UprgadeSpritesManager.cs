using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UprgadeSpritesManager : MonoBehaviour
{
    public Sprite[] sprites;

    public Sprite GetSpriteByName(string name)
    {
        foreach (Sprite sprite in sprites)
        {
            if (sprite.name.Equals(name))
            {
                //Debug.Log("True");
                return sprite;
            }
        }
        //Debug.Log("False");
        return sprites[0]; //error sprite here
    }
}
