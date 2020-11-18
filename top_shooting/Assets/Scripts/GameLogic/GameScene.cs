using DG.Tweening;
using UnityEngine;

public class GameScene : Singleton<GameScene>
{
    public bool IsPlaying { get; private set; }

    [SerializeField]
    private SpawnManager spawnManager;

    protected override void Awake()
    {
        base.Awake();

        TableLoader.LoadAllData();

        SetPlayComponent(false);
    }

    public void StartGame()
    {
        MainMenu.Instance.gameObject.SetActive(false);

        var playerPrefab = Resources.Load("Prefabs/Player") as GameObject;
        var playerObject = Instantiate(playerPrefab);
        playerObject.GetComponent<Player>().enabled = false;

        var playerSequence = DOTween.Sequence();
        playerSequence.Append(playerObject.transform.DOMoveY(-4f, 2f).SetEase(Ease.InCirc, 1.5f));
        playerSequence.AppendCallback(() =>
        {
            IsPlaying = true;
            playerObject.GetComponent<Player>().enabled = true;
            SetPlayComponent(true);
        });
    }

    public void GameOver()
    {
        IsPlaying = false;
        SetPlayComponent(false);
    }

    private void SetPlayComponent(bool isOn)
    {
        spawnManager.enabled = isOn;
        GameHUD.Instance.gameObject.SetActive(isOn);
        MainMenu.Instance.gameObject.SetActive(!isOn);
    }
}