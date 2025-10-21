using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Database database;
    private int coins = 0;
    private int level1 = 0;
    private int level2 = 0;

    void Start()
    {
        var progress = database.LoadProgress();
        if (progress != null)
        {
            coins = progress.Coins;
            level1 = progress.Level1;
            level2 = progress.Level2;
            Debug.Log($"Progreso cargado: {coins} monedas, nivel1={level1}, nivel2={level2}");
        }
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        database.SaveProgress(coins, level1, level2);
    }

    public void CompleteLevel(int levelNumber)
    {
        if (levelNumber == 1) level1 = 1;
        if (levelNumber == 2) level2 = 1;
        database.SaveProgress(coins, level1, level2);
    }
}
