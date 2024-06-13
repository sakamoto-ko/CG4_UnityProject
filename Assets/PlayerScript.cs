using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject bombParticle;

    //�A�j���[�^�[�R���g���[���[
    public Animator animator;

    private AudioSource audioSource;

    private bool isBlock = true;

    private int runCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float stick = Input.GetAxis("Horizontal");

        if (GoalScript.isGameClear == false)
        {
            Vector3 v = rb.velocity;

            //�W�����v
            //ray�̎擾
            Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.8f, 0.0f);
            Ray ray = new Ray(rayPosition, Vector3.down);
            float distance = 0.9f;
            //�����u���b�N���ǂ����̔���
            isBlock = Physics.Raycast(ray, distance);
            //�W�����v����
            //�����u���b�N�̎��̂݃W�����v�\
            if (isBlock)
            {
                animator.SetBool("jump", false);
                if (Input.GetButtonDown("Jump"))
                {
                    v.y = 8.0f;
                }
            }
            else
            {
                animator.SetBool("jump", true);
            }

            //�ړ�
            //x��
            //�E
            if (Input.GetKey(KeyCode.D) ||
                stick > 0)
            {
                v.x = 4.0f;
                transform.rotation = Quaternion.Euler(0, 90, 0);
                animator.SetBool("mode", true);
                if (++runCount >= 2)
                {
                    animator.SetBool("dush", true);
                }
            }
            //��
            else if (Input.GetKey(KeyCode.A) ||
                stick < 0)
            {
                v.x = -4.0f;
                transform.rotation = Quaternion.Euler(0, -90, 0);
                animator.SetBool("mode", true);
                if (++runCount >= 2)
                {
                    animator.SetBool("dush", true);
                }
            }
            else
            {
                v.x = 0.0f;
                runCount = 0;
                animator.SetBool("mode", false);
                animator.SetBool("dush", false);
            }

            //z��
            ////�O
            //if (Input.GetKey(KeyCode.W))
            //{
            //    v.z = moveSpeedZ;
            //    transform.rotation = Quaternion.Euler(0, 180, 0);
            //    animator.SetBool("mode", true);
            //}
            ////��
            //else if (Input.GetKey(KeyCode.S))
            //{
            //    v.z = -moveSpeedZ;
            //    transform.rotation = Quaternion.Euler(0, 360, 0);
            //    animator.SetBool("mode", true);
            //}
            //else
            //{
            //    v.z = 0;
            //    animator.SetBool("mode", false);
            //}

            rb.velocity = v;

        }
        else
        {
            runCount = 0;
            animator.SetBool("mode", false);
            animator.SetBool("dush", false);
            animator.SetBool("jump", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //���������I�u�W�F�N�g���R�C�����ǂ�������
        if (other.gameObject.tag == "COIN")
        {
            //�R�C������������
            other.gameObject.SetActive(false);
            //se��炷
            audioSource.Play();
            //�X�R�A���Z
            GameManagerScript.score += 1;
            //�����p�[�e�B�N��
            Instantiate(bombParticle, transform.position, Quaternion.identity);
        }
    }
}
