using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingSelection : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Building building;
    [SerializeField] private GameObject buildingPrefab;


    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.MainCanvasScript.HideBuildingsPanel();
        GameManager.Instance.MainCanvasScript.ShowCancelButton();
        foreach (TileScript script in GameManager.Instance.TileScripts)
        {
            script.OnTileBuild.AddListener(BuildOnClick);

        }
    }


    public async void BuildOnClick(int index)
    {
        Debug.Log("BuildOnClick" + index);

        if (GameManager.Instance.TileScripts[index].Tile.Building == null)
        {
            GameManager.Instance.GameStats.Tiles[index].Building = building;
            GameManager.Instance.TileScripts[index].Tile.Building = building;
            GameManager.Instance.TileScripts[index].CreateBuildingMesh(buildingPrefab);
            GameManager.Instance.MainCanvasScript.CancelButtonEvent();
            await Task.Delay(300);
            GameManager.Instance.TileScripts[index].OnTileClick.AddListener(GameManager.Instance.MainCanvasScript.BuildStatsPanel.SetStats);
        }
    }
}
