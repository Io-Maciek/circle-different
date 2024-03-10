using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BecomeSquareAbility : MonoBehaviour
{
    PlayerObjectController playerObjectController;

    [DoNotSerialize]
    public bool IsCircle = true;
    public float AbilitySubtracter = 0.5f;
    public float AbilityAdder = 1.0f;
    //public float AbilityCooldown = 10.0f;


    float _ability_usage = 1.0f;

    public float AbilityUsage
    {
        get => _ability_usage;
        set
        {
            _ability_usage = value;
            AbilitySliderMeter.value = value;
        }
    }
    //float AbilityUsageNextTime = 0.0f;

    public Slider AbilitySliderMeter;

    public bool IsPenalty = false;


    void Start()
    {
        playerObjectController = GetComponent<camera_movement>().player.GetComponent<PlayerObjectController>();
    }

    void Update()
    {
        bool previous_state = IsCircle;
        var x = Input.GetAxisRaw("Fire3");

        if (x > 0.0f && !IsPenalty) // && Time.time>=AbilityUsageNextTime
        {
            AbilityUsage = Mathf.Clamp(AbilityUsage - (AbilityAdder * Time.deltaTime), 0.0f, 1.0f);

            if(AbilityUsage == 0.0f)
            {
                //AbilityUsageNextTime = Time.time + AbilityCooldown;
                IsCircle = true;
                IsPenalty = true;
            }
            else
            {
                IsCircle = false;
            }
            //UpdateMeterUI();
            ShowMeterUI();
        }
        else
        {
            
            if (AbilityUsage < 1.0f)
            {
                IsCircle = true;
                AbilityUsage = Mathf.Clamp(AbilityUsage + (AbilitySubtracter * Time.deltaTime), 0.0f, 1.0f);
                //UpdateMeterUI();
            }
            else 
            {
                HideMeterUI();
                if (IsPenalty)
                    IsPenalty = false;
            }
        }

        if (previous_state != IsCircle)
        {
            Change(previous_state);
        }
    }

    void Change(bool ShouldBecomeCircle)
    {
        try
        {
            playerObjectController.animator.SetBool("IsCircle", !ShouldBecomeCircle);
        }catch(MissingReferenceException) { }
    }

    void UpdateMeterUI()
    {
        AbilitySliderMeter.value = AbilityUsage;
    }

    void HideMeterUI()
    {
        if(AbilitySliderMeter.gameObject.activeSelf)
            AbilitySliderMeter.gameObject.SetActive(false);
    }

    void ShowMeterUI()
    {
        if (!AbilitySliderMeter.gameObject.activeSelf)
            AbilitySliderMeter.gameObject.SetActive(true);
    }

}
