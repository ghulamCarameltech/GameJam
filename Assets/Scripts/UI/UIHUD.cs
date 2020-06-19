using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHUD : MonoBehaviour
{
    public enum ShootType {Perfect, Good, Nice, Missed};

    [SerializeField]
    private TextMeshProUGUI _gaugeResult;

    [SerializeField]
    GameObject _gauge;

    [SerializeField]
    private UIManager uIManager;

    void OnEnable()
    {
         InputController.onTap += StopGauge;
    }

    void OnDisable()
    {
         InputController.onTap -= StopGauge;
    }

    private void StopGauge()
    {
        Animator animator = _gauge.GetComponent<Animator>();
        animator.enabled = false;
        UpdateGaugeStatus();
    }

    private void UpdateGaugeStatus()
    {
        int postion = (int)_gauge.transform.GetChild(0).transform.localPosition.x;
        if((postion <= -186 && postion >= -312) || (postion >= 203 && postion <= 328))
        {
            EventManager.RaiseShootEvent(ShootType.Missed);
            UpdateShootTypeHUD(ShootType.Missed);
        }
        else if((postion <= -70 && postion >= -185) || (postion >= 88 && postion <= 202))
        {
            EventManager.RaiseShootEvent(ShootType.Nice);
            UpdateShootTypeHUD(ShootType.Nice);
        }
        else if((postion <= -8 && postion >= -69) || (postion >= 7 && postion <= 87))
        {
            EventManager.RaiseShootEvent(ShootType.Good);
            UpdateShootTypeHUD(ShootType.Good);
        }
        else
        {
            EventManager.RaiseShootEvent(ShootType.Perfect);
            UpdateShootTypeHUD(ShootType.Perfect);
        }
    }

    private void UpdateShootTypeHUD(ShootType type)
    {
        switch (type)
        {
            case ShootType.Perfect:
            _gaugeResult.text = string.Format("Perfect Shoot!");
            break;

            case ShootType.Good:
            _gaugeResult.text = string.Format("Good Shoot!");
            break;

            case ShootType.Nice:
            _gaugeResult.text = string.Format("Nice Shoot!");
            break;

            case ShootType.Missed:
            _gaugeResult.text = string.Format("Missed!");
            break;
        }
    }

    public void BackButton()
    {
        if(InputController.Enable)
            uIManager.ShowScreen(UIManager.UIs.Back);
    }
}

