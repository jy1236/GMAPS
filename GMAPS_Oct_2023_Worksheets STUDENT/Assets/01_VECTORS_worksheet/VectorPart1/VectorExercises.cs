using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2d, Q2e;
    [SerializeField] bool Q3a, Q3b, Q3c, projection;

    private Line drawnLine;

    private Vector2 startPt;
    private Vector2 endPt;

    public float GameWidth, GameHeight;
    private float minX, minY, maxX, maxY;

    private void Start()
    {
        CalculateGameDimensions();

        if (Q2a)
            Question2a();
        if (Q2b)
            Question2b(20);
        if (Q2d)
            Question2d();
        if (Q2e)
            Question2e(20);
        if (Q3a)
            Question3a();
        if (Q3b)
            Question3b();
        if (Q3c)
            Question3c();
        if (projection)
            Projection();
    }
    
    public void CalculateGameDimensions()
    {
        GameHeight = Camera.main.orthographicSize * 2f;
        GameWidth = Camera.main.aspect * GameHeight;

        maxX = GameWidth / 2;
        maxY = GameHeight / 2;
        minX = -maxX;
        minY = -maxY;
    }

    void Question2a()
    {
        startPt = new Vector2(0, 0);
        endPt = new Vector2(2, 3);

        drawnLine = lineFactory.GetLine(startPt , endPt ,0.02f, Color.black);
        drawnLine.EnableDrawing(true);

        Vector2 vec2 = endPt - startPt;
        float magnitude = vec2.magnitude; // calculate magnitude
        Debug.Log("Magnitude = " + magnitude); // print magnitude
    }

    void Question2b(int n)
    {
        for(int i = 0; i < n; i++) // loop
        {
            startPt = new Vector2(
                Random.Range(-maxX ,maxX), //random point between -5f and 5f
                Random.Range(-maxY, maxY)); //random point between -5 and 5

            endPt = new Vector2(
                Random.Range(-maxX ,maxX), //random point between -5 and 5
                Random.Range(-maxY, maxY)); //random point between -5 and 5


            drawnLine = lineFactory.GetLine(
                startPt, endPt, 0.02f, Color.black);
            
            drawnLine.EnableDrawing(true);
        }
    }

    void Question2d()
    {
        DebugExtension.DebugArrow(
            new Vector3(0, 0, 0),
            new Vector3(5, 5, 5),
            Color.red,
            60f);
    }

    void Question2e(int n)
    {
        for (int i = 0; i < n; i++)
        {
            DebugExtension.DebugArrow(
                new Vector3(0, 0, 0),
                new Vector3(Random.Range(-maxX ,maxX), Random.Range(-maxY ,maxY), Random.Range(-maxY ,maxY)),
                Color.white,
                60f);
        }  
    }

    public static HVector2D operator +(HVector2D a, HVector2D b)
    {
        return new HVector2D(a.x + b.x, a.y + b.y);
    }
    public void Question3a()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(-4, 2);
        HVector2D c = a + b;

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(Vector3.zero, b.ToUnityVector3(), Color.green, 60f);
        DebugExtension.DebugArrow(Vector3.zero, c.ToUnityVector3(), Color.white, 60f);

        float magnitudeA = a.Magnitude();
        float magnitudeB = b.Magnitude();
        float magnitudeC = c.Magnitude();

       /* Debug.Log("Magnitude of a = " + magnitudeA.ToString("F2"));
        Debug.Log("Magnitude of b: " + magnitudeB.ToString("F2"));
        Debug.Log("Magnitude of c: " + magnitudeC.ToString("F2"));*/

    }
    

    public void Question3b()
    {
        HVector2D a = new HVector2D(3, 5);



        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        
    }

    public void Question3c()
    {

        HVector2D a = new HVector2D(3, 5);

    
    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        //HVector2D v1 = b - a;
        // Your code here

        //HVector2D proj = // Your code here

        //DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        //DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        //DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
}
