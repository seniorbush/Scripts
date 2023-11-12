using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem crashVFX;
    private void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    private void StartCrashSequence()
    {
        crashVFX.Play();
        GetComponent<PlayerControls>().enabled = false;

        foreach (MeshRenderer meshInChild in GetComponentsInChildren<MeshRenderer>())
            meshInChild.enabled = false;

        foreach (SkinnedMeshRenderer skinnedMeshInChild in GetComponentsInChildren<SkinnedMeshRenderer>())
            skinnedMeshInChild.enabled = false;

        foreach (Collider colliderInChild in GetComponentsInChildren<Collider>())
            colliderInChild.enabled = false;

        Invoke("ReloadLevel", loadDelay);
    }

    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
