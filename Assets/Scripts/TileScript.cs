using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class TileScript : MonoBehaviour
{
    public UnityEvent<Building> OnTileClick;
    public UnityEvent<int> OnTileBuild;
    [SerializeField] private int index;
    [SerializeField] private GameObject mesh;

    public Tile Tile;




    void Start()
    {
        mesh = transform.gameObject;
    }

    public void ClearBuildEvent()
    {
        OnTileBuild.RemoveAllListeners();
    }

    public void CreateBuildingMesh(GameObject building)
    {
        mesh = Instantiate(building, transform.position, Quaternion.identity);
        mesh.transform.parent = transform;
    }


    private void OnMouseDown()
    {   
        OnTileBuild?.Invoke(index);
        if (Tile.Building != null)
        {
            OnTileClick?.Invoke(Tile.Building);
        }
    }


}
