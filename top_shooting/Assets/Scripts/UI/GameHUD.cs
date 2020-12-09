using UnityEngine.UI;

public class GameHUD : UI<GameHUD>
{
    public int Score { get; private set; }

    public void AddScore(int additionalScore)
    {
        Score += additionalScore;
        Vars["ScoreText"].GetComponent<Text>().text = $"Score: {Score}";
    }
}