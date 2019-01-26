using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerShooting))]
public class ComboBehaviour : MonoBehaviour
{
    [SerializeField] private float comboTime = 5;
    [SerializeField] private Text text;
    [SerializeField] private Slider slider;
    
    private PlayerShooting _player;

    public float CurrentTime { get; private set; }
    public int CurrentCombo { get; private set; }

    public event EventHandler<ComboEventArgs> OnGainedCombo;
    public event EventHandler<ComboEventArgs> OnLostCombo; 


    void Start()
    {
        _player = GetComponent<PlayerShooting>();
        EnemyHealth.OnDeathAny += EnemyHealthOnOnDeathAny;

        StartCoroutine(WaitForCombo());
    }

    private IEnumerator WaitForCombo()
    {
        while (true)
        {
            slider.gameObject.SetActive(true);
            text.gameObject.SetActive(true);
            while (CurrentTime > 0)
            {
                CurrentTime -= Time.deltaTime;
                slider.value = CurrentTime / comboTime;
                yield return new WaitForEndOfFrame();
            }

            OnLostCombo?.Invoke(this, new ComboEventArgs{Combo = 0, Player = _player});
            CurrentCombo = 0;
            slider.gameObject.SetActive(false);
            text.gameObject.SetActive(false);
            yield return new WaitUntil(() => CurrentCombo > 0);
        }
    }

    private void EnemyHealthOnOnDeathAny(object sender, EventArgs e)
    {
        CurrentCombo++;
        CurrentTime = comboTime;
        text.text = $"Combo: {CurrentCombo.ToString()}";
        OnGainedCombo?.Invoke(this, new ComboEventArgs{Combo = CurrentCombo, Player = _player});
    }
}