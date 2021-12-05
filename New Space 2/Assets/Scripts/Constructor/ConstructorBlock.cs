using UnityEngine;
using UnityEngine.EventSystems;
using Test.ShipModules.Abstraction;
using UnityEngine.UI;
using Test;

public class ConstructorBlock : MonoBehaviour
{
    public Vector2Int GridPos = Vector2Int.one;

    public GameObject CommandCenter;
    public GameObject Battery;
    public GameObject Collector;
    public GameObject Converter;
    public GameObject Engine;
    public GameObject Corpus;
    public GameObject Generator;
    public GameObject Cannon;
    public GameObject Repeirer;
    public GameObject Storage;

    public Text TextError;

    private TypeModule TypeBlock = TypeModule.Null;

    public void Error()
    {
        TextError.text = "Conditions not met ";
        
        void Return()
        {
            TextError.text = "";
        }
    }
    
    //������

    public void Exit()
    {
        transform.transform.Find("Canvas")
            .transform.Find("PanelBuild")
            .gameObject.SetActive(false);
        transform.transform.Find("Canvas")
            .gameObject
            .SetActive(false);
    }
    public void ExitLVL()
    {
        transform.Find("Canvas").transform.Find("PanelLVL").gameObject.SetActive(false);
        transform.Find("Canvas").gameObject.SetActive(false);
    }
    public void Destroy()
    {
        void RealDestroy()
        {
            if (FindNeighbor(GridPos, TypeModule.Corpus, 0))
                transform.GetComponent<LineRenderer>()
                    .enabled = true;
            else if (FindNeighbor(GridPos, TypeModule.CommandCenter, 0))
                transform.GetComponent<LineRenderer>()
                    .enabled = true;

            Ship.Modules.Remove(transform.Find("GameObject").GetChild(0).GetComponent<BaseModule>());  //������� �� ������ ������ ��������� ��� ����� �����        <---

            Ship.Refresh(transform.Find("GameObject").GetChild(0).GetComponent<BaseModule>());  //                                     |

            transform.GetComponent<ConstructorBlock>()                  //������ ��� ����� ����� �� �������, �� ������ ������� �:     --
                .TypeBlock = TypeModule.Null;

            transform.parent.GetComponent<Stats>().RefreshStats();  //���������� ���������� �������

            Destroy(transform.Find("GameObject")
                .transform.GetChild(0)
                .gameObject);
            transform.Find("Canvas")
                .gameObject
                .SetActive(false);
            transform.Find("Canvas")
                .transform.Find("PanelLVL")
                .gameObject
                .SetActive(false);
        }
        if (TypeBlock != TypeModule.CommandCenter)
        {
            if (TypeBlock == TypeModule.Corpus)
            {
                int CountNeighbor = 0;

                if (ConstructorGrid.constructorGrid[GetUp(GridPos)[0], GetUp(GridPos)[1]]
                    .GetComponent<ConstructorBlock>().TypeBlock != TypeModule.Null)
                    CountNeighbor++;
                if (ConstructorGrid.constructorGrid[GetDown(GridPos)[0], GetDown(GridPos)[1]]
                    .GetComponent<ConstructorBlock>().TypeBlock != TypeModule.Null)
                    CountNeighbor++;
                if (ConstructorGrid.constructorGrid[GetLeft(GridPos)[0], GetLeft(GridPos)[1]]
                    .GetComponent<ConstructorBlock>().TypeBlock != TypeModule.Null)
                    CountNeighbor++;
                if (ConstructorGrid.constructorGrid[GetRight(GridPos)[0], GetRight(GridPos)[1]]
                    .GetComponent<ConstructorBlock>().TypeBlock != TypeModule.Null)
                    CountNeighbor++;

                if (CountNeighbor == 1)
                {
                    if (GridPos.y < ConstructorGrid.constructorGrid.GetLength(1) - 1
                    && !FindNeighbor(new Vector2(GetUp(GridPos)[0], GetUp(GridPos)[1]), TypeModule.Corpus, 3)
                    && !FindNeighbor(new Vector2(GetUp(GridPos)[0], GetUp(GridPos)[1]), TypeModule.CommandCenter, 3))   //Up
                    {
                        ConstructorGrid.constructorGrid[GetUp(GridPos)[0], GetUp(GridPos)[1]]
                            .transform.GetComponent<LineRenderer>()
                            .enabled = false;
                    }
                    if (GridPos.y > 0
                    && !FindNeighbor(new Vector2(GetDown(GridPos)[0], GetDown(GridPos)[1]), TypeModule.Corpus, 1)
                    && !FindNeighbor(new Vector2(GetDown(GridPos)[0], GetDown(GridPos)[1]), TypeModule.CommandCenter, 1))  //Down
                    {
                        ConstructorGrid.constructorGrid[GetDown(GridPos)[0], GetDown(GridPos)[1]]
                            .transform.GetComponent<LineRenderer>()
                            .enabled = false;
                    }
                    if (GridPos.x > 0
                    && !FindNeighbor(new Vector2(GetLeft(GridPos)[0], GetLeft(GridPos)[1]), TypeModule.Corpus, 2)
                    && !FindNeighbor(new Vector2(GetLeft(GridPos)[0], GetLeft(GridPos)[1]), TypeModule.CommandCenter, 2))  //Left
                    {
                        ConstructorGrid.constructorGrid[GetLeft(GridPos)[0], GetLeft(GridPos)[1]]
                            .transform.GetComponent<LineRenderer>()
                            .enabled = false;
                    }
                    if (GridPos.x < ConstructorGrid.constructorGrid.GetLength(0) - 1
                    && !FindNeighbor(new Vector2(GetRight(GridPos)[0], GetRight(GridPos)[1]), TypeModule.Corpus, 4)
                    && !FindNeighbor(new Vector2(GetRight(GridPos)[0], GetRight(GridPos)[1]), TypeModule.CommandCenter, 4))    //Right
                    {
                        ConstructorGrid.constructorGrid[GetRight(GridPos)[0], GetRight(GridPos)[1]]
                            .transform.GetComponent<LineRenderer>()
                            .enabled = false;
                    }
                    RealDestroy();
                }
                else
                {
                    Error();
                }
            }
            else
            {
                RealDestroy();
            }
        }
        else Error();
    }


