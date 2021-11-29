using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    private TileType currentType = TileType.Empty;  //���콺 Ŭ���� ��ġ�� Ÿ���� currentType �Ӽ����� ����

    private void Update()
    {
        RaycastHit hit;
        //���콺 ���� ��ư�� ������ ���� ��
        if (Input.GetMouseButton(0))
        {
            //ī�޶�κ��� ���� ���콺 ��ġ�� ������� ���� ����
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            //������ �ε��� ������Ʈ�� �����ϸ� hit�� ����
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //hit ������Ʈ�� Tile ������Ʈ ������ �ҷ��� tile ������ ����
                //�̶� hit ������Ʈ�� Tile ������Ʈ�� ������ null ��ȯ
                Tile tile = hit.transform.GetComponent<Tile>();
                if (tile != null)
                {
                    //�ε��� ������Ʈ�� tileType �Ӽ����� ���� (Ÿ��, ������, �÷��̾� ĳ����)
                    tile.TileType = currentType;
                }
            }
        }
    }


    /// <summary>
    /// Ÿ��, ������, �÷��̾� ĳ���� ��ư�� ���� tileType�� ����
    /// </summary>
    public void SetTileType(int tileType)
    {
        currentType = (TileType)tileType;
    }
}
