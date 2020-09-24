using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorByElement : MonoBehaviour
{
    Image image;

    private Dictionary<BasePlayer.element, Color> colors = new Dictionary<BasePlayer.element, Color>();

    //Events must be subscribed += and unsubscribed to -= on enable and disable to prevent memory errors
    private void OnEnable()
    {
        //Fill Dictionary with Enum values and colors
        colors.Add(BasePlayer.element.None, Color.white);
        colors.Add(BasePlayer.element.Air, Color.green);
        colors.Add(BasePlayer.element.Earth, Color.grey);
        colors.Add(BasePlayer.element.Fire, Color.red);
        colors.Add(BasePlayer.element.Water, Color.blue);


        image = this.GetComponent<Image>();

        EventManager.elementChanged += changeColor;
    }

    private void OnDisable()
    {
        EventManager.elementChanged -= changeColor;
    }

    private void changeColor(BasePlayer.element currentElement)
    {
        image.color = colors[currentElement];
    }
}
