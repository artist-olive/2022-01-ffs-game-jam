using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    [SerializeField] ParticleSystem splashParticles;
    [SerializeField] Vector3 OriginalPosition;
    [SerializeField] GameObject Sprout;
    private bool IsClicked = false;
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Level"))
        {
            //make seed stay in place if they land on the sand/level
            Rigidbody rigidBody = gameObject.GetComponent<Rigidbody>();
            rigidBody.isKinematic = true;
        } else if (collision.gameObject.CompareTag("Water")) {
            ParticleSystem particles = gameObject.GetComponent<ParticleSystem>();
            particles.Play();
            StartCoroutine("HandleDestroySelf");
        }
    }

    private IEnumerator HandleDestroySelf()
    {
        yield return new WaitForSeconds(3);
        if (!IsClicked)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (IsClicked)
        {
            Vector3 NewPosition = OriginalPosition;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.point != null)
                {
                    NewPosition = hit.point;
                }
            }
            transform.position = NewPosition;
        }
    }

    public void setIsClicked(bool IsSeedClicked)
    {
        IsClicked = IsSeedClicked;
        if(IsSeedClicked)
        {
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        }
    }

    public void HandleDestroyAndCreateSprout(Vector3 position)
    {
        Destroy(gameObject);
        Instantiate(Sprout, position, Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
    }
}
