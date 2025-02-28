using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    [SerializeField]
    private float xMax;
    [SerializeField]
    private float yMax;

    [SerializeField]
    private float xMin;
    [SerializeField]
    private float yMin;

    private Transform target;
    private float undergroundThreshold;

    // Use this for initialization
    void Start()
    {

        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);
    }

    public void SetUnderground(bool isUnderground)
    {
        // TODO do whatever the camera needs to do while underground here.
        return;
    }

    public float GetUndergroundThreshold()
    {
        return undergroundThreshold;
    }
}

