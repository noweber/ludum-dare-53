using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    public int maxHitPoints = 100;
    public int minHitPoints = 0;
    public int currentHitPoints = 100;
    public GameObject spritePrefab;
    public int spritesPer20Percent = 1;
    public int maxSprites = 5;
    public float spriteSpacing = 0.2f;

    private List<GameObject> sprites = new List<GameObject>();

    private void Start()
    {
        UpdateSprites();
    }

    private float secondsSinceLastHpChange = 0;

    private void Update()
    {
        secondsSinceLastHpChange += Time.deltaTime;
        if(secondsSinceLastHpChange > 2)
        {
            secondsSinceLastHpChange = 0;
            currentHitPoints = Random.Range(25, 100);
        }
        //currentHitPoints = Mathf.Clamp(currentHitPoints - 1, minHitPoints, maxHitPoints);
        UpdateSprites();
    }

    private void UpdateSprites()
    {
        int spritesNeeded = Mathf.RoundToInt((maxHitPoints - currentHitPoints) / (maxHitPoints / 5f)) * spritesPer20Percent;
        spritesNeeded = Mathf.Clamp(spritesNeeded, 0, maxSprites);

        int currentSprites = sprites.Count;

        if (spritesNeeded > currentSprites)
        {
            for (int i = currentSprites; i < spritesNeeded; i++)
            {
                GameObject sprite = Instantiate(spritePrefab, transform);
                sprite.transform.localPosition = new Vector3(-(i - 1) * spriteSpacing, 0, 0);
                sprites.Add(sprite);
            }
        }
        else if (spritesNeeded < currentSprites)
        {
            for (int i = currentSprites - 1; i >= spritesNeeded; i--)
            {
                GameObject sprite = sprites[i];
                sprites.RemoveAt(i);
                Destroy(sprite);
            }
        }

        UpdateSpriteOrder();
    }


    private void UpdateSpriteOrder()
    {
        // Sort the sprites based on their x position
        sprites.Sort((a, b) => a.transform.localPosition.x.CompareTo(b.transform.localPosition.x));

        // Set the local z position of each sprite based on its position in the list
        for (int i = 0; i < sprites.Count; i++)
        {
            Vector3 position = sprites[i].transform.localPosition;
            position.z = -i;
            sprites[i].transform.localPosition = position;
        }
    }
}
