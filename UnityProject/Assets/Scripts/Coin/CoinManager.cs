using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance; // Singleton for global access

    public TMPro.TextMeshProUGUI TxtCoin;

    private int totalCoins = 0;

    private void Awake()
    {
        if(instance == null)
        {
        instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoin(int amount)
    {
        totalCoins += amount; // totalCoins = totalCoins + amount
        TxtCoin.text = totalCoins.ToString();
    }
}
