package minesweeper;

import java.util.*;

import org.junit.Before;
import org.junit.Test;

import static org.junit.Assert.*;
import minesweeper.Minesweeper.Cover;
import minesweeper.Minesweeper.GameStatus;

public class MinesweeperTest {

    Minesweeper minesweeperToDesignExpose;
    Minesweeper minesweeperToDesignRevealNeighbor;
    Minesweeper minesweeper;

    List<Integer> neighborCells;
    boolean revealCalled = false;

    @Before
    public void setUp() {
        neighborCells = new ArrayList<>();

        minesweeperToDesignExpose = new Minesweeper() {
            @Override
            public void revealNeighbor(int row, int column) {
                neighborCells.add(row);
                neighborCells.add(column);
            }
        };

        minesweeperToDesignRevealNeighbor = new Minesweeper(){
            @Override
            public void reveal(int row, int column) {
                    revealCalled = true;
            }

        };

        minesweeper = new Minesweeper();
    }

    @Test
    public void Canary() {
        assertTrue(true);
    }

    @Test
    public void RevealACell() {
      minesweeperToDesignExpose.reveal(0, 0);
      assertEquals(Cover.REVEALED, minesweeperToDesignExpose.getCover(0, 0));
    }

    @Test
    public void RevealAnAlreadyRevealCell() {
      minesweeperToDesignExpose.reveal(0, 0);
      minesweeperToDesignExpose.reveal(0, 0);
      assertEquals(Cover.REVEALED, minesweeperToDesignExpose.getCover(0, 0));
    }

    private void checkBounds(Runnable block) {
      try {
          block.run();
          fail("Expected exception out of bound");
      }
      catch(IndexOutOfBoundsException ex) {
          assertTrue(true);
      }
    }

    @Test
    public void revealCellOutOfRowLowerBound() {
      checkBounds(() -> minesweeperToDesignExpose.reveal(-2, 3));
    }

    @Test
    public void revealCellOutOfRowUpperBound() {
      checkBounds(() -> minesweeperToDesignExpose.reveal(12, 3));
    }

    @Test
    public void revealCellOutOfColumnLowerBound() {
        checkBounds(() -> minesweeperToDesignExpose.reveal(2, -3));
    }

    @Test
    public void revealCellOutOfColunUpperBound() {
        checkBounds(() -> minesweeperToDesignExpose.reveal(2, 13));
    }
    
    @Test
    public void revealEmptyCellWillRevealNeighborCell() {
        minesweeperToDesignExpose.reveal(2, 3);
        List<Integer> expected = Arrays.asList(1, 2, 1, 3, 1, 4, 2, 2, 2, 4, 3, 2, 3, 3, 3, 4);
        assertEquals(expected, neighborCells);
    }

    @Test
    public void revealingARevealedCellWillNotTryToRevealNeighbors() {
        minesweeperToDesignExpose.reveal(2, 3);
        neighborCells.clear();
        List<Integer> empty = new ArrayList<>();
        minesweeperToDesignExpose.reveal(2, 3);
        assertEquals(empty, neighborCells);
    }

    @Test
    public void revealNeighborCallsRevealWhenValidCellIsGiven() {
        minesweeperToDesignRevealNeighbor.revealNeighbor(2, 3);
        assertTrue(revealCalled);
    }

    @Test
    public void revealNeighborWillNotCallRevealOutOfRowLowerBound() {
        minesweeperToDesignRevealNeighbor.revealNeighbor(-2, 3);
        assertFalse(revealCalled);
    }

    @Test
    public void revealNeighborWillNotCallRevealOutOfRowUpperBound() {
        minesweeperToDesignRevealNeighbor.revealNeighbor(12, 3);
        assertFalse(revealCalled);
    }

    @Test
    public void revealNeighborWillNotCallRevealOutOfColumnLowerBound() {
        minesweeperToDesignRevealNeighbor.revealNeighbor(2, -3);
        assertFalse(revealCalled);

    }

    @Test
    public void revealNeighborWillNotCallRevealOutOfColumnUpperBound() {
        minesweeperToDesignRevealNeighbor.revealNeighbor(2, 13);
        assertFalse(revealCalled);

    }

