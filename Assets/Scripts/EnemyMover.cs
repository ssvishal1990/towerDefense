using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField][Range(0f, 5f)] float speed = 1f;
    void Start()
    {
        Debug.Log("Inside Enemy Mover Script");
        StartCoroutine(FollowPath());
    }

    void Update()
    {
        
    }

    IEnumerator FollowPath()
    {

        foreach (WayPoint wayPoint in path)
        {
            //Debug.Log(wayPoint.name);
            Vector3 startPosition = transform.position;
            Vector3 endPosition = wayPoint.gameObject.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);
            while (travelPercent < 1)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
            
        }
    }
}
