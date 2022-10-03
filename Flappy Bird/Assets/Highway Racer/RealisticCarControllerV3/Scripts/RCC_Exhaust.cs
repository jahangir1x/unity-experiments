﻿//----------------------------------------------
//            Realistic Car Controller
//
// Copyright © 2014 - 2022 BoneCracker Games
// http://www.bonecrackergames.com
// Buğra Özdoğanlar
//
//----------------------------------------------

using UnityEngine;
using System.Collections;

/// <summary>
/// Exhaust based on Particle System. Based on vehicle controller's throttle situation.
/// </summary>
[AddComponentMenu("BoneCracker Games/Realistic Car Controller/Misc/RCC Exhaust")]
public class RCC_Exhaust : RCC_Core {

    private RCC_CarControllerV3 carController;
    private ParticleSystem particle;
    private ParticleSystem.EmissionModule emission;
    public ParticleSystem flame;
    private ParticleSystem.EmissionModule subEmission;

    private Light flameLight;
    private LensFlare lensFlare;

    public float flareBrightness = 1f;
    private float finalFlareBrightness;

    public float flameTime = 0f;
    private AudioSource flameSource;

    public Color flameColor = Color.red;
    public Color boostFlameColor = Color.blue;

    public bool previewFlames = false;

    public float minEmission = 5f;
    public float maxEmission = 20f;

    public float minSize = 1f;
    public float maxSize = 4f;

    public float minSpeed = .1f;
    public float maxSpeed = 1f;

    void Start() {

        if (RCC_Settings.Instance.dontUseAnyParticleEffects) {
            Destroy(gameObject);
            return;
        }

        carController = GetComponentInParent<RCC_CarControllerV3>();
        particle = GetComponent<ParticleSystem>();
        emission = particle.emission;

        if (flame) {

            subEmission = flame.emission;
            flameLight = flame.GetComponentInChildren<Light>();
            flameSource = NewAudioSource(RCC_Settings.Instance.audioMixer, gameObject, "Exhaust Flame AudioSource", 10f, 25f, .5f, RCC_Settings.Instance.exhaustFlameClips[0], false, false, false);

            if (flameLight)
                flameLight.renderMode = RCC_Settings.Instance.useLightsAsVertexLights ? LightRenderMode.ForceVertex : LightRenderMode.ForcePixel;

        }

        lensFlare = GetComponentInChildren<LensFlare>();

        if (flameLight) {

            if (flameLight.flare != null)
                flameLight.flare = null;

        }

    }

    void Update() {

        if (!carController || !particle)
            return;

        Smoke();
        Flame();

        if (lensFlare)
            LensFlare();

    }

    void Smoke() {

        if (carController.engineRunning) {

            var main = particle.main;

            if (carController.speed < 20) {

                if (!emission.enabled)
                    emission.enabled = true;

                if (carController.throttleInput > .35f) {

                    emission.rateOverTime = maxEmission;
                    main.startSpeed = maxSpeed;
                    main.startSize = maxSize;

                } else {

                    emission.rateOverTime = minEmission;
                    main.startSpeed = minSpeed;
                    main.startSize = minSize;

                }

            } else {

                if (emission.enabled)
                    emission.enabled = false;

            }

        } else {

            if (emission.enabled)
                emission.enabled = false;

        }

    }

    void Flame() {

        if (carController.engineRunning) {

            var main = flame.main;

            if (carController.throttleInput >= .25f)
                flameTime = 0f;

            if (((carController.useExhaustFlame && carController.engineRPM >= 5000 && carController.engineRPM <= 5500 && carController.throttleInput <= .25f && flameTime <= .5f) || carController.boostInput >= .75f) || previewFlames) {

                flameTime += Time.deltaTime;
                subEmission.enabled = true;

                if (flameLight)
                    flameLight.intensity = flameSource.pitch * 3f * Random.Range(.25f, 1f);

                if (carController.boostInput >= .75f && flame) {

                    main.startColor = boostFlameColor;

                    if (flameLight)
                        flameLight.color = main.startColor.color;

                } else {

                    main.startColor = flameColor;

                    if (flameLight)
                        flameLight.color = main.startColor.color;

                }

                if (!flameSource.isPlaying) {

                    flameSource.clip = RCC_Settings.Instance.exhaustFlameClips[Random.Range(0, RCC_Settings.Instance.exhaustFlameClips.Length)];
                    flameSource.Play();

                }

            } else {

                subEmission.enabled = false;

                if (flameLight)
                    flameLight.intensity = 0f;
                if (flameSource.isPlaying)
                    flameSource.Stop();

            }

        } else {

            if (emission.enabled)
                emission.enabled = false;

            subEmission.enabled = false;

            if (flameLight)
                flameLight.intensity = 0f;
            if (flameSource.isPlaying)
                flameSource.Stop();

        }

    }

    private void LensFlare() {

        if (!RCC_SceneManager.Instance.activePlayerCamera)
            return;

        float distanceTocam = Vector3.Distance(transform.position, RCC_SceneManager.Instance.activePlayerCamera.actualCamera.transform.position);
        float angle = Vector3.Angle(transform.forward, RCC_SceneManager.Instance.activePlayerCamera.actualCamera.transform.position - transform.position);

        if (angle != 0)
            finalFlareBrightness = flareBrightness * (4 / distanceTocam) * ((100f - (1.11f * angle)) / 100f) / 2f;

        if (flameLight) {

            lensFlare.brightness = finalFlareBrightness * flameLight.intensity;
            lensFlare.color = flameLight.color;

        }

    }

}