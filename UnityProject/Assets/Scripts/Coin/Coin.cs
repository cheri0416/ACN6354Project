using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) // Check if the player collides then increase coin
        {
            // increase the coin
            CoinManager.instance.AddCoin(coinValue);
            Destroy(gameObject);
        }
    }
}
