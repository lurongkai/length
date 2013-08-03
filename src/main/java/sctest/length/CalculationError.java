package sctest.length;

public class CalculationError extends Exception {
	private static final long serialVersionUID = 1L;

	private String message;
	int line;
	public CalculationError(String message) {
		this.message = message;
	}
	
	public void setLine(int line) {
		this.line = line;
	}
	
	public String getMessage() {
		StringBuilder sb = new StringBuilder("line ").append(line).append(":").append(message);
		return sb.toString();
	}
}
