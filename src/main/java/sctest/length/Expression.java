package sctest.length;

import java.util.ArrayList;
import java.util.Iterator;

public class Expression extends Statement {
	private ArrayList<ExpressItem> items;
	
	public Expression() {
		super(Type.EXPRESSION);
		items = new ArrayList<ExpressItem>();
	}
	
	public void addItem(String unit, double value) {
		items.add(new ExpressItem(unit,value));
	}
	
	public Iterator<ExpressItem> getItems() {
		return items.iterator();
	}
}
