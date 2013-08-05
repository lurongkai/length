package sctest.length;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;
import java.util.StringTokenizer;

public class Parser {
	private static Map<String,String> stemWords;
	static {
		stemWords = new HashMap<String,String>();
		stemWords.put("miles", "mile");
		stemWords.put("inches", "inch");
		stemWords.put("feet", "foot");
		stemWords.put("faths", "fath");
		stemWords.put("yards", "yard");
		stemWords.put("forlongs", "forlong");
		stemWords.put("meters", "meter");
	}
	private ArrayList<String> lines; //lazy eval , so use String instead of Statement
	private Iterator<String> iter;
	private int lineNo;
	
	public Parser(String fileName) throws FileNotFoundException, IOException {
		lines = new ArrayList<String>();
		
		try (BufferedReader reader = new BufferedReader(new FileReader(fileName))){
		      String line = null;
		      while ((line = reader.readLine()) != null) {
		    	  lines.add(line);
		      }
		}
		iter = lines.iterator();
		lineNo = 0;
	}
	
	public Statement next() throws SyntaxError {
		Statement result = null;
		lineNo ++;

		String line = iter.next().trim();
		if (line.length() == 0)
			result = new BlankStatement(); // should use a singleton blank statement?
		else if(line.contains("=")) {
			result = parseDefinition(line);
		} else {
			result = parseExpression(line);
		}
		return result;
	}
	
	public boolean hasNext() {
		return iter.hasNext();
	}
	
	public int getLineNo() {
		return lineNo;
	}
	
	// 1.2 miles
	// 3.02 miles + 17.5 yards - 0 fath
	private Expression parseExpression(String line) throws SyntaxError {
		ArrayList<Object> tokens = Collections.list(new StringTokenizer(line));
		int tokenNum = tokens.size();
		if (tokenNum < 2 
				|| ((tokenNum-2)%3!=0)) {
			throw new SyntaxError(lineNo, "expression syntax error");
		}
		Expression stmt = new Expression();
		addExpressItem(stmt, "+", (String)tokens.get(0), (String)tokens.get(1));
		for (int i=2; i<tokenNum; i=i+3) {
			addExpressItem(stmt, (String)tokens.get(i),(String)tokens.get(i+1),(String)tokens.get(i+2));
		}
		return stmt;
	}
	
	private void addExpressItem(Expression stmt, String sigh, String value, String unit) throws SyntaxError {
		double addend = toDouble(value);
		if (sigh.equals("-"))
			addend = 0-addend;
		stmt.addItem(stem(unit), addend);		
	}
	
	// 1 furlong = 201.17 m
	private Definition parseDefinition(String line) throws SyntaxError {
		ArrayList<Object> tokens = Collections.list(new StringTokenizer(line));
		if (tokens.size() != 5
				|| ! ((String)tokens.get(0)).equals("1") 
				|| ! ((String)tokens.get(2)).equals("=")
				|| ! ((String)tokens.get(4)).equals("m")) {
			throw new SyntaxError(lineNo, "definition syntax");
		}
		String rateStr = (String)tokens.get(3);
		double rate = toDouble(rateStr);
		Definition stmt = new Definition((String)tokens.get(1), rate);
		return stmt;
	}
	
	private double toDouble(String str) throws SyntaxError {
		double result;
		try {
			result = Double.parseDouble(str);
		} catch (Exception e) {
			throw new SyntaxError(lineNo, "numnber format error" + str);
		}
		return result;
	}
	
	private String stem(String word) {
		if (stemWords.containsKey(word))
			return stemWords.get(word);
		else
			return word;
	}
}
