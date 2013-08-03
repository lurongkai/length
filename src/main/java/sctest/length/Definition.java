package sctest.length;

public class Definition extends Statement {

	private String unit;
	private double rate;
	public Definition(String unit, double rate) {
		super(Type.DEFINITION);
		this.unit = unit;
		this.rate = rate;
	}
	public String getUnit() {
		return unit;
	}
	public double getRate() {
		return rate;
	}
	
}
