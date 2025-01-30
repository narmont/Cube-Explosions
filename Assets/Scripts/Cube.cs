using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    private float _chance = 100;
    private Rigidbody _rigidbody;
    public Vector3 Position => transform.position;
    public Rigidbody Rigidbody => _rigidbody;
    public float ChanceToSplit => _chance;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    public void Init(Cube cube, Vector3 scale, float chance)
    {
        transform.position = cube.transform.position;
        transform.localScale = scale;
        _chance = chance;
    }
}