    //�������������

    public void NewCorpus()
    {
        if (TestUp(GridPos, TypeModule.Null))
        {
            ConstructorGrid.constructorGrid[GetUp(GridPos)[0], GetUp(GridPos)[1]]
               .transform.GetComponent<LineRenderer>()
               .enabled = true;
        }
        if (TestRight(GridPos, TypeModule.Null))
        {
            ConstructorGrid.constructorGrid[GetRight(GridPos)[0], GetRight(GridPos)[1]]
                .transform.GetComponent<LineRenderer>()
                .enabled = true;
        }
        if (TestDown(GridPos, TypeModule.Null))
        {
            ConstructorGrid.constructorGrid[GetDown(GridPos)[0], GetDown(GridPos)[1]]
                .transform.GetComponent<LineRenderer>()
                .enabled = true;
        }
        if (TestLeft(GridPos, TypeModule.Null))
        {
            ConstructorGrid.constructorGrid[GetLeft(GridPos)[0], GetLeft(GridPos)[1]]
                .transform.GetComponent<LineRenderer>()
                .enabled = true;
        }
    }   //������ �������� ����� ��������� ��� �������������
    public void Build(GameObject prefab)
    {
        if (TestCantBeNear(prefab)
        && Ship.TryAddModule(prefab.GetComponent<BaseModule>()))
        {
            GameObject Prefab = Instantiate(prefab);
            Prefab.transform.position = transform.position + new Vector3(0.5f, 0, 0.5f);
            Prefab.transform.parent = transform.Find("GameObject");
            TypeBlock = Prefab.GetComponent<BaseModule>().Type;
            if (TypeBlock == TypeModule.Corpus)
                NewCorpus();
            transform.GetComponent<LineRenderer>().enabled = false;
            transform.parent.GetComponent<Stats>().RefreshStats();
            Exit();
        }
        else
        {
            Error();
        }
    }
    private void buildCommandCenter()
    {
        Build(CommandCenter);
    }

    //������ ������

