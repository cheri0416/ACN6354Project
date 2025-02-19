using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Singleton for global access

    public TMPro.TextMeshProUGUI TxtScore;
    public TMPro.TextMeshProUGUI TxtScoreFinal;

    private int score = 0;

    public int distanceMultiplier = 1;

    private Transform player;

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

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        score = Mathf.FloorToInt(player.position.z * distanceMultiplier);
        TxtScore.text = score.ToString();
        TxtScoreFinal.text = score.ToString();
    }
}
