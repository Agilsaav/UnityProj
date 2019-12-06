﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.UI.DamageText
{
    public class DamageText : MonoBehaviour
    {
        [SerializeField] Text damageText = null;

        private void Start()
        {
            DestroyText();
        }

        public void DestroyText()
        {
            float animationLength = GetComponentInChildren<Animation>().clip.length;
            Destroy(gameObject, animationLength);
        }

        public void SetValue(float amount)
        {
            damageText.text = String.Format("{0:0}", amount);
        }
    }

        //public void DestroyText()
        //{
        //    Destroy(gameObject);
        //}
}