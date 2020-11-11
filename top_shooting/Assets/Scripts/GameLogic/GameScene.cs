using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : Singleton<GameScene>
{
    public bool IsPlaying { get; private set; }

    [SerializeField]
    private SpawnManager spawnManager;

    [SerializeField]
    private Player player;

    protected override void Awake()
    {
        base.Awake();

        SetPlayComponent(false);
    }

    public void StartGame()
    {
        var playerSequence = DOTween.Sequence();
        playerSequence.Append(player.transform.DOMoveY(-4f, 2f).SetEase(Ease.InCirc, 1.5f));
        playerSequence.AppendCallback(() =>
        {
            IsPlaying = true;
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
        player.enabled = isOn;
        GameHUD.Instance.gameObject.SetActive(isOn);
    }
}