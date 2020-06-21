﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHUD : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _gaugeResult;

    [SerializeField]
    GameObject _gauge;

    [SerializeField]
    private TextMeshProUGUI _tileCollectedResult;

    [SerializeField]
    GameObject _tilesToCollect;

    [SerializeField]
    private TextMeshProUGUI _timer;

    [SerializeField]
    GameObject _stackingTimer;

    [SerializeField]
    private UIManager uIManager;

    void OnEnable()
    {
        _gauge.SetActive(false);
        _tilesToCollect.SetActive(false);
        _stackingTimer.SetActive(false);
        
        if(Game.currentLevelIndex == 1)
        {
            _gauge.SetActive(true);
            Animator animator = _gauge.GetComponent<Animator>();
            animator.enabled = true;
            _gaugeResult.text = "";
            InputController.onTap += StopGauge;
        }
        else if(Game.currentLevelIndex == 2)
        {
            EventManager.OnTileCollected += UpdateTileScoreUI;
            _tilesToCollect.SetActive(true);
        }
        else if(Game.currentLevelIndex == 3)
        {
            EventManager.OnTimerTick += UpdateTimerUI;
            _stackingTimer.SetActive(true);
        }
         InputController.onBack += BackButton;
         RunnerInputController.onBack += BackButton;
    }

    void OnDisable()
    {
        EventManager.OnTileCollected -= UpdateTileScoreUI;
        EventManager.OnTimerTick -= UpdateTimerUI;
        InputController.onTap -= StopGauge;
        InputController.onBack -= BackButton;
        RunnerInputController.onBack -= BackButton;
    }

    private void StopGauge()
    {
        Animator animator = _gauge.GetComponent<Animator>();
        animator.enabled = false;
        UpdateGaugeStatus();
    }

    private void UpdateGaugeStatus()
    {
        int postion = Mathf.Abs((int)_gauge.transform.GetChild(0).transform.localPosition.x);
        if((postion >= 199 && postion <= 328))
        {
            EventManager.RaiseShootEvent(Game.ShootType.Missed);
            UpdateShootTypeHUD(Game.ShootType.Missed);
        }
        else if((postion >= 81 && postion <= 198))
        {
            EventManager.RaiseShootEvent(Game.ShootType.Nice);
            UpdateShootTypeHUD(Game.ShootType.Nice);
        }
        else if(postion >= 16 && postion <= 80)
        {
            EventManager.RaiseShootEvent(Game.ShootType.Good);
            UpdateShootTypeHUD(Game.ShootType.Good);
        }
        else
        {
            EventManager.RaiseShootEvent(Game.ShootType.Perfect);
            UpdateShootTypeHUD(Game.ShootType.Perfect);
        }
    }

    private void UpdateShootTypeHUD(Game.ShootType type)
    {
        switch (type)
        {
            case Game.ShootType.Perfect:
            _gaugeResult.text = string.Format("Perfect Throw!");
            break;

            case Game.ShootType.Good:
            _gaugeResult.text = string.Format("Good Throw!");
            break;

            case Game.ShootType.Nice:
            _gaugeResult.text = string.Format("Nice Throw!");
            break;

            case Game.ShootType.Missed:
            _gaugeResult.text = string.Format("Missed!");
            break;
        }
    }

    void UpdateTileScoreUI(int value)
    {
        _tileCollectedResult.text = string.Format("{0}",value);
    }

    void UpdateTimerUI(int value)
    {
        _timer.text = string.Format("{0}",value);
    }

    public void BackButton()
    {
        if(InputController.Enable)
            uIManager.ShowScreen(UIManager.UIs.Back);
    }
}

