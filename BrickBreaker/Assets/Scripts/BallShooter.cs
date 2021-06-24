using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BallShooter : MonoBehaviour
{
    public static UnityAction OnStartShooting;
    public static UnityAction OnBallShoot;

    public float InitialForce = 10.0f;
    public GameObject Prefab_Ball;
    public GameObject Prefab_BallShootingDirection;
    public int BallCount = 10;

    public GameObject BallStartPos;
    public GameObject BallEndPos;

    private GameObject BallShootingDirection;
    private bool ActiveTurn = true;
    private Coroutine ShootCoRoutine;
    private bool bCollectingBalls = false;
    private Vector3 ShootingDirection = Vector3.up;

    private BallsBucket bucket = new BallsBucket();

    private void Awake()
    {
        BallCollector.OnFirstBallHitCollector += FirstBallReached;
        BallCollector.OnBallHitCollector += CollectBall;
        Ball.OnBallCollected += OnBallCollected;
        BallsBucket.OnAllBallsCollected += OnAllBallsCollected;
    }
    void Start()
    {
        BallStartPos.transform.position = transform.position;
        BallEndPos.transform.position = transform.position;

        BallShootingDirection = Instantiate(Prefab_BallShootingDirection, transform);
        BallShootingDirection.SetActive(false);

        bucket.FillBucket(Prefab_Ball, transform);
    }

    IEnumerator ShootBall(Vector3 direction)
    {
        foreach (GameObject ball in bucket.Balls)
        {
            ball.SetActive(true);
            ball.GetComponent<Ball>().ShootInDirection(BallStartPos.transform.position, direction, InitialForce);
            OnBallShoot?.Invoke();
            yield return new WaitForSeconds(0.1f);
        }
        BallStartPos.SetActive(false);
    }

    public void FirstBallReached(GameObject _gameObject)
    {
        Vector3 newPos = BallStartPos.transform.position;
        newPos.x = _gameObject.transform.position.x;
        BallEndPos.transform.position = newPos;
        BallEndPos.SetActive(true);
    }

    public void CollectBall(GameObject _gameObject)
    {
        _gameObject.GetComponent<Ball>().ReturnToBasket(BallEndPos.transform.position);
    }

    public void OnBallCollected()
    {
        if (bucket.IsFull)
        {
            BallStartPos.transform.position = BallEndPos.transform.position;
            BallStartPos.SetActive(true);
            BallEndPos.SetActive(false);
            ActiveTurn = true;
            bCollectingBalls = false;
            GameSpeedController.SpeedReset();
        }
    }

    public void CollectAllBalls()
    {
        if (ActiveTurn)
            return;

        bCollectingBalls = true;
        if (ShootCoRoutine != null)
        {
            StopCoroutine(ShootCoRoutine);
            ShootCoRoutine = null;
        }
        Vector3 pos = BallEndPos.transform.position;
        if (BallEndPos.activeSelf == false)
        {
            pos = BallStartPos.transform.position;
        }
        bucket.CollectAllBalls(pos);
    }

    public void OnAllBallsCollected()
    {
        bCollectingBalls = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!ActiveTurn || bCollectingBalls == true)
            return;

        if (Input.GetMouseButton(0))
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = transform.position.z;
            Vector3 direction = Vector3.Normalize(mouseWorldPosition - BallStartPos.transform.position);
            BallShootingDirection.SetActive(true);
            BallShootingDirection.transform.position = BallStartPos.transform.position;
            BallShootingDirection.GetComponent<ShootingDirection>().Direction = direction;
            Quaternion q = Quaternion.LookRotation(new Vector3(0.0f, 0.0f, 1.0f), direction);
            float fZAngle = q.eulerAngles.z;
            if (fZAngle < 87.0f || fZAngle > 273.0f)
            {
                ShootingDirection = direction;
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            ActiveTurn = false;
            OnStartShooting?.Invoke();
            BallShootingDirection.SetActive(false);
            ShootCoRoutine = StartCoroutine(ShootBall(ShootingDirection));
        }
    }

    private void FixedUpdate()
    {

    }

}
