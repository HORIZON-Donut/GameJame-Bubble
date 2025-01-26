using UnityEngine;

public class Billboarding : MonoBehaviour
{
    public int healt;
    private void Update()
    {
        LastUpdate();
    }
    private void LastUpdate()
    {
        //Get the camera postion
        Vector3 cameraPositoon = Camera.main.transform.position;

        //Rotate camera Y axis 
        cameraPositoon.y = transform.position.y;

        //Make the sprite face the camera
        transform.LookAt(cameraPositoon);
        //Rotate 180 on Y because of spriteRenderer works
        transform.Rotate(0f, 180f, 0f);
    }

    
}
