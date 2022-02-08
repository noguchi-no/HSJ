using System.Collections.Generic;
using UnityEngine;

public class RigidbodySimulate : MonoBehaviour
{
    [SerializeField]
    private GameObject _simulateResource;

    [SerializeField]
    private float _simulateTime = 2f;
    [SerializeField]
    private int divide = 10;
    [SerializeField]
    private float _offsetSpeed = 1f;

    private List<GameObject> _points;
    private bool _isSimulate;
    private float _offset;
    private Transform _cacheTarget;
    private float _mass;
    private Vector3 _velocity;
    private float _gravityY;

    private void Start()
    {
        _isSimulate = false;
        _points = new List<GameObject>(divide);
        for (var i = 0; i < divide; i++)
            _points.Add(Instantiate(_simulateResource, transform));

        if (_simulateResource.activeInHierarchy)
            _simulateResource.SetActive(false);
        Hide();
    }

    public void Hide()
    {
        _isSimulate = false;
        _offset = 0f;
        foreach (var p in _points)
            p.SetActive(false);
    }

    private void Show()
    {
        if (_isSimulate)
            return;

        _isSimulate = true;
        foreach (var p in _points)
            p.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (!_isSimulate)
            return;
        if (_cacheTarget == null)
        {
            _isSimulate = false;
            return;
        }
        _offset = (_offset + Time.deltaTime * _offsetSpeed) % 1;
        Simulate();
    }

    public void SetSimulate(Rigidbody target, Vector3 velocity)
    {
        Show();

        _cacheTarget = target.transform;
        _mass = target.mass;
        _velocity = velocity;
        _gravityY = Physics.gravity.y;
    }

    public void SetSimulate2D(Rigidbody2D target, Vector2 velocity)
    {
        Show();

        _cacheTarget = target.transform;
        _mass = target.mass;
        _velocity = velocity;
        _gravityY = Physics2D.gravity.y;
    }

    private void Simulate()
    {
        var force = _velocity / _mass;
        var addSec = _simulateTime / divide;
        for (var i = 0; i < divide; i++)
        {
            var pos = _cacheTarget.transform.position;
            var t = i * addSec + _offset;
            if (t > _simulateTime)
                t -= _simulateTime;
            pos += t * force;
            // yÇæÇØèdóÕÇåvéZÇ∑ÇÈ 1 / 2 g t^2
            pos.y += -0.5f * -_gravityY * Mathf.Pow(t, 2f);

            _points[i].transform.position = pos;
        }
    }
}