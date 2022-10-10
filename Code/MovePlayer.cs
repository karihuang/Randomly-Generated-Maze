using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
  public GameObject path;
  public AudioSource audioSource;
  public AudioClip upSound;
  public AudioClip downSound;
  public AudioClip leftSound;
  public AudioClip rightSound;
  public AudioClip winSound;

    // Start is called before the first frame update
    void Start()
    {
      transform.position = new Vector3(14, 0, 14);
      audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
  	{
      if (Input.GetKeyDown("g"))
      {
        Collider[] intersecting = Physics.OverlapSphere(new Vector3(
        transform.position.x, transform.position.y, transform.position.z + 1), 0.01f);
        if (intersecting.Length == 2)
        {
          transform.position = new Vector3(
          transform.position.x,
          transform.position.y,
          transform.position.z + 1);
          var point = Instantiate<GameObject>(path);
          point.transform.position = new Vector3(
          transform.position.x, transform.position.y, transform.position.z - 1);
        } else {
          audioSource.PlayOneShot(upSound, 1f);
        }
      }
      if (Input.GetKeyDown("v"))
      {
        Collider[] intersecting = Physics.OverlapSphere(new Vector3(
        transform.position.x - 1, transform.position.y, transform.position.z), 0.01f);
        if (intersecting.Length == 2)
        {
          transform.position = new Vector3(
          transform.position.x - 1,
          transform.position.y,
          transform.position.z);
          if (transform.position.x == -14 && transform.position.z == -12)
          {
            audioSource.PlayOneShot(winSound, 0.6f);
          }
          var point = Instantiate<GameObject>(path);
          point.transform.position = new Vector3(
          transform.position.x+1, transform.position.y, transform.position.z);
        } else {
          audioSource.PlayOneShot(leftSound, 1f);
        }
      }
      if (Input.GetKeyDown("b"))
      {
        Collider[] intersecting = Physics.OverlapSphere(new Vector3(
        transform.position.x, transform.position.y, transform.position.z - 1), 0.01f);
        if (intersecting.Length == 2)
        {
          transform.position = new Vector3(
          transform.position.x,
          transform.position.y,
          transform.position.z - 1);
          var point = Instantiate<GameObject>(path);
          point.transform.position = new Vector3(
          transform.position.x, transform.position.y, transform.position.z + 1);
        } else {
          audioSource.PlayOneShot(downSound, 1f);
        }
      }
      if (Input.GetKeyDown("n"))
      {
        Collider[] intersecting = Physics.OverlapSphere(new Vector3(
        transform.position.x + 1, transform.position.y, transform.position.z), 0.01f);
        if (intersecting.Length == 2)
        {
          transform.position = new Vector3(
          transform.position.x + 1,
          transform.position.y,
          transform.position.z);
          var point = Instantiate<GameObject>(path);
          point.transform.position = new Vector3(
          transform.position.x - 1, transform.position.y, transform.position.z);
        } else {
          audioSource.PlayOneShot(rightSound, 1f);
        }
      }
    }
}
