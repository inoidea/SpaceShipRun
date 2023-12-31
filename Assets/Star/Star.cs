﻿using System;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Star : MonoBehaviour
{
    [SerializeField] private ColorPoint _center;
    [SerializeField, NonReorderable] private ColorPoint[] _points;
    [SerializeField] private int _frequency = 1;

    private Mesh _mesh;
    private Vector3[] _vertices;
    private Color[] _colors;
    private int[] _triangles;

    public ColorPoint[] Points => _points;
    public int Frequency => _frequency;

    private void Start()
    {
        UpdateMesh();
    }

    public void UpdateMesh()
    {
        GetComponent<MeshFilter>().mesh = _mesh = new Mesh();
        _mesh.name = "Star Mesh";

        if (_frequency < 1)
        {
            _frequency = 1;
        }

        _points ??= Array.Empty<ColorPoint>();
        var numberOfPoints = _frequency * _points.Length;

        if (_vertices == null || _vertices.Length != numberOfPoints + 1)
        {
            _vertices = new Vector3[numberOfPoints + 1];
            _colors = new Color[numberOfPoints + 1];
            _triangles = new int[numberOfPoints * 3];
            _mesh.Clear();
        }

        if (numberOfPoints >= 3)
        {
            _vertices[0] = _center.Position;
            _colors[0] = _center.Color;
            var angle = -360f / numberOfPoints;
            for (int repetitions = 0, v = 1, t = 1; repetitions < _frequency; repetitions++)
            {
                for (var p = 0; p < _points.Length; p++, v++, t += 3)
                {
                    _vertices[v] = Quaternion.Euler(0f, 0f, angle * (v - 1)) * _points[p].Position;
                    _colors[v] = _points[p].Color;
                    _triangles[t] = v;
                    _triangles[t + 1] = v + 1;
                }
            }

            _triangles[_triangles.Length - 1] = 1;
        }

        _mesh.vertices = _vertices;
        _mesh.colors = _colors;
        _mesh.triangles = _triangles;
    }
}