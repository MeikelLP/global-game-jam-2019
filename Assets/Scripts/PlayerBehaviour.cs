using System;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float life = 100;

    public bool IsAlive => life > 0;
    
    public event EventHandler<EventArgs> OnDeath;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void ApplyDamage(float damage)
    {
        life -= damage;

        if (life <= 0)
        {
            OnDeath?.Invoke(this, null);
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0,0,200,30), life.ToString());
    }

    public static PlayerBehaviour Instance { get; private set; }
}
