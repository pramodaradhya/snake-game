﻿using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Snake2 : MonoBehaviour
{
    private List<Transform> segments = new List<Transform>();
    public Transform segmentPrefab;
    public Vector2 direction = Vector2.right;
    private Vector2 input;
    public int initialSize = 4;

    private void Start()
    {
        ResetState();
    }

    private void Update()
    {

        if (direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.W) )
            {
                input = Vector2.up;
            }
            else if (Input.GetKeyDown(KeyCode.S) )
            {
                input = Vector2.down;
            }
        }

        else if (direction.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.D) )
            {
                input = Vector2.right;
            }
            else if (Input.GetKeyDown(KeyCode.A) )
            {
                input = Vector2.left;
            }
        }
    }


    private void FixedUpdate()
    {

        if (input != Vector2.zero)
        {
            direction = input;
        }


        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }


        float x = Mathf.Round(transform.position.x) + direction.x;
        float y = Mathf.Round(transform.position.y) + direction.y;

        transform.position = new Vector2(x, y);
    }

    public void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
        
    }

    public void shrink()
    {
        Destroy(segments[segments.Count - 1].gameObject);
        segments.RemoveAt(segments.Count - 1);
    }

  
    public void ResetState()
    {
        direction = Vector2.right;
        transform.position = Vector3.zero;

      
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }

      
        segments.Clear();
        segments.Add(transform);


        for (int i = 0; i < initialSize - 1; i++)
        {
            Grow();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Grow();
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            ResetState();
        }
        else if (other.gameObject.CompareTag("poison"))
        {
            shrink();
        }
    }

}