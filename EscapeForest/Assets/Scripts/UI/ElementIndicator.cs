using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementIndicator : MonoBehaviour
{
    private Image image;
    [SerializeField]  private  Sprite[] spritesImages = new Sprite[5];
    [SerializeField] private Material[] elementMaterials = new Material[5];

    private Dictionary<BasePlayer.element, Color> colors = new Dictionary<BasePlayer.element, Color>();
    private Dictionary<BasePlayer.element, Sprite> sprites = new Dictionary<BasePlayer.element, Sprite>();
    private Dictionary<BasePlayer.element, Material> materials = new Dictionary<BasePlayer.element, Material>();

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

        materials.Add(BasePlayer.element.None, elementMaterials[0]);
        materials.Add(BasePlayer.element.Air, elementMaterials[1]);
        materials.Add(BasePlayer.element.Earth, elementMaterials[2]);
        materials.Add(BasePlayer.element.Fire, elementMaterials[3]);
        materials.Add(BasePlayer.element.Water, elementMaterials[4]);


        image = this.GetComponent<Image>();
        image.sprite = sprites[0];
    }

    public void changeColor()
    {
        BasePlayer player = GameObject.Find("Player").GetComponent<BasePlayer>();
        //image.color = colors[currentElement];
        //image.sprite = sprites[player.getCurrentElement()];
        image.sprite = sprites[player.currentElement.RuntimeValue];
        //player.particle.startColor = colors[player.getCurrentElement()];
        player.particle.startColor = colors[player.currentElement.RuntimeValue];

        player.particle.GetComponent<ParticleSystemRenderer>().material = materials[player.currentElement.RuntimeValue];
    }
}
