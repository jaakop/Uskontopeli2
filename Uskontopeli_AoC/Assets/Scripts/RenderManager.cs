using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RenderManager : MonoBehaviour
{
    public const float CHUNK_EXTENT = 10;
    public const float UPDATE_INTERVAL = 1;

    [SerializeField]
    public static int RENDER_RADIUS = 8;
    public static int RENDER_DIAMETER = RENDER_RADIUS * 2 + 1;

    public class Chunk
    {
        private Transform Header;

        public int X;
        public int Y;

        public List<GameObject> Objects = new List<GameObject>();

        public Chunk (int x, int y)
        {            
            X = x;
            Y = y;

            Header = new GameObject(X.ToString() + ", " + Y.ToString()).transform;
            Header.gameObject.SetActive(false);
        }

        public void AddObject (GameObject Object)
        {
            Object.transform.SetParent(Header);
            Objects.Add(Object);
        }

        public void SetActive (bool Active)
        {
            Header.gameObject.SetActive(Active);
        }
    }

    public static List<Chunk> Chunks = new List<Chunk>();

    private Chunk TryFind (int X, int Y)
    {
        foreach (Chunk Chunk in Chunks)
        {
            if (Chunk.X == X && Chunk.Y == Y)
                return Chunk;
        }

        return null;
    }

    protected void Start()
    {
        GameObject[] GameObjects = GameObject.FindGameObjectsWithTag("GameObject");

        foreach (GameObject Object in GameObjects)
        {
            int X = (int)(Object.transform.position.x / CHUNK_EXTENT);
            int Y = (int)(Object.transform.position.z / CHUNK_EXTENT);

            Chunk Chunk = TryFind(X, Y);

            if (Chunk != null)
            {
                Chunk.AddObject(Object);
                continue;
            }

            Chunk = new Chunk(X, Y);
            Chunk.AddObject(Object);

            Chunks.Add(Chunk);
        }

        InvokeRepeating("Process", 0, UPDATE_INTERVAL);
    }

    private static Chunk[] ActiveChunks = new Chunk[RENDER_DIAMETER * RENDER_DIAMETER];

    private void Process ()
    {

#if DEBUG
        GameObject.FindGameObjectWithTag("FPS").GetComponent<Text>().text = ((int)(1.0f / Time.deltaTime)).ToString() + "fps";
#endif

        int PlayerX = (int)(PlayerController.Player.transform.position.x / CHUNK_EXTENT);
        int PlayerY = (int)(PlayerController.Player.transform.position.z / CHUNK_EXTENT);

        Chunk[] Chunks = new Chunk[RENDER_DIAMETER * RENDER_DIAMETER];
            
        for (int Y = -RENDER_RADIUS, i = 0; Y < RENDER_RADIUS; Y++)
        {
            for (int X = -RENDER_RADIUS; X < RENDER_RADIUS; X++, i++)
            {
                if ((Chunks[i] = TryFind(PlayerX + X, PlayerY + Y)) == null)
                    continue;

                bool isActivated = false;

                for (int l = 0; l < ActiveChunks.Length; l++)
                {
                    if (ActiveChunks[l] != null && ActiveChunks[l].X == Chunks[i].X && ActiveChunks[l].Y == Chunks[i].Y)
                    {
                        ActiveChunks[l] = null;
                        isActivated = true;
                        break;
                    }
                }

                if (!isActivated)
                    Chunks[i].SetActive(true);
            }
        }

        foreach (Chunk Chunk in ActiveChunks)
        {
            if (Chunk != null)
                Chunk.SetActive(false);
        }

        ActiveChunks = Chunks;
    }

    public static void ChangeRenderDistance(int _renderDistance)
    {
        RENDER_RADIUS = _renderDistance;
        RENDER_DIAMETER = RENDER_RADIUS * 2 + 1;
    }

}
