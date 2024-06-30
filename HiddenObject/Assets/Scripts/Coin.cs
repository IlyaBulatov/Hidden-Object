using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HiddenObjects;

public class Coin : MonoBehaviour, ITouchable
{
    [SerializeField] private int secondsCount;
    private Timer timer;
    private void Start()
    {
        timer = FindObjectOfType<Timer>();
    }
    public void Touch()
    {
        timer.SetTime(secondsCount);
        Destroy(gameObject);
    }
}