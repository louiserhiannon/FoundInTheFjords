using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToBaitball : MonoBehaviour
{
    public float distance;
    public float viewDistance = 30f;
    public float minDistance = 12f;
    public float speed = 0.5f;
    public float rotationSpeed = 2f;
    public Transform carouselTransform;

    private void Start()
    {
        distance = Vector3.Distance(carouselTransform.position, transform.position);
    }
    public void MoveToMinimumDistance()
    {
        Vector3 direction = carouselTransform.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

        this.transform.Translate(0, 0, speed * Time.deltaTime);

        distance = Vector3.Distance(carouselTransform.position, transform.position);
    }
}
