using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }
}
