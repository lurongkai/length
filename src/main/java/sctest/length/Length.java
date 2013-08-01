package sctest.length;

public class Length {
	private static String defaultFile="input.txt";
	/**
	 * @param args
	 */
	public static void main(String[] args) {
		Length length = new Length();
		if (args.length==0) 
			length.process(defaultFile);
		else
			length.process(args[0]);
	}
	
	public void process(String fileName) {
		Parser parser = null;
		parser = new Parser(fileName);
		while (parser.hasNext()) {
			Statement stmt = parser.next();
			switch(stmt.getType()) {
			case DEFINITION:
				addDef
				break;
			case EXPRESSION:
				break;
			default: // don't process blank
				break;
			}
			double result = Calculator.calculate(parser.next());
		}

		
	}

}
