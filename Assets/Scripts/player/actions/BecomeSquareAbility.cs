using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BecomeSquareAbility : MonoBehaviour
{
    PlayerObjectController playerObjectController;

    [DoNotSerialize]
    public bool IsCircle = true;
    public float AbilityTaker = 0.1f;
    public float AbilityCooldown = 10.0f;

    public float AbilityUsage = 1.0f;
    float AbilityUsageNextTime = 0.0f;


    void Start()
    {
        playerObjectController = GetComponent<camera_movement>().player.GetComponent<PlayerObjectController>();
    }

    void Update()
    {
        bool previous_state = IsCircle;
        var x = Input.GetAxisRaw("Fire3");

        if (x != 0.0f && Time.time>=AbilityUsageNextTime)
        {
            AbilityUsage = Mathf.Clamp(AbilityUsage - (AbilityTaker * Time.deltaTime), 0.0f, 1.0f);

            if(AbilityUsage == 0.0f)
            {
                AbilityUsageNextTime = Time.time + AbilityCooldown;
                IsCircle = true;
                AbilityUsage = 1.0f;
            }
            else
            {
                IsCircle = false;
            }
        }
        else
        {
            
            if (AbilityUsage < 1.0f)
            {
                IsCircle = true;
                AbilityUsage = Mathf.Clamp(AbilityUsage + (AbilityTaker * Time.deltaTime), 0.0f, 1.0f);
            }
        }

        if (previous_state != IsCircle)
        {
            if (IsCircle)
            {
                playerObjectController.Square.SetActive(true);
                playerObjectController.Circle.SetActive(false);

                playerObjectController.Square.transform.localScale = Vector3.one;
                playerObjectController.Circle.transform.localScale = Vector3.zero;
            }
            else
            {
                playerObjectController.Square.SetActive(false);
                playerObjectController.Circle.SetActive(true);

                playerObjectController.Square.transform.localScale = Vector3.zero;
                playerObjectController.Circle.transform.localScale = Vector3.one;
            }
        }

    }
}
