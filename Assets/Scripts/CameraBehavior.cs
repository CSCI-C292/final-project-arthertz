using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField]
    Animator gunAnimator;

    [SerializeField]
    Camera ghostCamera;

    bool canFire = true;

    [SerializeField]
    float flickerTime = .1f;

    [SerializeField]
    float blindDuration = 5f;

    [SerializeField]
    AudioClip playOnFire;

    [SerializeField]
    PlayerInventory inv;

    [SerializeField]
    GameObject ghostIndicator;


    [SerializeField]
    bool debug = false;

    [SerializeField]
    float cameraFlashRange = 15;


    GameObject[] ghosts;

    List<GameObject> ghostsInFrame = new List<GameObject>();

    

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && gunAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            AttemptFire();
        }

        UpdateGhostsInFrame();

        if (ghostsInFrame.Count > 0) {
            ghostIndicator.SetActive(true);
        } else {
            ghostIndicator.SetActive(false);
        }

    }

    void AttemptFire () {
        int film = inv.GetFilm();

        if (film <= 0) return;

        inv.SetFilm(film - 1);

        gunAnimator.SetTrigger("fireWeapon");

        StartCoroutine(FlickerCamera());

        foreach (GameObject ghost in ghostsInFrame) {
            ghost.GetComponent<Lurker>().Blind(blindDuration);
        }
    }

    void UpdateGhostsInFrame () {
        ghosts = GameObject.FindGameObjectsWithTag("Ghost");

        ghostsInFrame.Clear();

        Plane[] planes;

        RaycastHit hit;

        foreach (GameObject ghost in ghosts) {
                planes = GeometryUtility.CalculateFrustumPlanes(ghostCamera);
                Physics.Raycast(ghostCamera.transform.position, ghost.transform.position - ghostCamera.transform.position, out hit, cameraFlashRange);
                if (hit.collider) {
                    if (GeometryUtility.TestPlanesAABB(planes, ghost.GetComponent<Collider>().bounds) && hit.collider.gameObject.layer == LayerMask.NameToLayer("Ghost")) {

                    if (debug) print(ghost.name + " is in view");

                    ghostsInFrame.Add(ghost);
                }
                }
        }
    }

    IEnumerator FlickerCamera () {
        ghostCamera.gameObject.SetActive(true);

        GetComponent<AudioSource>().PlayOneShot(playOnFire);

        yield return new WaitForSeconds(flickerTime);

        ghostCamera.gameObject.SetActive(false);
    }


}
