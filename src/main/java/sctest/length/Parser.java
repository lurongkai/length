package sctest.length;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Iterator;
import java.util.StringTokenizer;

public class Parser {
	private ArrayList<String> lines; //lazy eval , so use String instead of Statement
	private Iterator<String> iter;
	int lineNo;
	
	public Parser(String fileName) throws FileNotFoundException, IOException {
		lines = new ArrayList<String>();
		
		try (BufferedReader reader = new BufferedReader(new FileReader(fileName))){
		      String line = null;
		      while ((line = reader.readLine()) != null) {
		    	  lines.add(line);
		      }
		}
		iter = lines.iterator();
		lineNo = 1;
	}
	
	public Statement next() throws SyntaxError {
		Statement result = null;
		String line = iter.next().trim();
		if (line.length() == 0)
			result = new BlankStatement(); // should use a singleton blank statement?
		else if(line.contains("=")) {
			result = parseDefinition(line);
		} else {
			result = new Expression();
		}
		lineNo ++;
		return result;
	}
	
	public boolean hasNext() {
		return iter.hasNext();
	}
	
	private Definition parseDefinition(String line) throws SyntaxError {
		ArrayList<Object> tokens = Collections.list(new StringTokenizer(line));
		if (tokens.size() != 5
				|| ! ((String)tokens.get(0)).equals("1") 
				|| ! ((String)tokens.get(2)).equals("=")
				|| ! ((String)tokens.get(4)).equals("m")) {
			throw new SyntaxError(new StringBuilder("definition syntax error at line:").append(lineNo).toString());
		}
		Definition stmt = new Definition();
		return stmt;
	}
}