    private void Start()
    {
        GetComponent<LineRenderer>()
            .SetPositions(new Vector3[]
          { new Vector3(transform.position.x, 0.3f, transform.position.z),
            new Vector3( transform.position.x+1, 0.3f, transform.position.z),
            new Vector3( transform.position.x+1, 0.3f, transform.position.z+1),
            new Vector3( transform.position.x, 0.3f, transform.position.z+1)});

        if (GridPos == new Vector2(5, 5))
        {
            buildCommandCenter();
            NewCorpus();
        }
    }
    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject()) //��� �������� �� ���� ������������ ��������� �� ��������
        {
            if (transform.GetComponent<LineRenderer>().enabled == true)
            {
                transform.Find("Canvas").gameObject.SetActive(true);
                transform.Find("Canvas").transform.Find("PanelBuild").gameObject.SetActive(true);
            }
            if (TypeBlock != TypeModule.Null)
            {
                transform.Find("Canvas").gameObject.SetActive(true);
                transform.Find("Canvas").transform.Find("PanelLVL").gameObject.SetActive(true);
            }
        }
    }

    //�������������� 

    private Vector2Int GetUp(Vector2 Pos)
    {
        return new Vector2Int((int)Pos.x, (int)Pos.y + 1);
    }   //���� ���������� ����� ������
    private Vector2Int GetRight(Vector2 Pos)
    {
        return new Vector2Int((int)Pos.x + 1, (int)Pos.y);
    }   //���� ���������� ����� ������
    private Vector2Int GetDown(Vector2 Pos)
    {
        return new Vector2Int((int)Pos.x, (int)Pos.y - 1);
    }   //���� ���������� ����� �����
    private Vector2Int GetLeft(Vector2 Pos)
    {
        return new Vector2Int((int)Pos.x - 1, (int)Pos.y);
    }   //���� ���������� ����� �����

    //��������

    private bool TestCantBeNear(GameObject prefab)
    {
        foreach (TypeModule type in prefab.GetComponent<BaseModule>().CantBeNear)
        {
            if(FindNeighbor(GridPos, type, 0))
                return false;
        }
        return true;
    }   //�������� �� ������� ��������� �������
    private bool TestUp(Vector2 Pos, TypeModule type)
    {

        if (Pos.y < ConstructorGrid.constructorGrid.GetLength(1) - 1
            && ConstructorGrid.constructorGrid[GetUp(Pos).x, GetUp(Pos).y]
            .GetComponent<ConstructorBlock>().TypeBlock == type)
            return true;

        else return false;
    }   //��������� ������� ���� �� ��� ������ : true - �������
    private bool TestRight(Vector2 Pos, TypeModule type)
    {
        if (Pos.x < ConstructorGrid.constructorGrid.GetLength(0) - 1
            && ConstructorGrid.constructorGrid[GetRight(Pos).x, GetRight(Pos).y]
            .GetComponent<ConstructorBlock>().TypeBlock == type)
            return true;
        else return false;
    }   //��������� ������ ���� �� ��� ������ : true - �������
    private bool TestDown(Vector2 Pos, TypeModule type)
    {
        if (Pos.y > 0
            && ConstructorGrid.constructorGrid[GetDown(Pos).x, GetDown(Pos).y]
            .GetComponent<ConstructorBlock>().TypeBlock == type)
            return true;
        else return false;
    }   //��������� ������ ���� �� ��� ������ : true - �������
    private bool TestLeft(Vector2 Pos, TypeModule type)
    {
        if (Pos.x > 0
            && ConstructorGrid.constructorGrid[GetLeft(Pos).x, GetLeft(Pos).y]
            .GetComponent<ConstructorBlock>().TypeBlock == type)
            return true;
        else return false;
    }   //��������� ����� ���� �� ��� ������ : true - �������
    private bool FindNeighbor(Vector2 pos, TypeModule type, int block)
    {
        switch (block)
        {
            case 0:
                if (TestUp(pos, type)
                || TestDown(pos, type)
                || TestRight(pos, type)
                || TestLeft(pos, type))
                    return true;
                else return false;
            case 1:
                if (TestDown(pos, type)
                || TestRight(pos, type)
                || TestLeft(pos, type))
                    return true;
                else return false;
            case 2:
                if (TestUp(pos, type)
                || TestDown(pos, type)
                || TestLeft(pos, type))
                    return true;
                else return false;
            case 3:
                if (TestUp(pos, type)
                || TestRight(pos, type)
                || TestLeft(pos, type))
                    return true;
                else return false;
            case 4:
                if (TestUp(pos, type)
                || TestDown(pos, type)
                || TestRight(pos, type))
                    return true;
                else return false;
            default:
                return false;
        }
    }   //��������� ������� �� ��� ������, ��������� ���� ������� ����� ������ ��������� �� ������(block) : true - �������
        // 0 - �� �������, 1 - ����, 2 - �����, 3 - ���, 4 - ����
}
