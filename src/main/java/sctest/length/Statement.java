package sctest.length;

public abstract class Statement {
	public enum Type {DEFINITION, EXPRESSION, BLANK};

	private Type type;
	
	public Statement(Type type) {
		this.type = type;
	}
	
	public Type getType() {return type;};
}
