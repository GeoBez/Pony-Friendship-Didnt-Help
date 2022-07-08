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
    private float speed = 1;
    private float defaultSpeed;
    public float maxDistance = .1f;
    public int moveingTo = 0;
    public int movementDirection = 1;

    private Enemy thisEnemy;

    private IEnumerator<Transform> pointInPath;

    private Animator _animator;

    float distance=1000;
    GameObject[] Tower_Enemy_Spawners;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        if (MyPath == null)
        {
            Debug.Log("���� �����");
            Find_Path();
        }

        pointInPath = GetNextPathPoint();

        pointInPath.MoveNext();

        if (pointInPath.Current == null)
        {
            Debug.Log("����� ���");
            return;
        }
        thisEnemy = GetComponent<Enemy>();
        speed = thisEnemy.Speed;

        transform.position = pointInPath.Current.position;
        defaultSpeed = speed;
    }

    private void Update()
    {
        if (pointInPath == null || pointInPath.Current == null)
        {
            return;
        }
        if (Type == MovementType.Moveing)
        {
            thisEnemy.Rigidbody2D.MovePosition(Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed));
        }
        else if (Type == MovementType.Lerping)
        {
            thisEnemy.Rigidbody2D.MovePosition(Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * speed));
        }
        _animator.SetBool("isWalking", true);
        float distanceSquare = (transform.position - pointInPath.Current.position).sqrMagnitude;
        if (distanceSquare < maxDistance * maxDistance)
        {
            pointInPath.MoveNext();
        }

        if (thisEnemy.FreezeAttac)
        {
            speed = 0;
            _animator.SetBool("isWalking", false);
        }
        else
        {
            speed = defaultSpeed;
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
            if (moveingTo >= MyPath.PathElements.Length && MyPath.PathType == MovementPath.PathTypes.linear)
            {
                break;            }

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

                /*else 
                if (moveingTo >= MyPath.PathElements.Length - 1)
                {
                    movementDirection = -1;
                }*/
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

    void Find_Path()
    {
        Tower_Enemy_Spawners = GameObject.FindGameObjectsWithTag("Tower Enemy Spawn");
        for (int i = 0; i < Tower_Enemy_Spawners.Length; i++)
        {
            if (Vector2.Distance(Tower_Enemy_Spawners[i].transform.position, transform.position) < distance)
            {
                distance = Vector2.Distance(Tower_Enemy_Spawners[i].transform.position, transform.position);
                MyPath = Tower_Enemy_Spawners[i].GetComponentInChildren<MovementPath>();
            }
        }
    }
}
