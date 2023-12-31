using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_BC : MonoBehaviour
{
    [SerializeField] protected Sprite[] sprites;
    [SerializeField] protected SpriteRenderer bgImage;

    private void Start()
    {
        this.ChangeSprite();
    }

    protected virtual void ChangeSprite()
    {
        if (this.sprites != null && this.sprites.Length > 0 && this.bgImage != null)
        {
            int ranIdx = Random.Range(0, this.sprites.Length);

            if (this.sprites[ranIdx] != null)
            {
                this.bgImage.sprite = this.sprites[ranIdx];
            }
        }
    }
}
