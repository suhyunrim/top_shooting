using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public float MovementSpeed = 0.0001f;
    public List<GameObject> BackgroundSprites;

    private float startY;
    private float spriteHeight;

    private void Start()
    {
        startY = BackgroundSprites[0].transform.position.y;
        spriteHeight = BackgroundSprites[0].GetComponent<SpriteRenderer>().bounds.size.y;

        for (int i = 1; i < BackgroundSprites.Count; ++i)
        {
            var prevBack = BackgroundSprites[i - 1];
            var curBack = BackgroundSprites[i];
            curBack.transform.localPosition = new Vector3(0, prevBack.transform.position.y + spriteHeight);
        }
    }

    private void Update()
    {
        for (int i = 0; i < BackgroundSprites.Count; ++i)
        {
            var background = BackgroundSprites[i];

            if (background.transform.position.y < startY - spriteHeight)
            {
                var prevIndex = i - 1;
                if (prevIndex == -1)
                    prevIndex = BackgroundSprites.Count - 1;

                var prevBack = BackgroundSprites[prevIndex];
                background.transform.localPosition = new Vector2(0, prevBack.transform.position.y + spriteHeight);
            }

            background.transform.Translate(new Vector2(0, -MovementSpeed));
        }
    }
}