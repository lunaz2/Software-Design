package minesweeper.ui;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseMotionListener;

import javax.swing.SwingUtilities;

public class Mouse implements MouseListener, MouseMotionListener
{
	private int mouseXPosition;
	private int mouseYPosition;
	private boolean RightClicked;
	private boolean LeftClicked;
	private boolean Inside;
	Mouse()
	{
		mouseXPosition = 0;
		mouseYPosition = 0;
		LeftClicked = false;
		RightClicked = false;
		Inside = false;
	}
	public void unclickRight() {
		RightClicked = false;
	}
	public void unclickLeft() {
		LeftClicked = false;
	}
	public boolean getRightClicked() {
		return RightClicked;
	}
	public boolean getLeftClicked() {
		return LeftClicked;
	}
	public int getXPosition() {
		return mouseXPosition;
	}
	public int getYPosition() {
		return mouseYPosition;
	}
	public boolean isInside(){
		return Inside;
	}
	@Override
	public void mouseClicked(MouseEvent event) {}
	@Override
	public void mouseEntered(MouseEvent event) 
	{
		Inside = true;
	}
	@Override
	public void mouseExited(MouseEvent event) 
	{
		Inside = false;
	}
	@Override
	public void mousePressed(MouseEvent event) {
		if(SwingUtilities.isRightMouseButton(event))
		{
			RightClicked=true;
		}
		else if(SwingUtilities.isLeftMouseButton(event))
		{
			LeftClicked=true;
		}
	}
	@Override
	public void mouseReleased(MouseEvent event) {}
	@Override
	public void mouseDragged(MouseEvent event) 
	{
		mouseMoved(event);
	}
	@Override
	public void mouseMoved(MouseEvent event) 
	{
		mouseXPosition = event.getX();
		mouseYPosition = event.getY();
	}

}
