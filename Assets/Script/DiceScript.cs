using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class DiceScript : MonoBehaviour
{
    [SerializeField, ReadOnly] private Rigidbody rb;
    [SerializeField, ReadOnly] private Vector3 initialPos;
    [SerializeField, ReadOnly] bool hasLanded;
    [SerializeField, ReadOnly] bool thrown;
    [SerializeField, ReadOnly] int DiceValue;
    [SerializeField, ReadOnly] DiceSide[] _ds;
    public PlayerMovement _playerMovement;

    [Button]
    private void SetRefs()
    {
        rb = GetComponent<Rigidbody>();
        initialPos = transform.position;
        _ds = GetComponentsInChildren<DiceSide>();
    }
    private void Start()
    {
        rb.useGravity = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RollDice();
        }
        if (rb.IsSleeping() && !hasLanded && thrown)
        {
            hasLanded = true;
            rb.useGravity = false;
            rb.isKinematic = true;
            SideValueCheck();
        }
        else if (rb.IsSleeping()&& hasLanded && DiceValue == 0)
        {
            RollAgain();
        }
    }

    void RollDice()
    {
        if (!thrown && !hasLanded)
        {
            thrown = true;
            rb.useGravity = true;
           rb.AddTorque(Random.Range(25, 100), Random.Range(25, 100), Random.Range(25, 100));
        }
        else if (thrown && hasLanded)
        {
            Reset();
        }
    }

    void Reset()
    {
        transform.position = initialPos;
        thrown = false;
        hasLanded = false;
        rb.useGravity = false;
        rb.isKinematic = false;
    }

    void RollAgain()
    {
        Reset();
        thrown = true;
        rb.useGravity = true;
        rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));

    }

    void SideValueCheck()
    {
        DiceValue = 0;
        foreach(DiceSide side in _ds)
        {
            if (side.OnGround())
            {
                DiceValue = side.SideValue;
                _playerMovement.NumberOfJumps = DiceValue;
                _playerMovement.GoToDestination();
                StartCoroutine(ChangeCam());
                Debug.Log(side.SideValue);
               
            }

        }
    }

    IEnumerator ChangeCam()
    {
        yield return new WaitForSeconds(0.25f);
        GameManager.Instance.ChangeCamToPlayer();
        yield return new WaitForSeconds(3f);
        GameManager.Instance.ChangeCamTOBoard();
    }


}
