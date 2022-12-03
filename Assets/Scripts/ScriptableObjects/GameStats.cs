using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameStats", menuName = "ScriptableObjects/GameStats", order = 1)]
public class GameStats : ScriptableObject
{
    [SerializeField] private List<Tile> tiles = new List<Tile>();
    [SerializeField] private int mapSize = 16;
    [SerializeField] private int money = 100;
    [SerializeField] private int population = 0;
    [SerializeField] private int reborn = 0;


    public List<Tile> Tiles => tiles;
    public int MapSize => mapSize;
    public int Money => money;
    public int Population => population;
    public int Reborn => reborn;

}
