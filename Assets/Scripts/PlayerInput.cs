﻿using UnityEngine;

[RequireComponent(typeof(RigidbodyCharacterController))]
public class PlayerInput : MonoBehaviour
{
  private RigidbodyCharacterController m_GravityCharacterController;
  private WeaponController m_WeaponController;
  private Vector2 m_InputDirection;
  [SerializeField]
  private Transform m_View;

  private void Start()
  {
    m_GravityCharacterController = GetComponent<RigidbodyCharacterController>();
    m_WeaponController = WeaponController.instance;
  }

  private void Update()
  {
    if (Input.GetButtonDown("Jump")) {
      m_GravityCharacterController.Jump();
    }

    if (Input.GetButtonDown("Fire")) {
      m_WeaponController.Fire();
    }
  }

  private void FixedUpdate()
  {
    m_InputDirection.x = Input.GetAxis("Horizontal");
    m_InputDirection.y = Input.GetAxis("Vertical");

    m_GravityCharacterController.Move(m_InputDirection);
  }
}