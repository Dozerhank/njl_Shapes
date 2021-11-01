using System;

abstract class Shape
{
    //Attributes
    protected string shapeColor = "";
    protected double shapeArea, shapePerimeter = 0.0;
    public virtual double area()
    {
        return shapeArea;
    }

    public virtual double perimeter()
    {
        return shapePerimeter;
    }

    public virtual void move(double x, double y)
    {

    }

    public virtual string render()
    {
        return this.render();
    }

    //Methods
    public virtual string getColor()
    {
        return shapeColor;
    }
}

class Box : Shape
{
    //Attributes
    string color;
    double left, top, right, bottom;

    //Methods
    public Box(string C, double L, double T, double R, double B)
    {
        color = C;
        left = L;
        top = T;
        right = R;
        bottom = B;
    }
    public override double area()
    {
        shapeArea = (right - left) * (top - bottom);
        return shapeArea;
    }
    public override double perimeter()
    {
        shapePerimeter = ((right - left) * 2) + ((top - bottom) * 2);
        return shapePerimeter;
    }
    public override string getColor()
    {
        return color;
    }
    public override void move(double x, double y)
    {
        base.move(x, y);
        left += x;
        right += x;
        top += y;
        bottom += y;
    }
    public override string render()
    {
        string renderTemp = "Box(" + color + "," + left + "," + top + "," + right + "," + bottom + ")";
        return renderTemp; 
    }

    //Set value functions
    public void setLeft(double L)
    {
        left = L;
    }
    public void setTop(double T)
    {
        top = T;
    }
    public void setRight(double R)
    {
        right = R;
    }
    public void setBottom(double B)
    {
        bottom = B;
    }

    //Get value functions
    public double getLeft()
    {
        return left;
    }
    public double getTop()
    {
        return top;
    }
    public double getRight()
    {
        return right;
    }
    public double getBottom()
    {
        return bottom;
    }
}

class Circle : Shape
{
    //Attributes
    string color;
    double centerX, centerY, radius;

    //Methods
    public Circle(string C, double X, double Y, double R)
    {
        color = C;
        centerX = X;
        centerY = Y;
        radius = R;
    }
    public override double area()
    {
        shapeArea = 3.14 * (radius * 2);
        return shapeArea;
    }
    public override double perimeter()
    {
        shapePerimeter = 2 * 3.14 * radius;
        return shapePerimeter;
    }
    public override string getColor()
    {
        return color;
    }
    public override void move(double x, double y)
    {
        centerX += x;
        centerY += y;
    }

    public override string render()
    {
        string renderTemp = "Circle(" + color + "," + centerX + "," + centerY + "," + radius + ")";
        return renderTemp;
    }

    //Set value functions
    public void setCenterX(double X)
    {
        centerX = X;
    }
    public void setCenterY(double Y)
    {
        centerY = Y;
    }
    public void setRadius(double R)
    {
        radius = R;
    }

    //Get value functions
    public double getCenterX()
    {
        return centerX;
    }
    public double getCenterY()
    {
        return centerY;
    }
    public double getRadius()
    {
        return radius;
    }
}

class Triangle : Shape
{
    //Attributes
    string color;
    double topX, topY, leftX, leftY, rightX, rightY;

    //Methods
    public Triangle(string C, double tX, double tY, double lX, double lY, double rX, double rY)
    {
        color = C;
        topX = tX; topY = tY;
        leftX = lX; leftY = lY;
        rightX = rX; rightY = rY;
    }
    public override double area()
    {
        shapeArea = .5 * (topX * (leftY - rightY) + leftX * (rightY - topY) + rightX * (topY - leftY));
        return shapeArea;
    }
    public override string getColor()
    {
        return color;
    }
    public override void move(double x, double y)
    {
        topX += x;
        topY += y;
        leftX += x;
        leftY += y;
        rightX += x;
        rightY += y;
    }

    public override string render()
    {
        string renderTemp = "Triangle(" + color + "," + topX + "," + topY + "," + leftX + "," + leftY + "," + rightX + "," + rightY + ")";
        return renderTemp;
    }

    //Set value functions
    public void setCornerX1(double X) //Top corner X
    {
        topX = X;
    }
    public void setCornerY1(double Y) //Top corner Y
    {
        topY = Y;
    }
    public void setCornerX2(double X) //Left corner X
    {
        leftX = X;
    }
    public void setCornerY2(double Y) //Left corner Y
    {
        leftY = Y;
    }
    public void setCornerX3(double X) //Right corner X
    {
        rightX = X;
    }
    public void setCornerY3(double Y) //Right corner Y
    {
        rightY = Y;
    }

    //Get value functions
    public double getCornerX1()
    {
        return topX;
    }
    public double getCornerY1()
    {
        return topY;
    }
    public double getCornerX2()
    {
        return leftX;
    }
    public double getCornerY2()
    {
        return leftY;
    }
    public double getCornerX3()
    {
        return rightX;
    }
    public double getCornerY3()
    {
        return rightY;
    }
}
class Polygon : Shape
{
    //Attributes
    string color;
    double[] pts = new double[20];
    int vertices;

    //Methods
    public Polygon(string C, double[] P, int V)
    {
        for (int i = 0; i < V * 2; i++)
        {
            pts[i] = P[i];
        }
        color = C;
        vertices = V;      
    }
    public override double area()
    {
        double temp = 0.0;
        int j = vertices - 1;
        for (int i = 0; i < vertices * 2 - 1; i += 2)
        {
            temp += (pts[j] + pts[i]) * (pts[j + 1] - pts[i + 1]);

            //j is previous vertex to i
            j = i;
        }
        shapeArea = Math.Abs(temp / 2.0);
        return shapeArea;
    }
    public override double perimeter()
    {
        //Using a^2 + b^2 = c^2
        for (int i = 0; i < vertices * 2 - 1; i += 2)
        {
            shapePerimeter += Math.Sqrt(Math.Pow(Math.Abs(pts[i] - pts[i + 2]), 2) + Math.Pow(Math.Abs(pts[i + 1] - pts[i + 3]), 2));
        }
        shapePerimeter += Math.Sqrt(Math.Pow(Math.Abs(pts[0] - pts[vertices * 2 - 2]), 2) + Math.Pow(Math.Abs(pts[1] - pts[vertices * 2 - 1]), 2));
        return shapePerimeter;
    }
    public override string getColor()
    {
        return color;
    }
    public override void move(double x, double y)
    {
        for (int i = 0; i < vertices * 2 - 1; i += 2)
        {
            pts[i] += x;
            pts[i + 1] += y;
        }
    }

    public override string render()
    {
        string renderTemp = "Polygon(" + color + "," + vertices;
        for (int i = 0; i < vertices * 2; i++)
        {
            renderTemp += ",";
            renderTemp += Convert.ToString(pts[i]);
        }
        renderTemp += ")";
        return renderTemp;
    }

    //Set value functions
    public void setVertexX(int V, double X)
    {
        pts[V * 2] = X;
    }
    public void setVertexY(int V, double Y)
    {
        pts[V * 2 + 1] = Y;
    }

    //Get value functions
    public double getVertexX(int V)
    {
        return pts[V * 2];
    }
    public double getVertexY(int V)
    {
        return pts[V * 2 + 1];
    }
    public int getNumpoints()
    {
        return vertices;
    }
}