using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShottingPlayer : MonoBehaviour
{
    [SerializeField] private GameObject GunBarrel;
    [SerializeField] private GameObject Nozzle;
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField]private float ReloadTime;
    private float LastShootTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = transform.position.z;
        float z = Mathf.Atan2(transform.position.y - worldPos.y, transform.position.x - worldPos.x) * Mathf.Rad2Deg;
        GunBarrel.transform.eulerAngles = new Vector3(0.0f, 0.0f, z+90.0f);

        if (Input.GetMouseButton(0))
        {
            if (Time.time - LastShootTime >= ReloadTime)
            {
                Instantiate(BulletPrefab, Nozzle.transform.position, Quaternion.Euler(0.0f, 0.0f, z + 90.0f));
                LastShootTime = Time.time;
            }
        }
    }

    /*
    private void OnDrawGizmos()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Gizmos.DrawLine(GunBarrel.transform.position, worldPos);
    }*/
}
