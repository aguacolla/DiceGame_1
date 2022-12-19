using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public CinemachineFreeLook Cam_1;
    public CinemachineFreeLook Cam_2;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Cam_1.Priority = 20;
        Cam_2.Priority = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCamToPlayer()
    {
        Cam_2.Priority = 20;
        Cam_1.Priority = 0;
    }

    public void ChangeCamTOBoard()
    {
        Cam_2.Priority = 0;
        Cam_1.Priority = 20;
    }
}
