using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class BuildStatsPanel : MonoBehaviour
{
    private Building building;
    [SerializeField] private TMP_Text nameText, levelText, typeText, populationText, incomeText;
    [SerializeField] private Button buildUpButton;
    [SerializeField] private Slider buildProgressSlider;

    private float sliderValue = 0;

    public void SetStats(Building building)
    {
        if (building == null)
            return;

        this.building = building;
        gameObject.SetActive(true);
        nameText.text = building.Name;
        levelText.text = "Level: " + building.Level.ToString();
        typeText.text = building.Type.ToString() + "District";

        if (!building.IsFinished)
        {
            populationText.text = "Population: 0";
            incomeText.text = "Income: 0";
        }
        else
        {
            populationText.text = "Population: " + building.Population.ToString();
            incomeText.text = "Income: " + building.Income.ToString();
        }

        buildUpButton.onClick.AddListener(building.BuildByClick);

    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }

    public void SliderUpdate()
    {
        sliderValue = (float)building.BuildPoints / (float)building.RequiredBuildPoints;
        if (buildProgressSlider.value < sliderValue)
        {
            buildProgressSlider.value += sliderValue * 0.0008f;
        }


    }

    private void Update()
    {
        if (building != null)
        {
            SliderUpdate();
        }
    }

    private void Start()
    {
        buildProgressSlider.value = 0;
    }


}
