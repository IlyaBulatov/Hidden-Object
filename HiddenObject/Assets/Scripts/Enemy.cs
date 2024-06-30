using HiddenObjects;
using UnityEngine;

public class Enemy : MonoBehaviour, ITouchable
{
    [SerializeField] private int points;
    private PointsHandler pointsHandler;
    private void Start()
    {
        pointsHandler = FindObjectOfType<PointsHandler>();
    }
    public void Touch()
    {
        pointsHandler.Score += points;
        Destroy(gameObject);
    }
}