using System;
using System.Collections.Generic;
using System.IO;
using SQLite4Unity3d;
using UnityEngine;

public class Database : MonoBehaviour
{
    private SQLiteConnection db;

    void Awake()
    {
        string dbPath = Path.Combine(Application.persistentDataPath, "gameData.db");
        db = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        db.CreateTable<PlayerProgress>();
        Debug.Log("Base de datos creada en: " + dbPath);
    }

    public void SaveProgress(int coins, int level1, int level2)
    {
        PlayerProgress progress = new PlayerProgress
        {
            Id = 1,
            Coins = coins,
            Level1 = level1,
            Level2 = level2
        };
        db.InsertOrReplace(progress);
        Debug.Log("Progreso guardado correctamente.");
    }

    public PlayerProgress LoadProgress()
    {
        return db.Find<PlayerProgress>(1);
    }
}

public class PlayerProgress
{
    [PrimaryKey]
    public int Id { get; set; }
    public int Coins { get; set; }
    public int Level1 { get; set; }
    public int Level2 { get; set; }
}