    @Test
    public void flagACell() {
        minesweeperToDesignExpose.flag(2, 3);
        assertEquals(Cover.FLAGGED, minesweeperToDesignExpose.getCover(2, 3));
    }

    @Test
    public void flagARevealedCell() {
        minesweeperToDesignExpose.reveal(2, 3);
        minesweeperToDesignExpose.flag(2, 3);
        assertEquals(Cover.REVEALED, minesweeperToDesignExpose.getCover(2, 3));
    }

    @Test
    public void flaggedCellCannotBeRevealed() {
        minesweeperToDesignExpose.flag(2, 3);
        minesweeperToDesignExpose.reveal(2, 3);
        assertEquals(Cover.FLAGGED, minesweeperToDesignExpose.getCover(2, 3));
    }

    @Test
    public void flagCellOutOfRowLowerBound() {
        checkBounds(() -> minesweeperToDesignExpose.flag(-2, 3));
    }

    @Test
    public void flagCellOutOfRowUpperBound() {
        checkBounds(() -> minesweeperToDesignExpose.flag(12, 3));
    }

    @Test
    public void flagCellOutOfColumnLowerBound() {
        checkBounds(() -> minesweeperToDesignExpose.flag(2, -3));
    }

    @Test
    public void flagCellOutOfColumnUpperBound() {
        checkBounds(() -> minesweeperToDesignExpose.flag(2, 13));
    }

    @Test
    public void unflagAFlaggedCell() {
        minesweeperToDesignExpose.flag(2, 3);
        minesweeperToDesignExpose.flag(2, 3);
        assertEquals(Cover.COVERED, minesweeperToDesignExpose.getCover(2, 3));
    }

    @Test
    public void revealWillNotCallRevealNeighborOnAFlaggedCell() {
        minesweeperToDesignExpose.flag(2, 3);
        minesweeperToDesignExpose.reveal(2, 3);
        List<Integer> empty = new ArrayList<>();
        assertEquals(empty, neighborCells);
    }

    @Test
    public void revealWillNotCallRevealNeighborOnMineCell() {
        minesweeperToDesignExpose.mines[2][3] = true;
        minesweeperToDesignExpose.reveal(2, 3);
        List<Integer> empty = new ArrayList<>();
        assertEquals(empty, neighborCells);
    }

    @Test
    public void revealWillNotCallRevealNeighborOnAdjacentCell() {
        minesweeperToDesignExpose.mines[2][3] = true;
        minesweeperToDesignExpose.reveal(1, 3);
        List<Integer> empty = new ArrayList<>();
        assertEquals(empty, neighborCells);
    }

    @Test
    public void isThereAMine() {
        minesweeperToDesignExpose.mines[2][3] = true;
        assertEquals(true, minesweeperToDesignExpose.isMineAt(2,3));
    }
    
    @Test
    public void isThereAMineOutOfRowLowerBound() {
        assertEquals(false, minesweeperToDesignExpose.isMineAt(-2,3));
    }
    
    @Test
    public void isThereAMineOutOfRowUpperBound() {
        assertEquals(false, minesweeperToDesignExpose.isMineAt(12,3));
    }
    
    @Test
    public void isThereAMineOutOfOutOfColumnLowerBound() {
        assertEquals(false, minesweeperToDesignExpose.isMineAt(2,-3));
    }

    @Test
    public void isThereAMineOutOfColumnUpperBound() {
        assertEquals(false, minesweeperToDesignExpose.isMineAt(2,13));
    }

    @Test
    public void countTenMines() {
        minesweeper.generateMines(10);
        int MineCounter = 0;
        for(int i = 0; i < 10; i++)
        	for(int j = 0; j < 10; j++)
        		if(minesweeper.isMineAt(i,j))
        			MineCounter++;
        assertEquals(10, MineCounter);
    }
    
