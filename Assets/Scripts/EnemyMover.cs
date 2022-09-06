using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Now Focussing on a graph theory approach
[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField][Range(0f, 5f)] float speed = 1f;
    Enemy enemy;

    bool finishedJourney = false;
    void OnEnable()
    {
        //Debug.Log("Inside Enemy Mover Script");
        enemy = GetComponent<Enemy>();
        FindPath();
        returnToStart();
        StartCoroutine(FollowPath());

    }

    void FindPath()
    {
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach (Transform child in parent.transform)
        {
            WayPoint wayPoint = child.GetComponent<WayPoint>();
            if (wayPoint != null)
            {
                path.Add(wayPoint);
            }
        }
    }

    void returnToStart()
    {
        transform.position = path[0].transform.position;
    }
    void Update()
    {
        //Debug.Log(gameObject.name);

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
        EndOfThePathActions();
    }

    private void EndOfThePathActions()
    {
        finishedJourney = true;
        enemy.stealGold();
        gameObject.SetActive(false);
    }
}
