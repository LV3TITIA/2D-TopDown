using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    private Sprite _boxesClose;

    [SerializeField]
    private Sprite _boxesOpen;

    [SerializeField]
    private SpriteRenderer _image;

    [SerializeField]
    GameObject _axes; 
    
    [SerializeField]
    Transform _player;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _playerHoldingAxe = GameObject.Find("Player").GetComponent<HoldingAxe>();
    }

    void Start()
    {
        _axes.SetActive(false);
    }

    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            //Debug.Log("Collide avec le player");
            _image.sprite = _boxesOpen;
            _axes.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(AddAxesToplayer());
        }
        else
        {
            //Debug.Log("Collide avec le player 22");
            _image.sprite = _boxesClose;
        }
    }

    #endregion

    #region Methodes
    #endregion

    IEnumerator AddAxesToplayer()
    {
        yield return new WaitForSeconds(2);
        _playerHoldingAxe._haveAxes = true;
        _axes.transform.SetParent(_player);
        _axes.SetActive(false);
    }

    #region Private & Protected

    private HoldingAxe _playerHoldingAxe;

    #endregion
}
