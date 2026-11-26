using Unity.Cinemachine;
using UnityEditor.Rendering;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public GameObject Player;

    // Camera
    //[SerializeField] private CinemachineCamera camA;
    //[SerializeField] private CinemachineCamera camB;
    [SerializeField] private CinemachineCamera cam;
    //bool CameraA = true;
    //bool CameraB = false;

    public void StopCamera()
    {
        cam.LookAt = null;
        cam.Follow = null;
    }

    public void StartCamera()
    {
        cam.Follow = Player.transform;
    }



    /*  public void SwitchToCamA()
      {
          camA.Priority = 10;
          camB.Priority = 5;
          CameraA = true;
          CameraB = false;

          Debug.Log("Camera A");
      }

      public void SwitchToCamB()
      {
          camB.transform.position = playerRB.position;
          camB.LookAt = null;
          camB.Follow = null;
          camB.Priority = 10;
          camA.Priority = 5;

          CameraA = false;
          CameraB = true;

          Debug.Log("Camera B");
      } */

}
