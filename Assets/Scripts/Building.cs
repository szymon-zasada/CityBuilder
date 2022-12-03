using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Building
{
    public string Name;
    public int Level;
    public BuildingType Type;
    public int MoneyCost;
    public int Population;
    public int Income;
    public bool IsFinished = false;
    public int BuildPoints = 0;
    public int RequiredBuildPoints;


    public void BuildByClick()
    {
        BuildPoints++;
        if (BuildPoints >= RequiredBuildPoints)
            IsFinished = true;
        
    }

}

public enum BuildingType
{
    House,
    Farm,
    Mine,
    Barracks,
    Castle
}
