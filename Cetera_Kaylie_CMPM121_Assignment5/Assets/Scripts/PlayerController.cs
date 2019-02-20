using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator wall;
    public Transform cam;
    Vector2 input;
    private int count;

    public GameObject testParticle;
    public Vector3 particleOffset;

    void Start()
    {
        count = 0;
    }


    void FixedUpdate()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * 100);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 100);
        }

        Vector3 camF = cam.forward;
        Vector3 camR = cam.right;
        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;

        transform.position += (camF * input.y + camR * input.x) * Time.deltaTime * 5;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            GameObject testParticleFX = Instantiate(testParticle, transform.position + particleOffset, Quaternion.identity) as GameObject;
            Destroy(testParticleFX, 5);

            other.gameObject.SetActive(false);
            count++;
            OpenDoor();
            ReturnToTitle();
        }
    }


    void OpenDoor()
    {
        if (count >= 5)
        {
            Debug.Log("picked up 5");
            wall.SetBool("openDoor", true);
            //bool openDoor = true;
            //wall.gameObject.SetActive(false);
        }
    }

    void ReturnToTitle()
    {
        if (count == 14)
        {
            SceneManager.LoadScene("Title Screen");
        }
    }
}
