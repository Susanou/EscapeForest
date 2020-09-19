using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{

    public float initialValue; //Value of the object (Stays the same throught the game)

    [HideInInspector] 
    public float RuntimeValue; //Value used during the game

    public void OnAfterDeserialize()
    {
        RuntimeValue = initialValue; //Reset value once the game stops
    }

    public void OnBeforeSerialize()
    {}

}