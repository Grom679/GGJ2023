using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helper
{
    public static class Helpers
    {
        public static Sprite CreateSprite(Texture2D texture)
        {
            int width = texture.width;
            int height = texture.height;
    
            return CreateSprite(texture, width, height);
        }
        public static Sprite CreateSprite(Texture2D texture, float width, float height)
        {
            return Sprite.Create(texture, 
                new Rect(0, 0, width, height), 
                new Vector2(0.5f, 0.5f));
        }
    }
}

