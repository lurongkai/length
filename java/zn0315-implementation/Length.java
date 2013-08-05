package sctest.length;

import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.PrintWriter;

public class Length {
	private static String defaultInputFile="input.txt";
	private static String defaultOutputFile="output.txt";
	private Calculator cal;
	private PrintWriter out;
	
	public Length() throws IOException {
		cal = new Calculator();
		out = new PrintWriter(defaultOutputFile);
	}
	
	public void process(String fileName) throws FileNotFoundException, IOException, SyntaxError, CalculationError {
		Parser parser = null;
		parser = new Parser(fileName);
		outputHeader();
		while (parser.hasNext()) {
			Statement stmt = parser.next();
			switch(stmt.getType()) {
			case DEFINITION:
				addDefinition((Definition)stmt);
				break;
			case EXPRESSION:
				try {
					calExpression((Expression)stmt);
				} catch (CalculationError e) {
					e.setLine(parser.getLineNo());
					throw e;
				}
				break;
			default: // don't process blank
				break;
			}
		}
		
		out.close();
	}
	
	private void outputHeader() {
		out.println("zn0315@163.com");
		out.println("");
	}
	
	private void addDefinition(Definition def) {
		cal.addDef(def);
	}
	
	private void calExpression(Expression exp) throws CalculationError {
		double result = cal.caculate(exp);
		out.format("%1$.2f m\n", result);
	}
	
	public static void main(String[] args) {
		
		try {
			Length length = new Length();
			if (args.length==0) 
				length.process(defaultInputFile);
			else
				length.process(args[0]);
		} catch (SyntaxError e) {
			System.err.println(e.getMessage());
		} catch (CalculationError e) {
			System.err.println(e.getMessage());
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

}
