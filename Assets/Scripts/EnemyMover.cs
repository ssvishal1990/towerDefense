using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField][Range(0f, 5f)] float speed = 1f;

    bool finishedJourney = false;
    void OnEnable()
    {
        Debug.Log("Inside Enemy Mover Script");
        FindPath();
        returnToStart();
        StartCoroutine(FollowPath());

    }

    void FindPath()
    {
        path.Clear();
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");
        foreach (GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<WayPoint>());
        }
    }

    void returnToStart()
    {
        transform.position = path[0].transform.position;
    }
    void Update()
    {
        if (finishedJourney)
        {
            finishedJourney = false;
            StartCoroutine(FollowPath());
        }
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
        finishedJourney = true;
        //returnToStart();
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
