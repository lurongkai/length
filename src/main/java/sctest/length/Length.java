package sctest.length;

import java.io.FileNotFoundException;
import java.io.IOException;

public class Length {
	private static String defaultInputFile="input.txt";
	private static String defaultOutputFile="output.txt";

	public static void main(String[] args) {
		Length length = new Length();
		try {
			if (args.length==0) 
				length.process(defaultInputFile);
			else
				length.process(args[0]);
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
	
	public void process(String fileName) throws FileNotFoundException, IOException {
		Parser parser = null;
		parser = new Parser(fileName);
		while (parser.hasNext()) {
			Statement stmt = parser.next();
			switch(stmt.getType()) {
			case DEFINITION:
				addDefinition((Definition)stmt);
				break;
			case EXPRESSION:
				calExpression((Expression)stmt);
				break;
			default: // don't process blank
				break;
			}
		}
	}
	
	private void addDefinition(Definition def) {
		
	}
	
	private void calExpression(Expression exp) {
		
	}

}
