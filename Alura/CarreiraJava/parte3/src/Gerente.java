import static java.lang.String.format;

public class Gerente extends FuncionarioAutenticavel {	
	public Gerente(String nome, String cpf, double salario, String senha) {
		super(nome, cpf, salario, senha);
	}
	
	@Override
	public double getBonificacao() {
		return super.getSalario() + getSalario();
	}
	
	@Override
	public String toString() {
		return format("Gerente(nome=%s, cpf=%s, salario=%.2f, bonificacao=%.2f)", getNome(), getCpf(), getSalario(), getBonificacao());
	}
}