    @Test
    public void countAdjacentMine() {
        minesweeperToDesignExpose.mines[1][2] = true;
        minesweeperToDesignExpose.mines[2][2] = true;
        minesweeperToDesignExpose.mines[2][4] = true;
        minesweeperToDesignExpose.mines[3][3] = true;
        minesweeperToDesignExpose.mines[3][4] = true;
        assertEquals(5, minesweeperToDesignExpose.countAdjacentMine(2,3));
    }
    
    @Test
    public void countAdjacentMineOnMineCell() {
        minesweeperToDesignExpose.mines[2][3] = true;
        minesweeperToDesignExpose.mines[2][2] = true;
        assertEquals(0, minesweeperToDesignExpose.countAdjacentMine(2,3));
    }
    
    @Test
    public void countAdjacentMineOnCellOutOfRowLowerBound() {
        minesweeperToDesignExpose.mines[0][0] = true;
        assertEquals(0, minesweeperToDesignExpose.countAdjacentMine(-1,0));
    }
    
    @Test
    public void countAdjacentMineOnCellOutOfRowUpperBound() {
        minesweeperToDesignExpose.mines[9][0] = true;
        assertEquals(0, minesweeperToDesignExpose.countAdjacentMine(10,0));
    }
    
    @Test
    public void countAdjacentMineOnCellOutOfColumnLowerBound() {
        minesweeperToDesignExpose.mines[0][0] = true;
        assertEquals(0, minesweeperToDesignExpose.countAdjacentMine(0,-1));
    }
    
    @Test
    public void countAdjacentMineOnCellOutOfColumnUpperBound() {
        minesweeperToDesignExpose.mines[0][9] = true;
        assertEquals(0, minesweeperToDesignExpose.countAdjacentMine(0,10));
    }
    
    @Test
    public void isAdjacentCell() {
        minesweeperToDesignExpose.mines[1][2] = true;
        assertEquals(true, minesweeperToDesignExpose.isAdjacentAt(2,3));
    }
    
    @Test
    public void isAdjacentCellAlsoAMineCell() {
        minesweeperToDesignExpose.mines[1][2] = true;
        assertEquals(false, minesweeperToDesignExpose.isAdjacentAt(1,2));
    }

    @Test
    public void isAdjacentCellAlsoAnEmptyCell() {
        minesweeperToDesignExpose.mines[1][2] = true;
        assertEquals(false, minesweeperToDesignExpose.isAdjacentAt(2,4));
    }
    
    @Test
    public void isEmptyCell() {
        minesweeperToDesignExpose.mines[1][2] = true;
        assertEquals(true, minesweeperToDesignExpose.isEmptyAt(3,3));
    }
    
    @Test
    public void isEmptyCellAlsoAMineCell() {
        minesweeperToDesignExpose.mines[1][2] = true;
        assertEquals(false, minesweeperToDesignExpose.isEmptyAt(1,2));
    }

    @Test
    public void isEmptyCellAlsoAnAdjacentCell() {
        minesweeperToDesignExpose.mines[1][2] = true;
        assertEquals(false, minesweeperToDesignExpose.isEmptyAt(2,2));
    }
    
    @Test
    public void isGameInProgress() {
        minesweeper.mines[1][2] = true;
        minesweeper.reveal(1, 1);
        assertEquals(GameStatus.STILLPROGRESS, minesweeper.getGameStatus());
    }
    
    @Test
    public void isGameOver() {
        minesweeper.mines[1][2] = true;
        minesweeper.reveal(1, 2);
        assertEquals(GameStatus.LOSING, minesweeper.getGameStatus());
    }

    @Test
    public void isWin() {
        for(int i = 0; i < 10; i++) {
            minesweeper.mines[i][2] = true;
            minesweeper.flag(i, 2);
        }
        minesweeper.reveal(0, 0);
        minesweeper.reveal(0, 9);
        assertEquals(GameStatus.WINNER, minesweeper.getGameStatus());
    }
    
    @Test 
    public void isMineAtRandomLocation() {
    	boolean [][] mines = new boolean [10][10];
        minesweeper.generateMines(10);
        mines = minesweeper.mines;
        minesweeper =  new Minesweeper(); 
        minesweeper.generateMines(10);
        assertEquals(false, Arrays.equals(mines , minesweeper.mines));
    }
}
