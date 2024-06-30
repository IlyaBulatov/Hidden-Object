using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PointsHandler : MonoBehaviour
{
    public UnityEvent OnVictoryEvent;
    public Text PointsScore;
    public int PointsCount;
    public int StartValue = 0;
    public int maxValue;

    public int Score
    {
        get
        {
            return PointsCount;
        }
        set
        {
            PointsCount = Mathf.Clamp(value, 0, maxValue);
            PointsScore.text = $"{PointsCount.ToString()}/{maxValue}";

            if(PointsCount == maxValue)
            {
                Victory();
            }
        }
    }
    private void Start()
    {
        Score = StartValue;
    }
    private void Victory()
    {
        OnVictoryEvent?.Invoke();
    }
}