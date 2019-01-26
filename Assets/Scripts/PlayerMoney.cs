using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private Text gui;
    public int Money { get; private set; }

    private void Start()
    {
        gui.text = Money.ToString();
    }

    private void OnEnable()
    {
        EnemyHealth.OnDeathAny += EnemyHealthOnOnDeathAny;
    }

    private void OnDisable()
    {
        EnemyHealth.OnDeathAny -= EnemyHealthOnOnDeathAny;
    }

    private void EnemyHealthOnOnDeathAny(object sender, EnemyDeathEventArgs e)
    {
        Money += e.Enemy.money;
        gui.text = Money.ToString();
    }

    public bool RemoveMoney(int amount)
    {
        if (Money - amount < 0)
        {
            return false;
        }

        Money -= amount;

        return true;
    }
}
