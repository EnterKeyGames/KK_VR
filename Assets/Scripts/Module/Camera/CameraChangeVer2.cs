using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeVer2 : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _pointRoot;

    private int _latestNo;
    private List<Transform> _points;

    // Start is called before the first frame update
    void Start()
    {
        _latestNo = 0;
        _points = new List<Transform>();

        foreach (Transform t in _pointRoot)
        {
            _points.Add(t);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _camera.position = _points[_latestNo].position;
            _camera.rotation = _points[_latestNo].rotation;
            _latestNo++;

            if (_latestNo == _points.Count)
            {
                _latestNo = 0;
            }
        }
    }
}
