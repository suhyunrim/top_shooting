using UnityEngine.UI;

public class MainMenu : UI<MainMenu>
{
    protected override void Awake()
    {
        base.Awake();

        Vars["GameStartButton"].GetComponent<Button>().onClick.AddListener(() =>
        {
            GameScene.Instance.StartGame();
        });
    }
}