
public class ControleBonificacao {
	private double soma;
	
	public ControleBonificacao registra(Funcionario funcionario) {
		soma += funcionario.getBonificacao();
		return this;
	}
	
	public double getSoma() {
		return soma;
	}
}