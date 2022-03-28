using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public enum MovementType
    {
        Moveing,
        Lerping
    }

    private Transform _target;
    public MovementType Type = MovementType.Moveing;
    public MovementPath MyPath;
    public float speed = 1;
    public float maxDistance = .1f;
    public int moveingTo = 0;
    public int movementDirection = 1;

    private IEnumerator<Transform> pointInPath;

    private void Start()
    {
        if (MyPath == null)
        {
            Debug.Log("Путь забыл");
            return;
        }

        pointInPath = GetNextPathPoint();

        pointInPath.MoveNext();

        if (pointInPath.Current == null)
        {
            Debug.Log("Точек нет");
            return;
        }

        transform.position = pointInPath.Current.position;
    }

    private void Update()
    {
        if (pointInPath == null || pointInPath.Current == null)
        {
            return;
        }

        if (Type == MovementType.Moveing)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        }
        else if (Type == MovementType.Lerping)
        {
            transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        }

        float distanceSquare = (transform.position - pointInPath.Current.position).sqrMagnitude;
        if (distanceSquare < maxDistance * maxDistance)
        {
            pointInPath.MoveNext();
        }

        _target = pointInPath.Current.transform;
        transform.eulerAngles = _target.transform.position.x > transform.position.x ? new Vector3(0, 180, 0) : new Vector3(0, 0, 0);
    }

    public IEnumerator<Transform> GetNextPathPoint()
    {
        if (MyPath.PathElements == null || MyPath.PathElements.Length < 1)
        {
            yield break;
        }

        while (true)
        {
            yield return MyPath.PathElements[moveingTo];

            if (MyPath.PathElements.Length == 1)
            {
                continue;
            }

            if (MyPath.PathType == MovementPath.PathTypes.linear)
            {
                if (moveingTo <= 0)
                {
                    movementDirection = 1;
                }
                else if (moveingTo >= MyPath.PathElements.Length - 1)
                {
                    movementDirection = -1;
                }
            }

            moveingTo = moveingTo + movementDirection;

            if (MyPath.PathType == MovementPath.PathTypes.loop)
            {
                if (moveingTo >= MyPath.PathElements.Length)
                {
                    moveingTo = 0;
                }

                if (moveingTo < 0)
                {
                    moveingTo = MyPath.PathElements.Length - 1;
                }
            }
        }
    }
}
