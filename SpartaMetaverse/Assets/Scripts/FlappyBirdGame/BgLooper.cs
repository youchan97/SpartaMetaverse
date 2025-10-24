using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    [SerializeField] int numBgCount;
    [SerializeField] int obstacleCount;
    [SerializeField] Vector3 obstacleLastPos = Vector3.zero;
    [SerializeField] Obstacle[] obstacles;


    private void Start()
    {
        Init();
        if (obstacleCount == 0)
            return;
        SetObstaclesPos();
    }

    private void Init()
    {
        obstacles = GameObject.FindObjectsOfType<Obstacle>();
        if (obstacles != null)
        {
            obstacleLastPos = obstacles[0].transform.position;
            obstacleCount = obstacles.Length;
        }
    }

    private void SetObstaclesPos()
    {
        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPos = obstacles[i].SetRandomPlace(obstacleLastPos);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("BackGround"))
        {
            float widthBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }
        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if(obstacle)
            obstacleLastPos = obstacle.SetRandomPlace(obstacleLastPos);
    }
}
