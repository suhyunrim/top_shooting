using UnityEngine.UI;

public class GameHUD : UI<GameHUD>
{
    private int score;

    public void AddScore(int additionalScore)
    {
        score += additionalScore;
        Vars["ScoreText"].GetComponent<Text>().text = $"Score: {score}";
    }
}