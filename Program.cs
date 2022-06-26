    int SIZE = 3;
    char EMPTY = '-';
    char CROSS = 'X';
    char ZERO = 'O';

    void main(String[] args)
    {
        char[,] field = new char[SIZE, SIZE];
        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                field[i,j] = EMPTY;
            }
        }

        int scanner = Convert.ToInt32(Console.ReadLine());
        bool isCrossTurn = true;

        while (true)
        {
            printField(field);
            Console.WriteLine("Ходят " + (isCrossTurn ? "крестики" : "нолики") + "!");
            String input = Console.ReadLine(); // "2 3"
            String[] parts = input.Split(" "); // ["2" , "3"]
            int r = Convert.ToInt32(parts[0]) - 1; // 2-1 = 1
            int c = Convert.ToInt32(parts[1]) - 1; // 3-1 = 2

            if (field[r,c] != EMPTY)
            {
                Console.WriteLine("Сюда ходить нельзя");
                continue;
            }

            field[r][c] = isCrossTurn ? CROSS : ZERO;
            if (isWin(field, isCrossTurn ? CROSS : ZERO))
            {
                printField(field);
                Console.WriteLine("Победили " + (isCrossTurn ? "крестики" : "нолики"));
                break;
            }
            else
            {
                if (isCrossTurn)
                {
                    isCrossTurn = false;
                }
                else
                {
                    isCrossTurn = true;
                }
                //isCrossTurn = !isCrossTurn;
            }
        }

        Console.WriteLine("Игра закончена!");

        bool isWin(char[][] field, char player)
        {
            int rowCount = 0;
            int columnCount = 0;
            int diagonalCount = 0;
            int reverseDiagonalCount = 0;
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    if (field[i][j] == player)
                    {
                        rowCount++;
                    }
                    if (field[j][i] == player)
                    {
                        columnCount++;
                    }
                    if ((i == j) && field[i][j] == player)
                    {
                        diagonalCount++;
                    }
                    if (field[SIZE - i - 1][j] == player)
                    {
                        reverseDiagonalCount++;
                    }
                }
                if (rowCount == SIZE || columnCount == SIZE || diagonalCount == SIZE || reverseDiagonalCount == SIZE)
                {
                    return true;
                }
                rowCount = 0;
                columnCount = 0;
            }
            return false;
        }

        void printField(char[][] field)
        {
            foreach (char[] row in field)
            {
                foreach (char cell in row)
                {
                    Console.WriteLine(cell + " ");
                }
                Console.WriteLine();
            }
        }
    }


