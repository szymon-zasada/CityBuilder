using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasScript : MonoBehaviour
{
    [SerializeField] private GameObject buildingsPanel, buildStatsPanel, cancelButton;
    [SerializeField] private BuildStatsPanel buildStatsPanelScript;

    public BuildStatsPanel BuildStatsPanel => buildStatsPanelScript;
    public GameObject BuildingsPanel => buildingsPanel;
    public GameObject BuildStatsPanelObject => buildStatsPanel;

    public void ShowBuildingsPanel() {
        buildingsPanel.SetActive(true);
    }

    public void HideBuildingsPanel() {
        buildingsPanel.SetActive(false);
    }

    public void ShowCancelButton() {
        cancelButton.SetActive(true);
    }

    public void HideCancelButton() {
        cancelButton.SetActive(false);
    }

    public void CancelButtonEvent() {
        foreach(TileScript script in GameManager.Instance.TileScripts) {
            script.ClearBuildEvent();
            HideCancelButton();
        }
    }
}
