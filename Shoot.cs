using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    SpriteRenderer playerSprite;
    AudioSource GunShotSFX;
    AudioSource ReloadSFX;
    Animator anim;
    Slider ReloadBar_value;
    Hp_con HpStat;
    PlayerMove move;
    public Transform bullet_Pos;
    public int damage = 10;
    public GameObject impactEffect;
    public LineRenderer linerenderer;
    public Text AmmoText;
    public int Ammo;
    public GameObject ReloadBar;
    float ReloadTime;
    bool IsReload;
    bool IsShooting;
    float originSpeed;
    private void Start()
    {
        move = GetComponent<PlayerMove>();
        anim = GetComponentInChildren<Animator>();
        GunShotSFX = GameObject.Find("ShotSFX").transform.GetComponent<AudioSource>();
        ReloadSFX = GameObject.Find("ReloadSFX").transform.GetComponent<AudioSource>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();
        ReloadBar_value = ReloadBar.transform.GetComponent<Slider>();
        HpStat = GetComponent<Hp_con>();
        originSpeed = move.speed;
    }
    void Update()
    {
        if (HpStat.gameOverStat == false)
        {
            if (Ammo > 0)
            {
                move.speed = originSpeed;
                AmmoText.text = Ammo.ToString();
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (IsReload == false)
                    {
                        StartCoroutine(shooting());
                        Ammo -= 1;
                        GunShotSFX.Play();
                    }
                }

                if (IsReload == false)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse1))
                    {
                        ReloadSFX.Play();
                        anim.SetBool("Reload", true);
                        IsReload = true;
                        ReloadTime = 1f;
                        ReloadBar.SetActive(true);
                    }
                }
                else
                {
                    move.speed = 3;
                    AmmoText.text = "Reloading";
                    if (ReloadTime > 0f)
                    {
                        ReloadTime -= Time.deltaTime;
                        ReloadBar_value.value += Time.deltaTime;
                    }
                    else
                    {
                        anim.SetBool("Reload", false);
                        Ammo = 18;
                        IsReload = false;
                        ReloadBar_value.value = 0;
                        ReloadBar.SetActive(false);
                    }
                }
            }

            if (Ammo <= 0)
            {
                if (IsReload == false)
                {
                    ReloadSFX.Play();
                    anim.SetBool("Reload", true);
                    IsReload = true;
                    ReloadTime = 1f;
                    ReloadBar.SetActive(true);
                }
                else
                {
                    move.speed = 3;
                    AmmoText.text = "Reloading";
                    if (ReloadTime > 0f)
                    {
                        ReloadTime -= Time.deltaTime;
                        ReloadBar_value.value += Time.deltaTime;
                    }
                    else
                    {
                        anim.SetBool("Reload", false);
                        Ammo = 18;
                        IsReload = false;
                        ReloadBar_value.value = 0;
                        ReloadBar.SetActive(false);
                    }
                }
            }
        }
    }

    IEnumerator shooting()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(bullet_Pos.position, bullet_Pos.forward);
        if(hitInfo)
        {
            //print(hitInfo.transform.name);
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.take_damage(damage);
            }

            Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

            linerenderer.SetPosition(0, bullet_Pos.position);
            linerenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            linerenderer.SetPosition(0, bullet_Pos.position);
            linerenderer.SetPosition(1, bullet_Pos.position + bullet_Pos.forward*100);
        }

        anim.SetBool("Shoot", true);
        linerenderer.enabled = true;

        yield return new WaitForSeconds(0.02f);

        anim.SetBool("Shoot", false);
        linerenderer.enabled = false;
    }
    IEnumerator healColor()
    {
        playerSprite.color = Color.green;

        yield return new WaitForSeconds(0.2f);

        playerSprite.color = Color.white;
    }
}
