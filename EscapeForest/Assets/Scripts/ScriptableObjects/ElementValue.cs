﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Element", menuName = "Values/Element", order = 1)]
public class ElementValue : ScriptableObject, ISerializationCallbackReceiver
{

    public BasePlayer.element initialValue; //Value of the object (Stays the same throught the game)

    [HideInInspector] 
    public BasePlayer.element RuntimeValue; //Value used during the game

    public void OnAfterDeserialize()
    {
        RuntimeValue = initialValue; //Reset value once the game stops
    }

    public void OnBeforeSerialize()
    {}

}