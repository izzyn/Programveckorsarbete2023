using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIScript : MonoBehaviour
{
    public Transform target;

    public float speed;
    public float wayPointDistance;

    Path objectPath;
    int currentWayPoint = 0;
    bool finishedPath = false;

    Seeker seeker;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void initiateSeeking()
    {
        seeker = this.gameObject.GetComponent<Seeker>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        followPlayerAction();

    }
    void followPlayerAction()
    {
        seeker.StartPath(rb.position, target.position, ReachedPlayer);
        StartCoroutine(pathTimer());
    }
    void ReachedPlayer(Path path)
    {
        if (!path.error)
        {
            objectPath = path;
            currentWayPoint = 0;
        }
    }
    IEnumerator pathTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            UpdatePath();
        }
    }
    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, ReachedPlayer);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (objectPath == null)
            return;
        if(currentWayPoint >= objectPath.vectorPath.Count)
        {
            finishedPath = true;
            return;
        }
        else
        {
            finishedPath = false;
        }

        Vector2 direction = (((Vector2)objectPath.vectorPath[currentWayPoint] - rb.position).normalized);
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, objectPath.vectorPath[currentWayPoint]);
        if(distance < wayPointDistance)
        {
            currentWayPoint++;
        }
    }
}
