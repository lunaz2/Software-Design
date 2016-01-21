package minesweeper;

import java.util.Random;
public class Minesweeper {

    private final int SIZE = 10;
    private Cover[][] cells = new Cover[SIZE][SIZE];
    public enum Cover {REVEALED, COVERED, FLAGGED};
    public enum GameStatus {STILLPROGRESS, WINNER, LOSING};
    public boolean[][] mines = new boolean[SIZE][SIZE];

    public Minesweeper() {
        for (int i = 0; i < SIZE; i++) {
            for (int j = 0; j < SIZE; j++) {
                cells[i][j] = Cover.COVERED;
                mines[i][j] = false;
            }
        }
    }

    public void generateMines(int numberOfWantedMines) {
        Random random = new Random();
        while(numberOfWantedMines > 0)
        {
            int row = random.nextInt(10);
            int column = random.nextInt(10);
            if(!mines[row][column]){
                mines[row][column] = true;
                numberOfWantedMines--;
            }
        }
    }
    
    public boolean isMineAt(int row, int column) {
        return checkBounds(row, column) && mines[row][column];
    }

    public boolean isEmptyAt(int row, int column){
        return !mines[row][column] && countAdjacentMine(row, column) == 0;
    }

    public boolean isAdjacentAt(int row, int column) {
        return !mines[row][column] && countAdjacentMine(row, column) != 0;
    }
    
    public int countAdjacentMine(int row, int column) {
        int mineCount = 0;
        if(checkBounds(row, column) && !mines[row][column]) {
            for(int i = 1; i> -2 ; i--) {
                for(int j = 1; j > -2 ; j--) {
                    if (checkBounds(row-i, column-j) && mines[row-i][column-j]) {
                        if(i != row || j != column)
                            mineCount++;
                    }
                }
            }
        }
        return mineCount;
    }

    public Cover getCover(int row, int column)
    {
        return cells[row][column];
    }

    public void reveal(int row, int column) {
        if(cells[row][column] == Cover.COVERED) {
            cells[row][column] = Cover.REVEALED;
            if(isEmptyAt(row, column) && !mines[row][column]) {
                revealNeighbor(row-1, column-1);
                revealNeighbor(row-1, column);
                revealNeighbor(row-1, column+1);
                revealNeighbor(row, column-1);
                revealNeighbor(row, column+1);
                revealNeighbor(row+1, column-1);
                revealNeighbor(row+1, column);
                revealNeighbor(row+1, column+1);
            }
        }
    }

    public void revealNeighbor(int row, int column) {
        if(checkBounds(row, column))
            reveal(row, column);
    }

    public void flag(int row, int column) {
        if(cells[row][column] == Cover.COVERED)
            cells[row][column] = Cover.FLAGGED;
        else if(cells[row][column] == Cover.FLAGGED)
            cells[row][column] = Cover.COVERED;
    }

    public boolean checkBounds(int row, int column) {
        return row >= 0 && row < SIZE && column >= 0 && column < SIZE;
    }
    
    public GameStatus getGameStatus()
    {
         int numberOfMineFlagged = 0;
         int numberOfRevealedCells = 0;
         for(int i = 0; i < SIZE; i++) {
             for(int j = 0; j < SIZE; j++)
             {
            	 if(mines[i][j] && cells[i][j] == Cover.REVEALED)
                  	return GameStatus.LOSING;
                 if(mines[i][j] && cells[i][j] == Cover.FLAGGED)
                     numberOfMineFlagged++;
                 if(cells[i][j] == Cover.REVEALED)
                     numberOfRevealedCells++;
             }
         }
        if( numberOfMineFlagged == 10 && numberOfRevealedCells == SIZE * SIZE - 10)
        	return GameStatus.WINNER;
    	return GameStatus.STILLPROGRESS;
    }
}
