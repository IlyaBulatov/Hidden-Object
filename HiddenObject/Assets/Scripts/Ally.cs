using HiddenObjects;
using UnityEngine;

public class Ally : MonoBehaviour, ITouchable
{
    [SerializeField] private int secondsCount;
    private Timer timer;
    private void Start()
    {
        timer = FindObjectOfType<Timer>();
    }
    public void Touch()
    {
        timer.SetTime(-secondsCount);
        Destroy(gameObject);
    }
}