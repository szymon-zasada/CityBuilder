using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
    
    [SerializeField] private MainCanvasScript mainCanvasScript;
    [SerializeField] private GameStats gameStats;
    [SerializeField] private List<TileScript> tileScripts = new List<TileScript>();
    [SerializeField] private int mapSize = 16;


    public MainCanvasScript MainCanvasScript => mainCanvasScript;
    public GameStats GameStats => gameStats;
    public List<TileScript> TileScripts => tileScripts;



    void Start()
    {
        GetTiles();
    
    }

    void GetTiles() {

        GameStats.Tiles.Clear();

        for (int i = 0; i < mapSize; i++)
        {
            GameStats.Tiles.Add(new Tile());
        }

        GameObject tileList = GameObject.Find("Tiles");
        foreach(Transform child in tileList.transform) {
            tileScripts.Add(child.GetComponent<TileScript>());
        }

        for(int i = 0; i < GameStats.Tiles.Count; i++) {
            tileScripts[i].Tile = GameStats.Tiles[i];
        }
    }

   
    void Update()
    {
        
    }
}
