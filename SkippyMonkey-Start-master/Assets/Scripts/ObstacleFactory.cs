using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFactory : MonoBehaviour {
    public GameObject obstaclePrefab;
    public float widthScreen;
    public float heightScreen;

    private void Start()
    {
        float height = -375f;
        while (height<heightScreen)
        {
            height += 200;
            float width = Random.Range(-302, 100);
            GameObject newObstacle = Instantiate(
                obstaclePrefab,
                new Vector3(width, height, 0),
                Quaternion.identity
            );
            
        }
        
    }
}
