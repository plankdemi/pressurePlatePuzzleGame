using System;
using UnityEngine;

public class pressurePlateController : MonoBehaviour
{
    public event Action pressedBtn;
    public event Action unpressedBtn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pressedBtn?.Invoke();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            unpressedBtn?.Invoke();
        }

    }
}
