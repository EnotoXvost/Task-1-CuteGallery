using UnityEngine;
using UnityEngine.UI;

public class PicturesGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _contentPrefab;
    [SerializeField] private GameObject _contentParent;

    [SerializeField] private float _spawnOffset;
    [SerializeField] private int _numberStartGeneratePictures;
    [SerializeField] private int _numberGeneratePictures;

    private float _spawnInterval;
    private float _lastSpawnPositionY;
    private int _numberFilesOnServer;
    private int _contentCount;

    private GridLayoutGroup _gridLayoutGroup;

    private void Start()
    {
        _gridLayoutGroup = GetComponent<GridLayoutGroup>();
        
        _lastSpawnPositionY = _contentParent.transform.position.y;
        _spawnInterval = _gridLayoutGroup.cellSize.y;

        _contentCount = 0;

        GenerateContent(_numberStartGeneratePictures);
    }

    private void Update()
    {
        _numberFilesOnServer = GeterNumberOfFiles.GetFilesCount();

        if (_contentParent.transform.position.y + _spawnOffset > _lastSpawnPositionY
            && _contentCount < _numberFilesOnServer)
        {
            GenerateContent(_numberGeneratePictures);
        }

    }
    private void GenerateContent(int numGenerateContent)
    {
        for (int i = 0; i < numGenerateContent; i++)
        {
            GameObject newContent = Instantiate(_contentPrefab, _contentParent.transform);
            _contentCount++;
            StartCoroutine(ImageLoaderFromWeb.LoadImageFromWeb(newContent, _contentCount));
            newContent.name = _contentCount.ToString();
        }

        _lastSpawnPositionY += _spawnInterval;
    }
}