package minesweeper.ui;

import javax.imageio.ImageIO;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JPanel;

import java.awt.Color;
import java.awt.Graphics;
import java.awt.image.BufferedImage;
import java.io.File;

import minesweeper.Minesweeper;
import minesweeper.Minesweeper.Cover;
import minesweeper.Minesweeper.GameStatus;
public class MinesweeperUI 
{
	 public static void main(String[] args) {
		final int ImageSize = 25;
		final int NumberOfMines = 10;
		final int Size = 10;
        Minesweeper minesweeper = new Minesweeper();
        minesweeper.generateMines(NumberOfMines);
        GameStatus status = minesweeper.getGameStatus();
        BufferedImage buffer = new BufferedImage(250,250,BufferedImage.TYPE_INT_ARGB);
        Graphics bufferGraphics = buffer.getGraphics();
        Mouse mouse = new Mouse();
        JPanel panel = new JPanel();
        panel.setFocusable(true);
        panel.setLayout(null);
        panel.addMouseListener(mouse);
        panel.addMouseMotionListener(mouse);
        JFrame frame = new JFrame("Minesweeper");
        frame.setBounds(0,0,256,279);
        frame.setVisible(true);
        frame.setResizable(false);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.getContentPane().add(panel);
        BufferedImage CoveredImage = null;
        BufferedImage FlagImage = null;
        BufferedImage MineImage = null;
        BufferedImage EmptyImage = null;
        BufferedImage OneImage = null;
        BufferedImage TwoImage = null;
        BufferedImage ThreeImage = null;
        BufferedImage FourImage = null;
        BufferedImage FiveImage = null;
        BufferedImage SixImage = null;
        BufferedImage SevenImage = null;
        BufferedImage EightImage = null;
        boolean ImageLoaded = false;
        bufferGraphics.setColor(new Color(.8f,.8f,0f,.4f));
        try
        {
            BufferedImage minesweeperImage = ImageIO.read(new File("Images\\minesweeper.png"));
        	CoveredImage = minesweeperImage.getSubimage(128*0, 128*0, 128, 128);
            FlagImage    = minesweeperImage.getSubimage(128*1, 128*0, 128, 128);
            MineImage    = minesweeperImage.getSubimage(128*2, 128*0, 128, 128);
            EmptyImage   = minesweeperImage.getSubimage(128*3, 128*0, 128, 128);
            OneImage     = minesweeperImage.getSubimage(128*0, 128*1, 128, 128);
            TwoImage     = minesweeperImage.getSubimage(128*1, 128*1, 128, 128);
            ThreeImage   = minesweeperImage.getSubimage(128*2, 128*1, 128, 128);
            FourImage    = minesweeperImage.getSubimage(128*3, 128*1, 128, 128);
            FiveImage    = minesweeperImage.getSubimage(128*0, 128*2, 128, 128);
            SixImage     = minesweeperImage.getSubimage(128*1, 128*2, 128, 128);
            SevenImage   = minesweeperImage.getSubimage(128*2, 128*2, 128, 128);
            EightImage   = minesweeperImage.getSubimage(128*3, 128*2, 128, 128);
        	ImageLoaded = true;
        }
        catch(Exception exeption)
        {
        	JOptionPane.showMessageDialog(null, exeption.toString());
        }
        while(ImageLoaded)
        {
        	status = minesweeper.getGameStatus();
        	if(status == GameStatus.LOSING)
        	{
            	for(int i = 0; i < Size; i++)
            		for(int j = 0; j < Size; j++)
            			if(minesweeper.isMineAt(i, j))
            				minesweeper.reveal(i, j);
        	}
        	else
        	{
	        	if(mouse.getRightClicked())
	        	{
	        		minesweeper.flag(mouse.getXPosition()/ImageSize, mouse.getYPosition()/ImageSize);
	        		mouse.unclickRight();
	        	}
	        	if(mouse.getLeftClicked())
	        	{
	        		minesweeper.reveal(mouse.getXPosition()/ImageSize, mouse.getYPosition()/ImageSize);
	        		mouse.unclickLeft();
	        	}
        	}
        	for(int i = 0; i < Size; i++)
        	{
        		for(int j = 0; j < Size; j++)
        		{
        			if(minesweeper.getCover(i, j) == Cover.FLAGGED)
        				bufferGraphics.drawImage(FlagImage, i*ImageSize, j*ImageSize, ImageSize, ImageSize,null);
        			else if(minesweeper.getCover(i, j) == Cover.COVERED)
        				bufferGraphics.drawImage(CoveredImage, i*ImageSize, j*ImageSize, ImageSize, ImageSize,null);
        			else if(minesweeper.getCover(i , j) == Cover.REVEALED)
        			{
        				if(minesweeper.isEmptyAt(i, j))
            				bufferGraphics.drawImage(EmptyImage, i*ImageSize, j*ImageSize, ImageSize, ImageSize,null);
        				else if(minesweeper.isMineAt(i, j))
            				bufferGraphics.drawImage(MineImage, i*ImageSize, j*ImageSize, ImageSize, ImageSize,null);
        				else if(minesweeper.isAdjacentAt(i, j))
        				{
        					switch(minesweeper.countAdjacentMine(i, j))
        					{
        					case 1:
                				bufferGraphics.drawImage(OneImage, i*ImageSize, j*ImageSize, ImageSize, ImageSize,null);
        						break;
        					case 2:
                				bufferGraphics.drawImage(TwoImage, i*ImageSize, j*ImageSize, ImageSize, ImageSize,null);
        						break;
        					case 3:
                				bufferGraphics.drawImage(ThreeImage, i*ImageSize, j*ImageSize, ImageSize, ImageSize,null);
        						break;
        					case 4:
                				bufferGraphics.drawImage(FourImage, i*ImageSize, j*ImageSize, ImageSize, ImageSize,null);
        						break;
        					case 5:
                				bufferGraphics.drawImage(FiveImage, i*ImageSize, j*ImageSize, ImageSize, ImageSize,null);
        						break;
        					case 6:
                				bufferGraphics.drawImage(SixImage, i*ImageSize, j*ImageSize, ImageSize, ImageSize,null);
        						break;
        					case 7:
                				bufferGraphics.drawImage(SevenImage, i*ImageSize, j*ImageSize, ImageSize, ImageSize,null);
        						break;
        					case 8:
                				bufferGraphics.drawImage(EightImage, i*ImageSize, j*ImageSize, ImageSize, ImageSize,null);
        						break;
        					}
        				}
        			}
        		}
        	}
        	if(status == GameStatus.STILLPROGRESS && mouse.isInside())
        		bufferGraphics.fillRect((mouse.getXPosition()/ImageSize)*ImageSize, (mouse.getYPosition()/ImageSize)*ImageSize, ImageSize, ImageSize);
			panel.getGraphics().drawImage(buffer, 0, 0,null);
			if(status == GameStatus.WINNER)
        	{
            	JOptionPane.showMessageDialog(null, "You Win");
                minesweeper = new Minesweeper();
                minesweeper.generateMines(NumberOfMines);
        	}
        	else if(status == GameStatus.LOSING)
        	{
            	JOptionPane.showMessageDialog(null, "Game Over");
                minesweeper = new Minesweeper();
                minesweeper.generateMines(NumberOfMines);
        	}
        }
    }
}
