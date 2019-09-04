﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class FloatValue : ScriptableObject{

    public float initialValue;
    
    public float RunTimeValue;
    /*
    public void OnBeforeSerialize()
    {
        
    }

    public void OnAfterDeserialize()
    {
        RunTimeValue = initialValue;
    }*/
}
