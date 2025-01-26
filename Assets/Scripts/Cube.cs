using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    [SerializeField] private int _minRandomValue;
    [SerializeField] private int _maxRandomValue;

    private float _chance = 100;
    public Vector3 Position => this.transform.position;
    public float ChanceToSplit => _chance;

    private void Awake()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    public void Initialization(Cube cube, Vector3 scale, float chance)
    {
        this.transform.position = cube.transform.position;
        transform.localScale = scale;
        _chance = chance;
    }
}
