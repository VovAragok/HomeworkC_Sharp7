
Main();

void Main()
{
	bool isWork = true;

	while (isWork)
	{
		Console.WriteLine("Enter command");
		string command = Console.ReadLine();

		switch (command)
		{
			case "47":
				Task47();
				break;
			case "50":
				Task50();
				break;
			case "52":
				Task52();
				break;
			case "exit":
				isWork = false;
				break;
		}
	}
}



// Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
void Task47()
{
    double [,] resultarray = CreateDoubleNewarray();
}
// Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, 
// и возвращает значение этого элемента или же указание, что такого элемента нет.
void Task50()
{
    Console.WriteLine("Task 50");
    Console.WriteLine("создадим новый массив");
    int [,] newRndArray = CreateIntNewarray();
    Console.WriteLine("для поиска элемента по позиции - нажмите 1");
    Console.WriteLine("для поиска эелемента по значению - нажмите 2");
    bool isWork = true;

	while (isWork)
	{
		Console.WriteLine("Enter command");
		string command = Console.ReadLine();

		switch (command)
		{
			case "1":
                Console.WriteLine("введите индекс елемента ");
                int line = ReadInt("line");
                Console.WriteLine("введите индекс елемента ");
                int column = ReadInt("column");
                int result = findIndex(newRndArray,line,column);
                break;
			case "2":
             Console.WriteLine("введите елемент который хотите найти в массиве ");
             int search = ReadInt("search element");
             Tuple <int, int> [] resultarr = findElement(newRndArray,search);
             
				
				break;
			case "exit":
				isWork = false;
				break;
		}
	}
    
     


}
// 52 Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.

// Например, задан массив:

void Task52()
{
    Console.WriteLine("Task 52");
    Console.WriteLine("создадим новый массив");
    int [,] newRndArray = CreateIntNewarray();
    double [] sumResultArray = Sumarray(newRndArray);
}



double [,] CreateDoubleNewarray()
{
    Console.WriteLine("введите количество строк для нового массива");
    int line = ReadInt("m");
    Console.WriteLine("введите количество столбцов для нового массива");
    int columnes = ReadInt("n");
    Console.WriteLine("укажите минимальный диапазон вещественных чисел в двумерном массиве");
    double rndMin = ReadDouble("min");
    Console.WriteLine (" укажите максимальный диапазон вещественных чисел в двумерном массиве");
    double rndMax = ReadDouble("max");
    double [,] newGenerateArray = Newarray(line,columnes,rndMin,rndMax);
    return newGenerateArray;

}
int [,] CreateIntNewarray()
{
    Console.WriteLine("введите количество строк для нового массива");
    int line = ReadInt("m");
    Console.WriteLine("введите количество столбцов для нового массива");
    int columnes = ReadInt("n");
    Console.WriteLine("укажите минимальный диапазон вещественных чисел в двумерном массиве");
    int rndMin = ReadInt("min");
    Console.WriteLine (" укажите максимальный диапазон вещественных чисел в двумерном массиве");
    int rndMax = ReadInt("max");
    int [,] newGenerateArray = IntNewarray(line,columnes,rndMin,rndMax);
    return newGenerateArray;

}





int ReadInt(string argument)
{
	Console.Write($"Input {argument}: ");
	int number;

	while (!int.TryParse(Console.ReadLine(), out number))
	{
		Console.WriteLine("Ooops. Try again!");
	}

	return number;
}

double ReadDouble(string argument)
{
	Console.Write($"Input {argument}: ");
	double number;

	while (!double.TryParse(Console.ReadLine(), out number))
	{
		Console.WriteLine("Ooops. Try again!");
	}

	return number;
}




double [,] Newarray(int m, int n, double a, double b) // функция для создания двумерного массива вещественных чисел.
{
    double [,] newarray = new double[m,n];
    Random rnd = new Random();
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
        newarray[i,j] = Math.Round(rnd.NextDouble()  * (b-a) + a, 2);
           Console.Write(newarray[i, j] + " ");
        }
        Console.WriteLine();
        
    }
    Console.WriteLine("Ваш сгененрированый двумерный массив вещественных чисел");
    return newarray;
   
}





int [,] IntNewarray(int m, int n, int a, int b) // функция для создания двумерного массива целых чисел.
{
    int  [,] newarray = new int[m,n];
    Random rnd = new Random();
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
        newarray[i,j] = rnd.Next(a, b+1);
           Console.Write(newarray[i, j] + " ");
        }
        Console.WriteLine();
        
    }
    Console.WriteLine("Ваш сгененерированый двумерный массив ");
    return newarray;
   
}



Tuple <int, int> [] findElement(int[,]newarray, int a) // функция для поиска элемента в двумерном массиве по значению.
{
    Tuple <int, int> [] resultTupleArray = new Tuple <int, int>[0];
    int count =0;
       for (int i = 0; i <  newarray.GetLength(0) ;i++)
    {
        for (int j = 0; j < newarray.GetLength(1); j++)
        {
            if (newarray[i,j] == a)
            {
                Array.Resize(ref resultTupleArray, resultTupleArray.Length + 1);
                resultTupleArray[count] = new Tuple<int, int>(i, j);
                count++;
            }
        }
    }
    if (count == 0)
    {
        Console.WriteLine("такого елемента нет в массиве");
    }
    else 
    {
        Console.Write("Найденные элементы: ");
        foreach (Tuple<int, int> element in resultTupleArray)
        {
            Console.Write($"({element.Item1}, {element.Item2}) ");
        }
        Console.WriteLine();
    }
    
    return resultTupleArray;
   
} 


int findIndex(int[,]newarray, int a, int b) // функция для поиска элемента по позиции в массиве
{
    int result = 0;
    if (newarray.GetLength(0)<= a || newarray.GetLength(1)<= b)
    {
        Console.WriteLine("в данной позиции двумерного массива нет такого елемента ");      
    }
    for (int i = 0; i < newarray.GetLength(0) ; i++)
    {
        for (int j = 0; j < newarray.GetLength(1); j++)
        {
            if (i == a && j == b)
            {
                Console.WriteLine($"в данной позиции {a}, {b} лежит елемент {newarray[i,j]}");
                result = newarray[i,j];
            }
        }
    }
   return result ;
   
} 


double[] Sumarray(int[,] newarray) // нахождение среднего арифмитического в столбцах 
{ 
    double[] averages = new double[newarray.GetLength(1)];
  
    for (int j = 0; j < newarray.GetLength(1); j++)
    {
        double sum = 0;

        for (int i = 0; i < newarray.GetLength(0); i++)
        {
            sum += newarray[i, j];
        }

        averages[j] = Math.Round(sum / newarray.GetLength(0),2);
    }

    for (int j = 0; j < averages.Length; j++)
    {
        Console.WriteLine($"Среднее арифметическое значений в столбце {j}: {averages[j]}");
    }

    return averages;
}

