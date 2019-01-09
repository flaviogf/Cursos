import static java.lang.String.format;

public abstract class Funcionario {
	private String nome;
	private String cpf;
	private double salario;
	
	public Funcionario(String nome, String cpf, double salario) {
		super();
		this.nome = nome;
		this.cpf = cpf;
		this.salario = salario;
	}

	public String getNome() {
		return nome;
	}
	
	public String getCpf() {
		return cpf;
	}
	
	public double getSalario() {
		return salario;
	}
	
	public abstract double getBonificacao();
	
	@Override
	public String toString() {
		return format("Funcionario(nome=%s, cpf=%s, salario=%.2f, bonificacao=%.2f)", nome, cpf, salario, getBonificacao());
	}
}
