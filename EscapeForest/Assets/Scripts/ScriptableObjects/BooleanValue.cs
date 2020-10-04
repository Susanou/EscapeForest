using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BooleanValue : ScriptableObject, ISerializationCallbackReceiver
{

    public bool initialValue; //Value of the object (Stays the same throught the game)

    [HideInInspector] 
    public bool RuntimeValue; //Value used during the game

    public void OnAfterDeserialize()
    {
        RuntimeValue = initialValue; //Reset value once the game stops
    }

    public void OnBeforeSerialize()
    {}

}