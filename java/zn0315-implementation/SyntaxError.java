package sctest.length;

public class SyntaxError extends Exception {
	private static final long serialVersionUID = 1L;
	
	public SyntaxError(int line, String message) {
		super((new StringBuilder("line ")
					.append(line)
					.append(":")
					.append(message))
					.toString());
	}
}
