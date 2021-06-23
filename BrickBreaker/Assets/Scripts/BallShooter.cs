using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallShooter : MonoBehaviour
{
    public float InitialForce = 10.0f;
    public GameObject Prefab_Ball;
    public GameObject Prefab_BallShootingDirection;
    public int BallCount = 10;

    private int ActiveBallCounter = 0;
    private GameObject BallInstance;
    private GameObject BallShootingDirection;
    private List<GameObject> Balls = new List<GameObject>();
    private bool ActiveTurn = true;
    private Vector3 StartPos;
    private Coroutine ShootCoRoutine;
    private bool bCollectingBalls = false;
    private Vector3 ShootingDirection = Vector3.up;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
        BallInstance = Instantiate(Prefab_Ball, transform);
        BallInstance.name = "Shooting POS";
        BallInstance.GetComponent<CircleCollider2D>().enabled = false;
        BallInstance.SetActive(true);
        BallInstance.GetComponent<SpriteRenderer>().color = new Color(0.0f, 1.0f, 1.0f, 1.0f);

        BallShootingDirection = Instantiate(Prefab_BallShootingDirection, transform);
        BallShootingDirection.SetActive(false);

        for (int i = 0; i < BallCount; i++)
        {
            GameObject ball = Instantiate(Prefab_Ball, transform);
            ball.SetActive(false);
            ball.name = "Ball " + i.ToString();
            Balls.Add(ball);
        }
    }

    IEnumerator ShootBall(Vector3 direction)
    {
        ActiveBallCounter = 0;
        foreach (GameObject ball in Balls)
        {
            ball.transform.position = StartPos + direction * 0.15f;
            ball.SetActive(true);
            ball.GetComponent<Collider2D>().enabled = true;
            ball.GetComponent<Rigidbody2D>().gravityScale = 0.003f;
            ball.GetComponent<Rigidbody2D>().AddForce(direction * InitialForce);
            ActiveBallCounter++;
            yield return new WaitForSeconds(0.1f);
        }
        BallInstance.SetActive(false);
    }

    public void CollectBall(GameObject _gameObject)
    {
        if (ActiveBallCounter == BallCount)
        {
            StartPos.x = _gameObject.transform.position.x;
            BallInstance.transform.position = StartPos;
        }
        StartCoroutine(CollectBallRoutine(_gameObject, StartPos));
    }

    private IEnumerator CollectBallRoutine(GameObject _gameObject, Vector3 pos)
    {
        _gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.00f;
        _gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        _gameObject.GetComponent<Collider2D>().enabled = false;
        while (Vector3.Distance(_gameObject.transform.position, pos) > 0.01f)
        {
            _gameObject.transform.position = Vector3.Lerp(_gameObject.transform.position, pos, 10.0f*Time.deltaTime);
            yield return null;
        }
        _gameObject.transform.position = pos;
        
        _gameObject.SetActive(false);
        _gameObject.name = _gameObject.name + " cd";
        BallInstance.SetActive(true);
        ActiveBallCounter--;
        if (ActiveBallCounter == 0)
        {
            ActiveTurn = true;
            GameSpeedController.SpeedReset();
        }
        yield return null;
    }

    public void CollectAllBalls()
    {
        bCollectingBalls = true;
        if (ShootCoRoutine != null)
            StopCoroutine(ShootCoRoutine);
        StartCoroutine(CollectBalls(StartPos));
    }

    IEnumerator CollectBalls(Vector3 pos)
    {
        foreach (GameObject ball in Balls)
        {
            if (ball.activeSelf == true && ball.GetComponent<Rigidbody2D>().velocity != Vector2.zero)
            {
                StartCoroutine(CollectBallRoutine(ball, pos));
            }
        }
        yield return new WaitForSeconds(1.0f);
        Debug.Log(ActiveBallCounter);
        Debug.Assert(ActiveBallCounter == 0);
        Debug.Assert(ActiveTurn == true);
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
            Vector3 direction = Vector3.Normalize(mouseWorldPosition - StartPos);
            BallShootingDirection.SetActive(true);
            BallShootingDirection.transform.position = StartPos;
            BallShootingDirection.GetComponent<ShootingDirection>().Direction = direction;
            Quaternion q = Quaternion.LookRotation(new Vector3(0.0f, 0.0f, 1.0f), direction);
            float fZAngle = q.eulerAngles.z;
            if (fZAngle < 87.0f || fZAngle > 273.0f)
            {
               // BallShootingDirection.transform.rotation = q;
                ShootingDirection = direction;
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            ActiveTurn = false;
            BallShootingDirection.SetActive(false);
            ShootCoRoutine = StartCoroutine(ShootBall(ShootingDirection));
        }
    }

    private void FixedUpdate()
    {

    }

}
