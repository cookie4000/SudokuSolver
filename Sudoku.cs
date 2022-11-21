public class SudokuSolver {

    public const int GRID_SIZE=9;
    public const int SQUARE_SIZE=3;
    private int [,] board;

    public SudokuSolver (int[,] boardToSolve){
        board=boardToSolve;
    }
    public bool IsRowUnique(int row,int numberToCheck) {
      // if the number we are checking is in the row - its not a valid number
      for (int i = 0; i < GRID_SIZE; i++)
        {
            if (this.board[row, i] == numberToCheck)
            {
                return false;
            }
        }  
        return true;
    }
    public bool IsColUnique(int col, int numberToCheck) {
        for (int i = 0; i < GRID_SIZE; i++)
        {
            if (this.board[i, col] == numberToCheck)
            {
                return false;
            }
        }  
        return true;
    }
    public bool IsSquareUnique(int row, int col, int numberToCheck) {
        
        // Get the starting positions
        int rowStart = row - row % SQUARE_SIZE;
        int ColStart = col - col % SQUARE_SIZE;

        // Loop through the square see if they equal the number to check - if so it isnt right.
        for (int r = rowStart;
             r < rowStart + SQUARE_SIZE; r++)
        {
            for (int c = ColStart;
                 c < ColStart + SQUARE_SIZE; c++)
            {
                if (board[r, c] == numberToCheck)
                {
                    return false;
                }
            }
        }

        return true;
    }

public bool IsValueOK (int row, int col, int numberToCheck) {
    
    bool isRowOK = IsRowUnique(row,numberToCheck);
    bool isColOK = IsColUnique(col,numberToCheck);
    bool isSquareOK = IsSquareUnique(row,col,numberToCheck);

    if (isRowOK && isColOK && isSquareOK) {
        return true;
    }

    return false;
}

public bool solveSudoku()
    {
        int row=0;
        int col=0;
        bool isEmpty = true;
        for (int r = 0; r < GRID_SIZE; r++)
        {
            for (int c = 0; c < GRID_SIZE; c++)
            {
                if (board[r, c] == 0) {
                    row = r;
                    col = c;

                    // More Numbers to calculate
                    isEmpty = false;
                    break;
                }
            }
            if (!isEmpty) {
                break;
            }
        }
 
        // Complete
        if (isEmpty) {
            return true;
        }
 
        // else backtrack
        for (int numberToCheck = 1; numberToCheck <= GRID_SIZE; numberToCheck++)
        {
            if (IsValueOK(row, col, numberToCheck))
            {
                board[row, col] = numberToCheck;
                if (solveSudoku()){
                    return true;
                }
                else {
                    // Replace it
                    board[row, col] = 0;
                }
            }
        }
        return false;
    }

 public void printResult()
    {
        for (int r = 0; r < GRID_SIZE; r++)
        {
            for (int d = 0; d < GRID_SIZE; d++)
            {
                Console.Write(this.board[r, d]);
                Console.Write(" ");
            }
            Console.Write("\n");
        }
    }

    static public void Main(String[] args) {
   
    int[, ] sodokuToSolve = new int[, ] {
            { 9, 8, 7, 0, 0, 2, 0, 1, 0 },
            { 0, 0, 0, 0, 0, 0, 7, 8, 0 },
            { 0, 0, 0, 0, 0, 7, 0, 3, 4 },

            { 6, 0, 9, 0, 0, 8, 0, 0, 3 },
            { 0, 2, 3, 0, 0, 0, 5, 9, 0 },
            { 8, 0, 0, 9, 0, 0, 4, 0, 6 },

            { 7, 5, 0, 3, 0, 0, 0, 0, 0 },
            { 0, 4, 8, 0, 0, 0, 0, 0, 0 },
            { 0, 9, 0, 1, 0, 0, 2, 4, 7 }
            };
        
        
        SudokuSolver mySolver = new SudokuSolver(sodokuToSolve);

        if (mySolver.solveSudoku()){
            // print solution
            mySolver.printResult();
        }
        else {
            Console.Write("No solution possible");
        }
    }
}
