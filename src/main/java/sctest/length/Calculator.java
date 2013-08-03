package sctest.length;

import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;

public class Calculator {
	Map<String, Double> rates;
	
	public Calculator() {
		rates = new HashMap<String, Double>();
		addDef(new Definition("meter",1));
	}
	
	public double caculate(Expression expression) throws CalculationError {
		double result = 0;
		
		Iterator<ExpressItem> itemIter = expression.getItems();
		while (itemIter.hasNext()) {
			ExpressItem item = itemIter.next();
			String unit = item.getUnit();
			if (!rates.containsKey(unit)) {
				throw new CalculationError("not rate def for " + unit);
			}
			result = result + item.getValue() * rates.get(unit);
		}
		return (result);
	}
	
	public void addDef(Definition def) {
		rates.put(def.getUnit(), def.getRate());
	}

}
