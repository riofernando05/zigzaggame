using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public GameObject ball;
    Vector3 offset;
    [SerializeField] private float lerpRate = 5f;
    [HideInInspector] public bool gameOver;

    void Start()
    {
        if (ball != null)
        {
            offset = transform.position - ball.transform.position; 
        }
        gameOver = false;
    }

    void Update()
    {
        if (!gameOver && ball != null)
        {
            Follow();
        }
    }
    
    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = ball.transform.position + offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}