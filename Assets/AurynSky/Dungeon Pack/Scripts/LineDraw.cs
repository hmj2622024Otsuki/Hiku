using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class LineDraw : MonoBehaviour
{
	LineRenderer lineRenderer;
	List<Vector3> points = new List<Vector3>();
	[SerializeField] Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
		if (cam == null) cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out RaycastHit hit))
			{
				Vector3 drawPos = hit.point + hit.normal * 0.01f;

				if (!points.Contains(drawPos))
				{
					points.Add(drawPos);
					lineRenderer.positionCount = points.Count;
					lineRenderer.SetPosition(points.Count - 1, drawPos);
				}
			}
		}
    }
}
