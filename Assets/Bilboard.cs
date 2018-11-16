using UnityEngine;


public class Bilboard : MonoBehaviour
{
    void Update() 
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}