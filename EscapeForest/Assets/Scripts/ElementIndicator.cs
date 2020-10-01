using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementIndicator : MonoBehaviour
{
    private Image image;
    [SerializeField]  private  Sprite[] spritesImages = new Sprite[5];

    private Dictionary<BasePlayer.element, Color> colors = new Dictionary<BasePlayer.element, Color>();
    private Dictionary<BasePlayer.element, Sprite> sprites = new Dictionary<BasePlayer.element, Sprite>();

    //Events must be subscribed += and unsubscribed to -= on enable and disable to prevent memory errors
    private void OnEnable()
    {
        //Inspector assignment of sprites checked
        UnityEngine.Assertions.Assert.IsNotNull(spritesImages[0], "Assign element UI sprites in inspector");

        //Fill Dictionary with Enum values and colors
        colors.Add(BasePlayer.element.None, Color.white);
        colors.Add(BasePlayer.element.Air, Color.green);
        colors.Add(BasePlayer.element.Earth, Color.grey);
        colors.Add(BasePlayer.element.Fire, Color.red);
        colors.Add(BasePlayer.element.Water, Color.blue);

        sprites.Add(BasePlayer.element.None, spritesImages[0]);
        sprites.Add(BasePlayer.element.Air, spritesImages[1]);
        sprites.Add(BasePlayer.element.Earth, spritesImages[2]);
        sprites.Add(BasePlayer.element.Fire, spritesImages[3]);
        sprites.Add(BasePlayer.element.Water, spritesImages[4]);


        image = this.GetComponent<Image>();
        image.sprite = sprites[0];

        EventManager.elementChanged += changeColor;
    }

    private void OnDisable()
    {
        EventManager.elementChanged -= changeColor;
    }

    private void changeColor(BasePlayer.element currentElement)
    {
        //image.color = colors[currentElement];
        image.sprite = sprites[currentElement];
    }
}
