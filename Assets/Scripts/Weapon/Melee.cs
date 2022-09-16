using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Weapon {

    public int _dmg;
    [SerializeField] BoxCollider _meleeArea = null;

    public TrailRenderer _trailEffect;

    public override void Use() {
        StopCoroutine("Swing");
        StartCoroutine("Swing");

    }

    public override void UpGrade()
    {
        level++;
        _dmg *= level;
    }

    IEnumerator Swing() {
        yield return new WaitForSeconds(0.1f);
        _meleeArea.enabled = true;
        _trailEffect.enabled = true;

        yield return new WaitForSeconds(0.4f);
        _meleeArea.enabled = false;

        yield return new WaitForSeconds(0.1f);
        _trailEffect.enabled = false;
    }
}